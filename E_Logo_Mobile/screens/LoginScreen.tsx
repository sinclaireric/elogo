import React, { useEffect } from "react";
import {
  StyleSheet,
  Text,
  View,
  TextInput,
  Button,
  TouchableHighlight,
  Alert,
} from "react-native";
import axios from "axios";

export default function LoginScreen({
  login,
}: {
  login: (email: string, password: string) => void;
}) {
  const [email, setEmail] = React.useState("");
  const [password, setPassword] = React.useState("");

  const handleSubmit = () => {
    login(email, password);
  };

  return (
    <View style={styles.container}>
      <View style={styles.inputContainer}>
        <TextInput
          style={styles.inputs}
          placeholder="Email"
          placeholderTextColor="black"
          keyboardType="email-address"
          underlineColorAndroid="transparent"
          onChangeText={setEmail}
        />
      </View>

      <View style={styles.inputContainer}>
        <TextInput
          style={styles.inputs}
          placeholder="Password"
          placeholderTextColor="black"
          secureTextEntry={true}
          underlineColorAndroid="transparent"
          onChangeText={setPassword}
        />
      </View>

      <TouchableHighlight
        style={[styles.buttonContainer, styles.loginButton]}
        onPress={handleSubmit}
      >
        <Text style={styles.loginText}>Login</Text>
      </TouchableHighlight>
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
  inputContainer: {
    borderBottomColor: "#F5FCFF",
    backgroundColor: "#FFFFFF",
    borderRadius: 30,
    borderBottomWidth: 1,
    width: 250,
    height: 45,
    marginBottom: 20,
    flexDirection: "row",
    alignItems: "center",
  },
  inputs: {
    height: 45,
    marginLeft: 16,
    borderBottomColor: "#FFFFFF",
    flex: 1,
  },
  inputIcon: {
    width: 30,
    height: 30,
    marginLeft: 15,
    justifyContent: "center",
  },
  buttonContainer: {
    height: 45,
    flexDirection: "row",
    justifyContent: "center",
    alignItems: "center",
    marginBottom: 20,
    width: 250,
    borderRadius: 30,
  },
  loginButton: {
    backgroundColor: "black",
  },
  loginText: {
    color: "white",
  },
});
