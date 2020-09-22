import {
  NavigationContainer,
  DefaultTheme,
  DarkTheme,
} from "@react-navigation/native";
import { createStackNavigator } from "@react-navigation/stack";
import * as React from "react";
import { ColorSchemeName } from "react-native";

import NotFoundScreen from "../screens/NotFoundScreen";
import { RootStackParamList } from "../types";
import LinkingConfiguration from "./LinkingConfiguration";
import Login from "../screens/LoginScreen";
import PatientsList from "../screens/PatientsListScreen";

// If you are not familiar with React Navigation, we recommend going through the
// "Fundamentals" guide: https://reactnavigation.org/docs/getting-started
type Props = {
  colorScheme: ColorSchemeName;
  isLoggedIn: boolean;
  login: (email: string, password: string) => void;
  error: any;
};

export default function Navigation({
  colorScheme,
  isLoggedIn,
  login,
  error,
}: Props) {
  return (
    <NavigationContainer
      linking={LinkingConfiguration}
      theme={colorScheme === "dark" ? DarkTheme : DefaultTheme}
    >
      <RootNavigator login={login} error={error} isLoggedIn={isLoggedIn} />
    </NavigationContainer>
  );
}

// A root stack navigator is often used for displaying modals on top of all other content
// Read more here: https://reactnavigation.org/docs/modal
const Stack = createStackNavigator<RootStackParamList>();

function RootNavigator({
  isLoggedIn,
  login,
  error,
}: {
  isLoggedIn: boolean;
  login: (email: string, password: string) => void;
  error: any;
}) {
  return (
    <Stack.Navigator screenOptions={{ headerShown: false }}>
      {isLoggedIn ? (
        <Stack.Screen name="PatientsList" component={PatientsList} />
      ) : (
        <Stack.Screen name="Login">
          {(props) => <Login {...props} error={error} login={login} />}
        </Stack.Screen>
      )}
      <Stack.Screen
        name="NotFound"
        component={NotFoundScreen}
        options={{ title: "Oops!" }}
      />
    </Stack.Navigator>
  );
}
