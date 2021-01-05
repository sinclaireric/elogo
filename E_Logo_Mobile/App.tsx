import { StatusBar } from "expo-status-bar";
import React from "react";
import { SafeAreaProvider } from "react-native-safe-area-context";

import useCachedResources from "./hooks/useCachedResources";
import useColorScheme from "./hooks/useColorScheme";
import Navigation from "./navigation";
import axios from "axios";
import AsyncStorage from "@react-native-community/async-storage";
import "react-native-gesture-handler";
import { NavigationContainer } from "@react-navigation/native";

export default function App() {
  const isLoadingComplete = useCachedResources();
  const colorScheme = useColorScheme();
  const [isLoggedIn, setIsLoggedIn] = React.useState(false);
  const [error, setError] = React.useState();

  const login = (email: string, password: string) => {
    axios({
      method: "POST",
      url: "http://localhost:5000/api/SpeechTherapists/authenticate",
      data: { email, password },
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((res) => {
        setIsLoggedIn(true);
        saveStorage("CurrentUserID", JSON.stringify(res.data.id));
      })
      .catch((err) => {
        if (err.response && err.response.data) setError(err.response.data);
        else setError(err);
      });
  };

  //Save dans le storage item doit être string!!!
  const saveStorage = async (key: string, item: string) => {
    try {
      var dataSaved = await AsyncStorage.setItem(key, item);
      return dataSaved;
    } catch (error) {
      console.log(error.message);
    }
  };

  if (!isLoadingComplete) {
    return null;
  } else {
    return (
      // <NavigationContainer>
      <SafeAreaProvider>
        <Navigation
          isLoggedIn={isLoggedIn}
          login={login}
          colorScheme={colorScheme}
          error={error}
        />
        <StatusBar />
      </SafeAreaProvider>
      // </NavigationContainer>
    );
  }
}
