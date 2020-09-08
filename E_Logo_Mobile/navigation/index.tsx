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
import BottomTabNavigator from "./BottomTabNavigator";
import LinkingConfiguration from "./LinkingConfiguration";
import Login from "../screens/LoginScreen";

// If you are not familiar with React Navigation, we recommend going through the
// "Fundamentals" guide: https://reactnavigation.org/docs/getting-started
type Props = {
  colorScheme: ColorSchemeName;
  isLoggedIn: boolean;
  login: (email: string, password: string) => void;
};

export default function Navigation({ colorScheme, isLoggedIn, login }: Props) {
  return (
    <NavigationContainer
      linking={LinkingConfiguration}
      theme={colorScheme === "dark" ? DarkTheme : DefaultTheme}
    >
      <RootNavigator login={login} isLoggedIn={isLoggedIn} />
    </NavigationContainer>
  );
}

// A root stack navigator is often used for displaying modals on top of all other content
// Read more here: https://reactnavigation.org/docs/modal
const Stack = createStackNavigator<RootStackParamList>();

function RootNavigator({
  isLoggedIn,
  login,
}: {
  isLoggedIn: boolean;
  login: (email: string, password: string) => void;
}) {
  return (
    <Stack.Navigator screenOptions={{ headerShown: false }}>
      {isLoggedIn ? (
        <Stack.Screen name="Root" component={BottomTabNavigator} />
      ) : (
        <Stack.Screen name="Login">
          {(props) => <Login {...props} login={login} />}
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
