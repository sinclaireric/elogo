import { StatusBar } from "expo-status-bar";
import React from "react";
import { SafeAreaProvider } from "react-native-safe-area-context";

import useCachedResources from "./hooks/useCachedResources";
import useColorScheme from "./hooks/useColorScheme";
import Navigation from "./navigation";
import axios from "axios";
import { AsyncStorage } from "react-native";

export default function App() {
  const isLoadingComplete = useCachedResources();
  const colorScheme = useColorScheme();
  const [isLoggedIn, setIsLoggedIn] = React.useState(false);

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
        //add token res.data dans local storage
        //AsyncStorage.setItem('')
      })
      .catch((err) => {
        console.log("handleSubmit -> err3", err);
      });
  };
  if (!isLoadingComplete) {
    return null;
  } else {
    return (
      <SafeAreaProvider>
        <Navigation
          isLoggedIn={isLoggedIn}
          login={login}
          colorScheme={colorScheme}
        />
        <StatusBar />
      </SafeAreaProvider>
    );
  }
}
