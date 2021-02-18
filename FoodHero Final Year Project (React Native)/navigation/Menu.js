// Programmer Name :Mr.Lau Kah Hou, UC3F2005SE
// Program Name :Menu.js
// Description :To create the menu drawer for both Food Distributor and Food Provider
// First Written on :Saturday, 21-November-2020
// Edited on :Friday, 4-December-2020

import React from "react";
import { useSafeArea } from "react-native-safe-area-context";
import {
  ScrollView,
  StyleSheet
} from "react-native";
import { Block, Text, theme } from "galio-framework";

import { DrawerItem as DrawerCustomItem } from '../components';

function CustomDrawerContent({ drawerPosition, navigation, profile, focused, state, ...rest }) {
  const insets = useSafeArea();
  // Choosing drawer based on user type
  const screens = state.routeNames.length===5 ? 
  [ //Drawer for food distributor has 4 pages
    "Home", 
    //"Profile",
    "Pending Request",
    "Active Request",
    "Completed Request",
    "Log Out"
  ] :
  [ //Drawer for food provider has 5 pages
    "Home", 
    //"Profile",
    "New Food Donation",
    "Food Donation History",
    "Log Out"
  ];

  return (
    <Block
      style={styles.container}
      forceInset={{ top: 'always', horizontal: 'never' }}
    >
      <Block flex={0.06} style={styles.header}>
        <Text bold size={24}> Food Hero</Text>
        {/* <Image styles={styles.logo} source={Images.Logo} /> */}
      </Block>
      <Block flex style={{ paddingLeft: 8, paddingRight: 14 }}>
        <ScrollView style={{ flex: 1 }} showsVerticalScrollIndicator={false}>
          {screens.map((item, index) => {
              return (
                <DrawerCustomItem
                  title={item}
                  key={index}
                  navigation={navigation}
                  focused={state.index === index ? true : false}
                />
              );
            })}
            {/* <Block flex style={{ marginTop: 24, marginVertical: 8, paddingHorizontal: 8 }}>
              <Block style={{ borderColor: "rgba(0,0,0,0.2)", width: '100%', borderWidth: StyleSheet.hairlineWidth }}/>
              <Text color="#8898AA" style={{ marginTop: 16, marginLeft: 8 }}>DOCUMENTATION</Text>
            </Block>
            <DrawerCustomItem title="Getting Started" navigation={navigation} /> */}
        </ScrollView>
      </Block>
    </Block>
  );
}


const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  header: {
    paddingHorizontal: 28,
    paddingBottom: theme.SIZES.BASE,
    paddingTop: theme.SIZES.BASE * 3,
    justifyContent: 'center'
  }
});

export default CustomDrawerContent;
