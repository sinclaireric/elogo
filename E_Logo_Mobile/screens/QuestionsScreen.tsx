import React, { useEffect } from "react";
import {
  StyleSheet,
  View,
  FlatList,
  ActivityIndicator,
  Text,
  TextInput,
  TouchableOpacity,
  Modal,
  TouchableHighlight,
  Alert,
} from "react-native";
import axios from "axios";
import AsyncStorage from "@react-native-async-storage/async-storage";
import filter from "lodash.filter";

import { useNavigation } from "@react-navigation/native";

export default function QuestionsScreen() {
  const navigation = useNavigation();

  const [DATA, setDATA] = React.useState([
    { id: 1, name: "tache 1: appariemment de lettres" },
    { id: 2, name: "tache 2: lecture de mots" },
    { id: 3, name: "tache 3: denomination des objets" },
  ]);
  const [isLoading, setIsLoading] = React.useState(false);
  const [error, setError] = React.useState(null);
  const [selectedId, setSelectedId] = React.useState(null);
  const [modalVisible, setModalVisible] = React.useState(false);
  const [selectedPatient, setSelectedPatient] = React.useState<any[any]>();

  const navigateByTask = (id: number) => {
    if (id === 1) {
      return navigation.navigate("TacheOne");
    } else if (id === 2) {
      return navigation.navigate("TacheTwo");
    } else {
      return navigation.navigate("TacheThree");
    }
  };

  /* useEffect(() => {
    async function getData() {
      //const selectedPatientID = await readData("SelectedPatientID");
      await axios
        .get(`http://localhost:5000/api/Tasks/`)
        .then((res) => {
          // const data = JSON.stringify(res.data); stringify or not
          setDATA(res.data);
          setIsLoading(false);
        })
        .catch((err) => {
          setIsLoading(false);
          setError(err);
        });
    }

    getData();
  }, []);  */

  //Lis des données dans le storage gâce à la key passée.
  const readData = async (key: string) => {
    try {
      const storeData = await AsyncStorage.getItem(key);
      return storeData;
    } catch (e) {
      alert("Failed to fetch the data from storage");
    }
  };

  const Item = ({
    item,
    onPress,
    style,
  }: {
    item: any;
    onPress: any;
    style: any;
  }) => (
    <TouchableOpacity onPress={onPress} style={[styles.item, style]}>
      <Text style={styles.title}>{`${item.name}`}</Text>
    </TouchableOpacity>
  );

  const renderItem = ({ item }: { item: any }) => {
    const backgroundColor = item.id === selectedId ? "grey" : "#fff";

    return (
      <Item
        item={item}
        onPress={() => {
          setSelectedPatient(item);
          setSelectedId(item.id);
          setModalVisible(true);
          navigateByTask(item.id);
        }}
        style={{ backgroundColor }}
      />
    );
  };

  function renderHeader() {
    return (
      <View
        style={{
          backgroundColor: "#fff",
          padding: 10,
          marginVertical: 10,
          borderRadius: 20,
        }}
      ></View>
    );
  }
  if (isLoading) {
    return (
      <View
        style={[
          styles.container,
          { flex: 1, justifyContent: "center", alignItems: "center" },
        ]}
      >
        <ActivityIndicator size="large" color="#5500dc" />
      </View>
    );
  }

  if (error) {
    console.log(error);
    return (
      <View
        style={[
          styles.container,
          { flex: 1, justifyContent: "center", alignItems: "center" },
        ]}
      >
        <Text style={{ fontSize: 18 }}>hello</Text>
      </View>
    );
  }
  return (
    <View style={styles.container}>
      <Text style={styles.text}>Questions !!!!!!</Text>
      {selectedPatient !== undefined ? (
        <Modal
          animationType="slide"
          transparent={true}
          visible={modalVisible}
          onRequestClose={() => {
            Alert.alert("Modal has been closed.");
          }}
        >
          <View style={styles.centeredView}>
            <View style={styles.modalView}>
              <Text style={styles.modalText}>
                Commencer le test de
                {selectedPatient.fullname}{" "}
              </Text>
              <View style={styles.modalButton}>
                <TouchableHighlight
                  style={{
                    ...styles.openButton,
                    backgroundColor: "#rgb(240, 91, 86)",
                  }}
                  onPress={() => {
                    setModalVisible(!modalVisible);
                  }}
                >
                  <Text style={styles.textStyle}>Non</Text>
                </TouchableHighlight>
                <Text> </Text>

                <TouchableHighlight
                  style={{
                    ...styles.openButton,
                    backgroundColor: "#rgb(240, 91, 86)",
                  }}
                  onPress={() => {
                    //  navigation.navigate('Profile', { name: 'Jane' })
                    setModalVisible(!modalVisible);
                    //navigateByTask(DATA.id);
                  }}
                >
                  <Text style={styles.textStyle}>Oui</Text>
                </TouchableHighlight>
              </View>
            </View>
          </View>
        </Modal>
      ) : (
        <></>
      )}
      <FlatList
        ListHeaderComponent={renderHeader}
        data={DATA}
        keyExtractor={(item) => item.id.toString()}
        renderItem={renderItem}
        extraData={selectedId}
      />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
    backgroundColor: "#rgb(240, 91, 86)",
  },
  text: {
    fontSize: 20,
    color: "#101010",
    marginTop: 60,
    fontWeight: "700",
  },
  item: {
    borderRadius: 20,
    padding: 8,
    marginVertical: 8,
    marginHorizontal: 16,
  },
  listItem: {
    marginTop: 10,
    paddingVertical: 20,
    paddingHorizontal: 20,
    backgroundColor: "#fff",
    flexDirection: "row",
  },
  coverImage: {
    width: 100,
    height: 100,
    borderRadius: 8,
  },
  metaInfo: {
    marginLeft: 10,
  },
  title: {
    fontSize: 18,
    width: 200,
    padding: 10,
  },
  centeredView: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
    marginTop: 22,
  },
  modalView: {
    margin: 20,
    backgroundColor: "white",
    borderRadius: 20,
    padding: 35,
    alignItems: "center",
    shadowColor: "#000",
    shadowOffset: {
      width: 0,
      height: 2,
    },
    shadowOpacity: 0.25,
    shadowRadius: 3.84,
    elevation: 5,
  },
  openButton: {
    backgroundColor: "#F194FF",
    borderRadius: 20,
    padding: 10,
    elevation: 2,
  },
  textStyle: {
    color: "white",
    fontWeight: "bold",
    textAlign: "center",
  },
  modalText: {
    marginBottom: 15,
    textAlign: "center",
  },
  modalButton: {
    flexDirection: "row",
  },
});
