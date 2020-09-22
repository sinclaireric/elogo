import React, { useEffect } from "react";
import { StyleSheet, View, FlatList, StatusBar, Text } from "react-native";
import axios from "axios";
import AsyncStorage from "@react-native-community/async-storage";

export default function PatientsListScreen() {
  const [DATA, setDATA] = React.useState<any[]>();

  useEffect(() => {
    async function getData() {
      const userID = await readData("CurrentUserID");
      await axios
        .get(`http://localhost:5000/api/Patients/getallpatients/${userID}`)
        .then((res) => {
          // const data = JSON.stringify(res.data); stringify or not
          setDATA(res.data);
        })
        .catch((err) => {
          console.log("Error Patients list : ", { ...err });
        });
    }

    getData();
  }, []);

  //Lis des données dans le storage gâce à la key passée.
  const readData = async (key: string) => {
    try {
      const storeData = await AsyncStorage.getItem(key);
      return storeData;
    } catch (e) {
      alert("Failed to fetch the data from storage");
    }
  };

  return (
    <View style={styles.container}>
      <FlatList
        data={DATA}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => <Text>{item.fullname + ""}</Text>}
      />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    marginTop: StatusBar.currentHeight || 0,
  },
  item: {
    padding: 20,
    marginVertical: 8,
    marginHorizontal: 16,
  },
  title: {
    fontSize: 32,
  },
});
