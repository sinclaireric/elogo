import React, { useState } from "react";
import { StyleSheet, Text, View, TouchableOpacity } from "react-native";
import { useNavigation } from "@react-navigation/native";

export default function TaskOneScreen() {
  const navigation = useNavigation();

  const [pressedR, setPressedR] = useState(false);
  const [pressedr, setPressedr] = useState(false);
  const [pressedm, setPressedm] = useState(false);

  let BorderColorR = pressedR ? "blue" : "transparent";
  let BorderColor = pressedr ? "blue" : "transparent";
  let BorderColorm = pressedm ? "blue" : "transparent";

  return (
    <View style={styles.container}>
      <View
        style={{
          position: "absolute",
          top: 150,
          left: 200,
        }}
      >
        <TouchableOpacity
          onPress={() => {
            setPressedR(true);
            //let BorderColor = pressed ? "blue" : "white";
            //console.warn(BorderColor);
          }}
          style={[
            styles.circleShadow,
            { borderColor: BorderColorR, borderWidth: 3, borderStyle: "solid" },
          ]}
        >
          <Text style={{ fontSize: 30, textAlign: "center" }}>R</Text>
        </TouchableOpacity>
      </View>
      <View style={{ position: "absolute", top: 250, left: 50 }}>
        <TouchableOpacity
          onPress={() => {
            setPressedr(true);
            //let BorderColor = pressed ? "blue" : "white";
            //console.warn(BorderColor);
          }}
          style={[
            styles.circleShadow,
            { borderColor: BorderColor, borderWidth: 3, borderStyle: "solid" },
          ]}
        >
          <Text style={{ fontSize: 30, textAlign: "center" }}>r</Text>
        </TouchableOpacity>
      </View>
      <View style={{ position: "absolute", top: 350, left: 250 }}>
        <TouchableOpacity
          onPress={() => {
            setPressedm(true);
            //let BorderColor = pressed ? "blue" : "white";
            //console.warn(BorderColor);
          }}
          style={[
            styles.circleShadow,
            { borderColor: BorderColorm, borderWidth: 3, borderStyle: "solid" },
          ]}
        >
          <Text
            style={{
              fontSize: 30,
              textAlign: "center",
            }}
          >
            m
          </Text>
        </TouchableOpacity>
      </View>
      <View
        style={{
          /* borderColor: "yellow",
          borderWidth: 2,
          borderStyle: "solid", */
          backgroundColor: "blue",
          width: 200,
          position: "absolute",
          bottom: 0,
          marginBottom: 30,
        }}
      >
        <TouchableOpacity
          onPress={() => {
            navigation.navigate("TacheTwo");
          }}
        >
          <Text
            style={{
              fontSize: 20,
              color: "white",
              padding: 8,
              textAlign: "center",
            }}
          >
            Valider
          </Text>
        </TouchableOpacity>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  circleShadow: {
    shadowColor: "#000",
    shadowOffset: {
      width: 0,
      height: 4,
    },
    shadowOpacity: 0.32,
    shadowRadius: 5.46,

    elevation: 9,
    width: 50,
    height: 50,
    borderRadius: 50 / 2,
    backgroundColor: "#f7f7f7",
  },
  container: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
    backgroundColor: "#rgb(240, 91, 86)",
  },
});
