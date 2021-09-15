import React, { useState, useRef, useEffect } from "react";
import { StyleSheet, Text, View, Button, TouchableOpacity } from "react-native";
import { useNavigation } from "@react-navigation/native";

// 3rd party packages
import { Audio } from "expo-av";

let recording = new Audio.Recording();

export default function TaskTwoScreen() {
  const navigation = useNavigation();

  const [RecordedURI, SetRecordedURI] = useState("");
  const [AudioPerm, SetAudioPerm] = useState(false);
  const [isRecording, SetisRecording] = useState(false);
  const [isPLaying, SetisPLaying] = useState(false);
  const Player = useRef(new Audio.Sound());

  useEffect(() => {
    GetPermission();
  }, []);

  const GetPermission = async () => {
    const getAudioPerm = await Audio.requestPermissionsAsync();
    SetAudioPerm(getAudioPerm.granted);
  };

  const startRecording = async () => {
    if (AudioPerm === true) {
      try {
        await recording.prepareToRecordAsync(
          Audio.RECORDING_OPTIONS_PRESET_HIGH_QUALITY
        );
        await recording.startAsync();
        SetisRecording(true);
      } catch (error) {
        console.log(error);
      }
    } else {
      GetPermission();
    }
  };

  const stopRecording = async () => {
    try {
      await recording.stopAndUnloadAsync();
      const result = recording.getURI();
      SetRecordedURI(result); // Here is the URI
      recording = new Audio.Recording();
      SetisRecording(false);
    } catch (error) {
      console.log(error);
    }
  };

  const playSound = async () => {
    try {
      const result = await Player.current.loadAsync(
        { uri: RecordedURI },
        {},
        true
      );
      //console.warn(RecordedURI);

      const response = await Player.current.getStatusAsync();
      if (response.isLoaded) {
        if (response.isPlaying === false) {
          Player.current.playAsync();
          SetisPLaying(true);
        }
      }
    } catch (error) {
      console.log(error);
    }
    console.warn(RecordedURI);
  };

  const stopSound = async () => {
    try {
      const checkLoading = await Player.current.getStatusAsync();
      if (checkLoading.isLoaded === true) {
        await Player.current.stopAsync();
        SetisPLaying(false);
      }
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <View style={styles.container}>
      <View style={{ position: "absolute", top: 150 }}>
        <Text style={{ fontSize: 20, fontWeight: "bold", color: "white" }}>
          Table
        </Text>
      </View>
      <View style={{ marginBottom: 30 }}>
        <Button
          title={isRecording ? "Stop Recording" : "Start Recording"}
          onPress={
            isRecording
              ? () => {
                  stopRecording();
                  console.warn(RecordedURI);
                }
              : () => startRecording()
          }
        />
      </View>
      <View>
        <Button
          title="Play Sound"
          onPress={isPLaying ? () => stopSound : () => playSound()}
        />
        {/* <Text>{RecordedURI}</Text> */}
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
            navigation.navigate("TacheThree");
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
  container: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
    backgroundColor: "#rgb(240, 91, 86)",
  },
});
