// Programmer Name :Mr.Lau Kah Hou, UC3F2005SE
// Program Name :Screens.js
// Description :To manage the screen navigation of the application
// First Written on :Saturday, 14-November-2020
// Edited on :Friday, 4-December-2020

import React from "react";
import { Dimensions } from "react-native";

import { createStackNavigator } from "@react-navigation/stack";
import { createDrawerNavigator } from "@react-navigation/drawer";
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";

// screens
import Onboarding from "../screens/Onboarding";
import HomeFoodDistributor from "../screens/HomeFoodDistributor";
import HomeFoodProvider from "../screens/HomeFoodProvider";
import LoginFoodDistributor from "../screens/LoginFoodDistributor";
import SignUpFoodDistributor from "../screens/SignUpFoodDistributor";
import LoginFoodProvider from "../screens/LoginFoodProvider";
import SignUpFoodProvider from "../screens/SignUpFoodProvider";
import ForgotPassword from "../screens/ForgotPassword";
import NewFoodDonation from "../screens/NewFoodDonation";
import FoodDonationHistory from "../screens/FoodDonationHistory";
import PendingRequest from "../screens/PendingRequest";
import ActiveRequest from "../screens/ActiveRequest";
import CompletedRequest from "../screens/CompletedRequest";
//import Profile from "../screens/Profile";
//import Elements from "../screens/Elements";
//import Articles from "../screens/Articles";

// drawer
import CustomDrawerContent from "./Menu";

// header for screens
import { Header } from "../components";
import useStatusBar from '../hooks/useStatusBar';
import { logout } from '../components/Firebase/firebase';

// // expo
// import { Notifications } from 'expo';
// import * as Permissions from 'expo-permissions';
// import expoPushTokensApi from '../api/expoPushTokens';

const { width } = Dimensions.get("screen");

const Stack = createStackNavigator();
const Drawer = createDrawerNavigator();
const Tab = createBottomTabNavigator();

// const useNotifications = (notificationListener) => {
//   useEffect(() => {
//     registerForPushNotifications();

//     if (notificationListener) Notifications.addListener(notificationListener);
//   }, []);
// }


// const registerForPushNotifications = async () => { 
//   try {
//     const permission = await Permissions.askAsync(Permissions.NOTIFICATIONS);
//     if (!permission.granted) return;

//     const token = await Notifications.getExpoPushTokenAsync();
//     expoPushTokensApi.register(token)
//   } 
//   catch (error) {
//     console.log('Error getting a token', error);
//   }
// }

async function handleSignOut() {
  try {
    useStatusBar('dark-content');
    console.log("going to log out");
    await logout();
  } catch (error) {
    console.log(error);
  }
}

// function ElementsStack(props) {
//   return (
//     <Stack.Navigator mode="card" headerMode="screen">
//       <Stack.Screen
//         name="Elements"
//         component={Elements}
//         options={{
//           header: ({ navigation, scene }) => (
//             <Header title="Elements" navigation={navigation} scene={scene} />
//           ),
//           cardStyle: { backgroundColor: "#F8F9FE" }
//         }}
//       />
//       <Stack.Screen
//         name="Pro"
//         component={Pro}
//         options={{
//           header: ({ navigation, scene }) => (
//             <Header
//               title=""
//               back
//               white
//               transparent
//               navigation={navigation}
//               scene={scene}
//             />
//           ),
//           headerTransparent: true
//         }}
//       />
//     </Stack.Navigator>
//   );
// }

// function ArticlesStack(props) {
//   return (
//     <Stack.Navigator mode="card" headerMode="screen">
//       <Stack.Screen
//         name="Articles"
//         component={Articles}
//         options={{
//           header: ({ navigation, scene }) => (
//             <Header title="Articles" navigation={navigation} scene={scene} />
//           ),
//           cardStyle: { backgroundColor: "#F8F9FE" }
//         }}
//       />
//             <Stack.Screen
//         name="Pro"
//         component={Pro}
//         options={{
//           header: ({ navigation, scene }) => (
//             <Header
//               title=""
              
//               white
//               transparent
//               navigation={navigation}
//               scene={scene}
//             />
//           ),
//           headerTransparent: true
//         }}
//       />
//     </Stack.Navigator>
//   );
// }

