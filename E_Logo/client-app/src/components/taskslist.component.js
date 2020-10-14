import React, { useEffect } from "react";
import MaterialTable from "material-table";
import API from "../api";
import Alert from "@material-ui/lab/Alert";
import { useSelector } from "react-redux";
import { useHistory } from "react-router-dom";

export default function TasksList() {
  const userConnected = useSelector((state) => state.userConnected);
  const history = useHistory();
  var columns = [
    
    { title: "Name", field: "name" },
  ];
  var columnsStimulis = [
 
    { title: "Name", field: "name" },
  ];
  var columnsResponses = [
    
    {title:"Type", field:"type"},
    { title: "Choice", field: "choice" },
    {title:"Bonne réponse", field:"isGoodAnswer"},
  ];
  const [data, setData] = React.useState([]); //table data
  //for error handling
  const [iserror, setIserror] = React.useState(false);
  const [errorMessages, setErrorMessages] = React.useState([]);

  useEffect(() => {
    if (userConnected.id === null || userConnected.id === -1) {
      history.push("/");
    } else {
      API.get(`/Tasks/`)
        .then((res) => {
          setData(res.data);
        })
        .catch((error) => {
          history.push("/");
        });
    }
  }, [userConnected, history]);

  //TASKS EDITABLE
  const handleRowAdd = (newData, resolve) => {
    //validation
    let errorList = [];
    newData.speechTherapistID = userConnected.id;
    if (newData.name === undefined) {
      errorList.push("Please enter a name");
    }
    if (errorList.length < 1) {
      //no error
      API.post("/Tasks/", newData)
        .then((res) => {
          let dataToAdd = [...data];
          dataToAdd.push(newData);
          setData(dataToAdd);
          resolve();
          setErrorMessages([]);
          setIserror(false);
          refreshPage();
        })
        .catch((error) => {
          setErrorMessages(["Cannot add data. Server error!"]);
          setIserror(true);
          resolve();
        });
    } else {
      setErrorMessages(errorList);
      setIserror(true);
      resolve();
    }
  };


  const handleRowUpdate = (newData, oldData, resolve) => {
    //validation
    let errorList = [];
    if (newData.name === "") {
      errorList.push("Please enter a name");
    }

    if (errorList.length < 1) {
      API.put("/Tasks/" + newData.id, newData)
        .then((res) => {
          const dataUpdate = [...data];
          const index = oldData.tableData.id;
          dataUpdate[index] = newData;
          setData([...dataUpdate]);
          resolve();
          setIserror(false);
          setErrorMessages([]);
          refreshPage();
        })
        .catch((error) => {
          setErrorMessages(["Update failed! Server error"]);
          setIserror(true);
          resolve();
        });
    } else {
      setErrorMessages(errorList);
      setIserror(true);
      resolve();
    }
  };

  const handleRowDelete = (oldData, resolve) => {
    API.delete("/Tasks/" + oldData.id)
      .then((res) => {
        const dataDelete = [...data];
        const index = oldData.tableData.id;
        dataDelete.splice(index, 1);
        setData([...dataDelete]);
        resolve();
        refreshPage();
      })
      .catch((error) => {
        setErrorMessages(["Delete failed! Server error"]);
        setIserror(true);
        resolve();
      });
  };
  //END TASKS EDITABLE

  //STIMULIS EDITABLE
  const handleRowAddStimulis = (newData, resolve) => {
    //validation
    let errorList = [];
    newData.speechTherapistID = userConnected.id;
    if (newData.name === undefined) {
      errorList.push("Please enter a name");
    }
    if (errorList.length < 1) {
      //no error
      API.post("/Stimulis/", newData)
        .then((res) => {
          let dataToAdd = [...data];
          dataToAdd.push(newData);
          setData(dataToAdd);
          resolve();
          setErrorMessages([]);
          setIserror(false);
          refreshPage();
        })
        .catch((error) => {
          setErrorMessages(["Cannot add data. Server error!"]);
          setIserror(true);
          resolve();
        });
    } else {
      setErrorMessages(errorList);
      setIserror(true);
      resolve();
    }
  };


  const handleRowUpdateStimulis = (newData, oldData, resolve) => {
    //validation
    let errorList = [];
    if (newData.name === "") {
      errorList.push("Please enter a name");
    }

    if (errorList.length < 1) {
      API.put("/Stimulis/" + newData.id, newData)
        .then((res) => {
          const dataUpdate = [...data];
          const index = oldData.tableData.id;
          dataUpdate[index] = newData;
          setData([...dataUpdate]);
          resolve();
          setIserror(false);
          setErrorMessages([]);
          refreshPage();
        })
        .catch((error) => {
          setErrorMessages(["Update failed! Server error"]);
          setIserror(true);
          resolve();
        });
    } else {
      setErrorMessages(errorList);
      setIserror(true);
      resolve();
    }
  };

  const handleRowDeleteStimulis = (oldData, resolve) => {
    API.delete("/Stimulis/" + oldData.id)
      .then((res) => {
        const dataDelete = [...data];
        const index = oldData.tableData.id;
        dataDelete.splice(index, 1);
        setData([...dataDelete]);
        resolve();
        refreshPage();
      })
      .catch((error) => {
        setErrorMessages(["Delete failed! Server error"]);
        setIserror(true);
        resolve();
      });
  };
    //END STIMULIS EDITABLE

    //RESPONSES EDITABLE
    const handleRowAddResponses = (newData, resolve) => {
        //validation
        let errorList = [];
        newData.speechTherapistID = userConnected.id;
        if (newData.name === undefined) {
          errorList.push("Please enter a choice");
        }
        if (errorList.length < 1) {
          //no error
          API.post("/Responses/", newData)
            .then((res) => {
              let dataToAdd = [...data];
              dataToAdd.push(newData);
              setData(dataToAdd);
              resolve();
              setErrorMessages([]);
              setIserror(false);
              refreshPage();
            })
            .catch((error) => {
              setErrorMessages(["Cannot add data. Server error!"]);
              setIserror(true);
              resolve();
            });
        } else {
          setErrorMessages(errorList);
          setIserror(true);
          resolve();
        }
      };
    
    
      const handleRowUpdateResponses = (newData, oldData, resolve) => {
        //validation
        let errorList = [];
        if (newData.name === "") {
          errorList.push("Please enter a name");
        }
    
        if (errorList.length < 1) {
          API.put("/Responses/" + newData.id, newData)
            .then((res) => {
              const dataUpdate = [...data];
              const index = oldData.tableData.id;
              dataUpdate[index] = newData;
              setData([...dataUpdate]);
              resolve();
              setIserror(false);
              setErrorMessages([]);
              refreshPage();
            })
            .catch((error) => {
              setErrorMessages(["Update failed! Server error"]);
              setIserror(true);
              resolve();
            });
        } else {
          setErrorMessages(errorList);
          setIserror(true);
          resolve();
        }
      };
    
      const handleRowDeleteResponsess = (oldData, resolve) => {
        API.delete("/Responses/" + oldData.id)
          .then((res) => {
            const dataDelete = [...data];
            const index = oldData.tableData.id;
            dataDelete.splice(index, 1);
            setData([...dataDelete]);
            resolve();
            refreshPage();
          })
          .catch((error) => {
            setErrorMessages(["Delete failed! Server error"]);
            setIserror(true);
            resolve();
          });
      };

      //END RESPONSES EDITABLE
  function refreshPage() {
    window.location.reload(false);
  }

  return (
    <div className="App">
      <div>
        {iserror && (
          <Alert severity="error">
            {errorMessages.map((msg, i) => {
              return <div key={i}>{msg}</div>;
            })}
          </Alert>
        )}
      </div>
      <MaterialTable
              options={{
                pageSize: 5,
                pageSizeOptions: [5, 10, 20, 30, 50, 75, 100],
                toolbar: true,
                paging: true,
              }}
       
            //icons={tableIcons}
            title={'Tâches'}
            columns={columns}
            data={data}
            editable={{
                onRowUpdate: (newData, oldData) =>
                  new Promise((resolve) => {
                    handleRowUpdate(newData, oldData, resolve);
                  }),
                onRowAdd: (newData) =>
                  new Promise((resolve) => {
                    handleRowAdd(newData, resolve);
                  }),
                onRowDelete: (oldData) =>
                  new Promise((resolve) => {
                    handleRowDelete(oldData, resolve);
                  }),
              }}
            detailPanel={(rowData) => {
              return (
                rowData.stimulis && (
                  <div
                    style={{
                      background: 'grey',
                     padding: '10px 0px 10px 20px',
                    }}
                  >
                    {/* Stimulis Table */}
                    <MaterialTable
                                  options={{
                                    pageSize: 3,
                                    pageSizeOptions: [5, 10, 20, 30, 50, 75, 100],
                                    toolbar: true,
                                    paging: true,
                                  }}
                      //icons={tableIcons}
                      title={'Stimulis'}
                              columns={columnsStimulis}
                      data={rowData.stimulis}
                      editable={{
                        onRowUpdate: (newData, oldData) =>
                          new Promise((resolve) => {
                            handleRowUpdateStimulis(newData, oldData, resolve);
                          }),
                        onRowAdd: (newData) =>
                          new Promise((resolve) => {
                            handleRowAddStimulis(newData, resolve);
                          }),
                        onRowDelete: (oldData) =>
                          new Promise((resolve) => {
                            handleRowDeleteStimulis(oldData, resolve);
                          }),
                      }}
                      detailPanel={(rowData) => {
                        return (
                          rowData.responses && (
                            <div
                              style={{
                                background: 'rgb(240, 91, 86)',
                               padding: '10px px 10px 20px',
                              }}
                            >
                              {/* Responses Table */}
                              <MaterialTable
                                            options={{
                                                pageSize: 2,
                                                pageSizeOptions: [5, 10, 20, 30, 50, 75, 100],
                                                toolbar: true,
                                                paging: true,
                                              }}
                              //  icons={tableIcons}
                                title={'Responses'}
                                columns={columnsResponses}
                                data={rowData.responses}
                                editable={{
                                    onRowUpdate: (newData, oldData) =>
                                      new Promise((resolve) => {
                                        handleRowUpdateResponses(newData, oldData, resolve);
                                      }),
                                    onRowAdd: (newData) =>
                                      new Promise((resolve) => {
                                        handleRowAddResponses(newData, resolve);
                                      }),
                                    onRowDelete: (oldData) =>
                                      new Promise((resolve) => {
                                        handleRowDeleteResponsess(oldData, resolve);
                                      }),
                                  }}
                              />
                            </div>
                          )
                        );
                      }}
                    />
                  </div>
                )
              );
            }}
          />
    </div>
  );
}
