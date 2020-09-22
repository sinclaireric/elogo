import React, { useEffect } from "react";
import {
  StyleSheet,
  View,
  FlatList,
  ActivityIndicator,
  Text,
  TextInput,
} from "react-native";
import axios from "axios";
import AsyncStorage from "@react-native-community/async-storage";
import filter from "lodash.filter";

export default function PatientsListScreen() {
  const [DATA, setDATA] = React.useState<any[]>();
  const [isLoading, setIsLoading] = React.useState(false);
  const [error, setError] = React.useState(null);
  const [query, setQuery] = React.useState("");
  const [fullData, setFullData] = React.useState([]);

  useEffect(() => {
    async function getData() {
      const userID = await readData("CurrentUserID");
      await axios
        .get(`http://localhost:5000/api/Patients/getallpatients/${userID}`)
        .then((res) => {
          // const data = JSON.stringify(res.data); stringify or not
          setDATA(res.data);
          setFullData(res.data);
          setIsLoading(false);
        })
        .catch((err) => {
          setIsLoading(false);
          setError(err);
        });
    }

    getData();
  }, []);

  if (isLoading) {
    return (
      <View style={{ flex: 1, justifyContent: "center", alignItems: "center" }}>
        <ActivityIndicator size="large" color="#5500dc" />
      </View>
    );
  }

  if (error) {
    return (
      <View style={{ flex: 1, justifyContent: "center", alignItems: "center" }}>
        <Text style={{ fontSize: 18 }}>
          Error fetching data... Check your network connection!
        </Text>
      </View>
    );
  }

  //Lis des données dans le storage gâce à la key passée.
  const readData = async (key: string) => {
    try {
      const storeData = await AsyncStorage.getItem(key);
      return storeData;
    } catch (e) {
      alert("Failed to fetch the data from storage");
    }
  };

  const handleSearch = (text: string) => {
    const formattedQuery = text.toLowerCase();
    const filteredData = filter(fullData, (user) => {
      return contains(user, formattedQuery);
    });
    setDATA(filteredData);
    setQuery(text);
  };

  const contains = (user: any, query: string) => {
    if (user.fullname.includes(query)) {
      return true;
    }

    return false;
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
      >
        <TextInput
          autoCapitalize="none"
          autoCorrect={false}
          clearButtonMode="always"
          value={query}
          onChangeText={(queryText) => handleSearch(queryText)}
          placeholder="Search"
          style={{ backgroundColor: "#fff", paddingHorizontal: 20 }}
        />
      </View>
    );
  }

  return (
    <View style={styles.container}>
      <Text style={styles.text}>Patients List</Text>
      <FlatList
        ListHeaderComponent={renderHeader}
        data={DATA}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
          <View style={styles.listItem}>
            <View style={styles.metaInfo}>
              <Text style={styles.title}>{`${item.fullname}`}</Text>
            </View>
          </View>
        )}
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
});
