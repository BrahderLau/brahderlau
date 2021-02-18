

import React from "react";
import {
  ImageBackground,
  Image,
  StyleSheet,
  StatusBar,
  Dimensions
} from "react-native";
import { Block, Button, Text, theme } from "galio-framework";

const { height, width } = Dimensions.get("screen");

import argonTheme from "../constants/Theme";
import Images from "../constants/Images";

class Onboarding extends React.Component {
  render() {
    const { navigation } = this.props;

    return (
      <Block flex style={styles.container}>
        <StatusBar hidden />
        <Block flex center>
          <ImageBackground
            source={Images.Onboarding}
            style={{ height, width, zIndex: 1 }}
          />
        </Block>
        <Block flex space="between" style={styles.padded}>
            <Block flex space="around" style={{ zIndex: 2 }}>
              <Block style={styles.title}>
                <Block>
                  <Text color="black" size={60}>
                    FOOD
                  </Text>
                </Block>
                <Block>
                  <Text color="black" size={60}>
                    HERO
                  </Text>
                </Block>
                <Block style={styles.subTitle}>
                  <Text color="black" size={16}>
                    Modernized Way of Food Sharing Platform.
                  </Text>
                </Block>
              </Block>
              <Block center>
                <Button
                  style={styles.button}
                  color={argonTheme.COLORS.PRIMARY}
                  onPress={() => navigation.navigate("LoginFoodDistributor")}
                  textStyle={{ color: argonTheme.COLORS.WHITE }}
                >
                  Join us as Food Distributor!
                </Button>
                <Button
                  style={styles.button}
                  color={argonTheme.COLORS.PRIMARY}
                  onPress={() => navigation.navigate("LoginFoodProvider")}
                  textStyle={{ color: argonTheme.COLORS.WHITE }}
                >
                  Join us as Food Provider!
                </Button>
              </Block>
          </Block>
        </Block>
      </Block>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    backgroundColor: theme.COLORS.BLACK
  },
  padded: {
    paddingHorizontal: theme.SIZES.BASE * 2,
    position: "relative",
    bottom: theme.SIZES.BASE,
    zIndex: 2,
  },
  button: {
    width: width - theme.SIZES.BASE * 4,
    height: theme.SIZES.BASE * 3,
    shadowRadius: 0,
    shadowOpacity: 0
  },
  logo: {
    width: 200,
    height: 60,
    zIndex: 2,
    position: 'relative',
    marginTop: '-50%'
  },
  title: {
    marginTop:'-5%'
  },
  subTitle: {
    marginTop: 20
  }
});

export default Onboarding;
