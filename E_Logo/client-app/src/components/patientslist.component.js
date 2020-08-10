import React, { useEffect } from 'react';
import MaterialTable from 'material-table';
import API from '../api';
import Alert from '@material-ui/lab/Alert';
import { useSelector } from "react-redux";
import { useHistory } from "react-router-dom";


export default function PatientsList() {

  const userConnected = useSelector(state => state.userConnected);
  const history = useHistory();
  var columns = [
    { title: 'Fullname', field: 'fullname' },
    { title: 'Results', field: 'results' },
    { title: 'Diagnostic', field: 'diagnostique' },
    { title: 'Last Task Done', field: 'lastTaskDone' },
  ]
  const [data, setData] = React.useState([]); //table data
  //for error handling
  const [iserror, setIserror] = React.useState(false)
  const [errorMessages, setErrorMessages] = React.useState([])

  useEffect(() => {
    if (userConnected.id === -1) {
      history.push('/');
    }
    API.get(`/Patients/getallpatients/${userConnected.id}`)
      .then(res => {
        setData(res.data)
      }).catch(error => {
        console.log("Error")
      })
  }, [userConnected, history])

  const handleRowAdd = (newData, resolve) => {
    //validation
    let errorList = []
    newData.speechTherapistID = userConnected.id;
    if (newData.fullname === undefined) {
      errorList.push("Please enter fullname")
    }
    if (newData.diagnostique === undefined) {
      errorList.push("Please enter a diagnostic")
    }
    if (errorList.length < 1) { //no error
      API.post("/Patients/", newData)
        .then(res => {
          let dataToAdd = [...data];
          dataToAdd.push(newData);
          setData(dataToAdd);
          resolve()
          setErrorMessages([])
          setIserror(false)
        })
        .catch(error => {
          setErrorMessages(["Cannot add data. Server error!"])
          setIserror(true)
          resolve()
        })
    } else {
      setErrorMessages(errorList)
      setIserror(true)
      resolve()
    }
  };

  const handleRowUpdate = (newData, oldData, resolve) => {
    //validation
    let errorList = []
    if (newData.fullname === "") {
      errorList.push("Please enter fullname")
    }
    if (newData.diagnostique === "") {
      errorList.push("Please enter a diagnostic")
    }

    if (errorList.length < 1) {
      API.put("/patients/" + newData.id, newData)
        .then(res => {
          const dataUpdate = [...data];
          const index = oldData.tableData.id;
          dataUpdate[index] = newData;
          setData([...dataUpdate]);
          resolve()
          setIserror(false)
          setErrorMessages([])
        })
        .catch(error => {
          setErrorMessages(["Update failed! Server error"])
          setIserror(true)
          resolve()

        })
    } else {
      setErrorMessages(errorList)
      setIserror(true)
      resolve()

    }

  }

  const handleRowDelete = (oldData, resolve) => {
    API.delete("/patients/" + oldData.id)
      .then(res => {
        const dataDelete = [...data];
        const index = oldData.tableData.id;
        dataDelete.splice(index, 1);
        setData([...dataDelete]);
        resolve()
      })
      .catch(error => {
        setErrorMessages(["Delete failed! Server error"])
        setIserror(true)
        resolve()
      })
  }

  return (
    <div className="App">
      <div>
        {iserror &&
          <Alert severity="error">
            {errorMessages.map((msg, i) => {
              return <div key={i}>{msg}</div>
            })}
          </Alert>
        }
      </div>
      <MaterialTable
        options={{
          pageSize: 10,
          pageSizeOptions: [5, 10, 20, 30, 50, 75, 100],
          toolbar: true,
          paging: true
        }}
        title="Patients List"
        columns={columns}
        data={data}
        editable={{
          onRowUpdate: (newData, oldData) =>
            new Promise((resolve) => {
              handleRowUpdate(newData, oldData, resolve);

            }),
          onRowAdd: (newData) =>
            new Promise((resolve) => {
              handleRowAdd(newData, resolve)
            }),
          onRowDelete: (oldData) =>
            new Promise((resolve) => {
              handleRowDelete(oldData, resolve)
            }),
        }}
      />
    </div>
  );
}