// function ProfileStack(props) {
//   return (
//     <Stack.Navigator initialRouteName="Profile" mode="card" headerMode="screen">
//       <Stack.Screen
//         name="Profile"
//         component={Profile}
//         options={{
//           header: ({ navigation, scene }) => (
//             <Header
//               transparent
//               white
//               title="Profile"
//               navigation={navigation}
//               scene={scene}
//             />
//           ),
//           cardStyle: { backgroundColor: "#FFFFFF" },
//           headerTransparent: true
//         }}
//       />
//             <Stack.Screen
//         name="Pro"
//         component={Pro}
//         options={{
//           header: ({ navigation, scene }) => (
//             <Header
//               title=""
//               back
//               white
//               transparent
//               navigation={navigation}
//               scene={scene}
//             />
//           ),
//           headerTransparent: true
//         }}
//       />
//     </Stack.Navigator>
//   );
// }

function HomeFoodDistributorStack(props) {
  return (
    <Stack.Navigator mode="card" headerMode="screen">
      <Stack.Screen
        name="HomeFoodDistributor"
        component={HomeFoodDistributor}
        options={{
          header: ({ navigation, scene }) => (
            <Header
              title="Welcome back!"
              //search
              //options
              navigation={navigation}
              scene={scene}
            />
          ),
          cardStyle: { backgroundColor: "#F8F9FE" }
        }}
      />
      </Stack.Navigator>
  );
}

function HomeFoodProviderStack(props) {
  return (
    <Stack.Navigator mode="card" headerMode="screen">
      <Stack.Screen
        name="HomeFoodProvider"
        component={HomeFoodProvider}
        options={{
          header: ({ navigation, scene }) => (
            <Header
              title="Welcome back!" 
              navigation={navigation}
              scene={scene}
            />
          ),
          cardStyle: { backgroundColor: "#F8F9FE" }
        }}
      />
    </Stack.Navigator>
  );
}

function LoginFoodDistributorStack(props) {
  return (
    <Stack.Navigator mode="card" headerMode="screen">
      <Stack.Screen
        name="LoginFoodDistributor"
        component={LoginFoodDistributor}
        options={{
          header: ({ navigation, scene }) => (
            <Header
              title="Login as Food Distributor"
              back
              white
              transparent
              navigation={navigation}
              scene={scene}
            />
          ),
          headerTransparent: true
        }}
      />
      <Stack.Screen
        name="ForgotPassword"
        component={ForgotPassword}
        options={{
          header: ({ navigation, scene }) => (
            <Header
              title="Forgot Password"
              back
              white
              transparent
              navigation={navigation}
              scene={scene}
            />
          ),
          headerTransparent: true
        }}
      />
      <Stack.Screen
        name="SignUpFoodDistributor"
        component={SignUpFoodDistributor}
        options={{
          header: ({ navigation, scene }) => (
            <Header
              title="Sign up as Food Distributor"
              back
              white
              transparent
              navigation={navigation}
              scene={scene}
            />
          ),
          headerTransparent: true
        }}
      />
    </Stack.Navigator>
  );
}

function LoginFoodProviderStack(props) {
  return (
    <Stack.Navigator mode="card" headerMode="screen">
      <Stack.Screen
        name="LoginFoodProvider"
        component={LoginFoodProvider}
        options={{
          header: ({ navigation, scene }) => (
            <Header
              title="Login as Food Provider"
              back
              white
              transparent
              navigation={navigation}
              scene={scene}
            />
          ),
          headerTransparent: true
        }}
      />
      <Stack.Screen
        name="ForgotPassword"
        component={ForgotPassword}
        options={{
          header: ({ navigation, scene }) => (
            <Header
              title="Forgot Password"
              back
              white
              transparent
              navigation={navigation}
              scene={scene}
            />
          ),
          headerTransparent: true
        }}
      />
      <Stack.Screen
        name="SignUpFoodProvider"
        component={SignUpFoodProvider}
        options={{
          header: ({ navigation, scene }) => (
            <Header
              title="Sign up as Food Provider"
              back
              white
              transparent
              navigation={navigation}
              scene={scene}
            />
          ),
          headerTransparent: true
        }}
      /> 
    </Stack.Navigator>
  );
}

function NewFoodDonationStack(props) {
  return (
    <Stack.Navigator mode="card" headerMode="screen">
      <Stack.Screen
        name="New Food Donation"
        component={NewFoodDonation}
        options={{
          header: ({ navigation, scene }) => (
            <Header
              title="Add New Food Donation"
              white
              transparent
              navigation={navigation}
              scene={scene}
            />
          ),
          headerTransparent: true
        }}
      />
    </Stack.Navigator>
  );
}

function FoodDonationHistoryStack(props) {
  return (
    <Stack.Navigator mode="card" headerMode="screen">
      <Stack.Screen
        name="Food Donation History"
        component={FoodDonationHistory}
        options={{
          header: ({ navigation, scene }) => (
            <Header
              title="Food Donation History"
              transparent
              navigation={navigation}
              scene={scene}
            />
          ),
          headerTransparent: true
        }}
      />
    </Stack.Navigator>
  );
}

function PendingRequestStack(props) {
  return (
    <Stack.Navigator mode="card" headerMode="screen">
      <Stack.Screen
        name="Pending Request"
        component={PendingRequest}
        options={{
          header: ({ navigation, scene }) => (
            <Header
              title="Pending Request List"
              transparent
              navigation={navigation}
              scene={scene}
            />
          ),
          headerTransparent: true
        }}
      />
    </Stack.Navigator>
  );
}

function ActiveRequestStack(props) {
  return (
    <Stack.Navigator mode="card" headerMode="screen">
      <Stack.Screen
        name="Active Request"
        component={ActiveRequest}
        options={{
          header: ({ navigation, scene }) => (
            <Header
              title="Active Request List"
              transparent
              navigation={navigation}
              scene={scene}
            />
          ),
          headerTransparent: true
        }}
      />
    </Stack.Navigator>
  );
}

function CompletedRequestStack(props) {
  return (
    <Stack.Navigator mode="card" headerMode="screen">
      <Stack.Screen
        name="Completed Request"
        component={CompletedRequest}
        options={{
          header: ({ navigation, scene }) => (
            <Header
              title="Completed Request List"
              transparent
              navigation={navigation}
              scene={scene}
            />
          ),
          headerTransparent: true
        }}
      />
    </Stack.Navigator>
  );
}

export default function OnboardingStack(props) {
  return (
    <Stack.Navigator mode="card" headerMode="none">
      <Stack.Screen
        name="Onboarding"
        component={Onboarding}
        option={{
          headerTransparent: true
        }}
      />
      <Stack.Screen name="LoginFoodDistributor" component={LoginFoodDistributorStack}/>
      <Stack.Screen name="LoginFoodProvider" component={LoginFoodProviderStack}/>
      <Stack.Screen name="AppFoodDistributor" component={AppFoodDistributorStack} />
      <Stack.Screen name="AppFoodProvider" component={AppFoodProviderStack} />
    </Stack.Navigator>
  );
}

export function AppFoodDistributorStack(props) {
  return (
    <Drawer.Navigator
      style={{ flex: 1 }}
      drawerContent={props => <CustomDrawerContent {...props} />}
      drawerStyle={{
        backgroundColor: "white",
        width: width * 0.8
      }}
      drawerContentOptions={{
        activeTintcolor: "white",
        inactiveTintColor: "#000",
        activeBackgroundColor: "transparent",
        itemStyle: {
          width: width * 0.75,
          backgroundColor: "transparent",
          paddingVertical: 16,
          paddingHorizonal: 12,
          justifyContent: "center",
          alignContent: "center",
          alignItems: "center",
          overflow: "hidden"
        },
        labelStyle: {
          fontSize: 18,
          marginLeft: 12,
          fontWeight: "normal"
        }
      }}
      initialRouteName="Home"
    >
      <Drawer.Screen name="Home" component={HomeFoodDistributorStack} />
      <Drawer.Screen name="Pending Request" component={PendingRequestStack} />
      <Drawer.Screen name="Active Request" component={ActiveRequestStack} />
      <Drawer.Screen name="Completed Request" component={CompletedRequestStack} />
      <Drawer.Screen name="Log Out" onPress={() => handleSignOut()} component={OnboardingStack} />
    </Drawer.Navigator>
  );
}

export function AppFoodProviderStack(props) {
  return (
    <Drawer.Navigator
      style={{ flex: 1 }}
      drawerContent={props => <CustomDrawerContent {...props} />}
      drawerStyle={{
        backgroundColor: "white",
        width: width * 0.8
      }}
      drawerContentOptions={{
        activeTintcolor: "white",
        inactiveTintColor: "#000",
        activeBackgroundColor: "transparent",
        itemStyle: {
          width: width * 0.75,
          backgroundColor: "transparent",
          paddingVertical: 16,
          paddingHorizonal: 12,
          justifyContent: "center",
          alignContent: "center",
          alignItems: "center",
          overflow: "hidden"
        },
        labelStyle: {
          fontSize: 18,
          marginLeft: 12,
          fontWeight: "normal"
        }
      }}
      initialRouteName="Home"
    >
      <Drawer.Screen name="Home" component={HomeFoodProviderStack} />
      <Drawer.Screen name="New Food Donation" component={NewFoodDonationStack} />
      <Drawer.Screen name="Food Donation History" component={FoodDonationHistoryStack} />
      <Drawer.Screen name="Log Out" onPress={() => handleSignOut()} component={OnboardingStack} />
    </Drawer.Navigator>
  );
}

