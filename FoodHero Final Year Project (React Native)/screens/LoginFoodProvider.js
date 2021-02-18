// Programmer Name :Mr.Lau Kah Hou, UC3F2005SE
// Program Name :LoginFoodProvider.js
// Description :To create the login screen for Food Provider
// First Written on :Saturday, 14-November-2020
// Edited on :Wednesday, 9-December-2020

import React, { useState } from 'react';
import {
  View,
  StyleSheet,
  ImageBackground,
  Dimensions,
  StatusBar,
  KeyboardAvoidingView
} from "react-native";
import { Block, Text, theme} from "galio-framework";
import { Images, argonTheme } from "../constants";
import { TouchableOpacity } from "react-native-gesture-handler";

import * as Yup from 'yup';
import SafeView from '../components/SafeView';
import Form from '../components/Forms/Form';
import FormField from '../components/Forms/FormField';
import FormButton from '../components/Forms/FormButton';
import { loginWithEmail } from '../components/Firebase/firebase';
import FormErrorMessage from '../components/Forms/FormErrorMessage';
import useStatusBar from '../hooks/useStatusBar';

const { width, height } = Dimensions.get("screen");

const validationSchema = Yup.object().shape({
  email: Yup.string()
    .required('Please enter a registered email')
    .email()
    .label('Email'),
  password: Yup.string()
    .required()
    .min(6, 'Password must have at least 6 characters')
    .label('Password')
});

export default function LoginFoodProvider({ navigation }) {

  useStatusBar('light-content');

  const [passwordVisibility, setPasswordVisibility] = useState(true);
  const [rightIcon, setRightIcon] = useState('eye');
  const [loginError, setLoginError] = useState('');

  function handlePasswordVisibility() {
    if (rightIcon === 'eye') {
      setRightIcon('eye-off');
      setPasswordVisibility(!passwordVisibility);
    } else if (rightIcon === 'eye-off') {
      setRightIcon('eye');
      setPasswordVisibility(!passwordVisibility);
    }
  }


  async function handleOnLogin(values) {
    const { email, password } = values;

    try {
      await loginWithEmail(email, password);
      navigation.navigate("AppFoodProvider", { screen: 'HomeFoodProvider'})
    } catch (error) {
      setLoginError(error.message);
    }
  }
    
  return (
    <SafeView>
    <Block flex middle>
      <StatusBar hidden />
      <ImageBackground
        source={Images.FormBackground}
        style={{ width, height, zIndex: 1 }}
      >
        <Block flex middle>
          <Block style={styles.loginContainer}>
            <Block flex>
              <Block flex={0.17} middle>
                <Text color="#8898AA" size={20}>
                  Food Provider Login Form
                </Text>
              </Block>
              <Block flex center>
                <KeyboardAvoidingView
                    style={{ flex: 1 }}
                    behavior="padding"
                    enabled
                >
                  <Form
                    initialValues={{ email: '', password: '' }}
                    validationSchema={validationSchema}
                    onSubmit={values => handleOnLogin(values)}
                  >
                    <FormField
                      name="email"
                      leftIcon="email"
                      placeholder="Enter email"
                      autoCapitalize="none"
                      keyboardType="email-address"
                      textContentType="emailAddress"
                      autoFocus={true}
                    />
                    <FormField
                      name="password"
                      leftIcon="lock"
                      placeholder="Enter password"
                      autoCapitalize="none"
                      autoCorrect={false}
                      secureTextEntry={passwordVisibility}
                      textContentType="password"
                      rightIcon={rightIcon}
                      handlePasswordVisibility={handlePasswordVisibility}
                    />
                    <Block middle>
                      <FormButton 
                        title={'login'} 
                      />
                      {<FormErrorMessage error={loginError} visible={true} />}
                    </Block>
                    {/* <View style={styles.footerButtonContainer}>
                      <TouchableOpacity onPress={() => navigation.navigate('ForgotPassword')}>
                        <Text bold style={styles.forgotPasswordButtonText}>Forgot Password?</Text>
                      </TouchableOpacity>
                    </View> */}
                  </Form>
                </KeyboardAvoidingView>
                <View style={{flexDirection: 'row', justifyContent: 'center', alignItems: 'center'}}>
                  <Text style = {styles.signUpText}> Do not have an account?</Text>
                </View>
                <TouchableOpacity 
                  onPress={() => navigation.navigate('SignUpFoodProvider')}
                > 
                  <View style={{flexDirection: 'row', justifyContent: 'center', alignItems: 'center', paddingBottom: 10}}>
                      <Text bold> Sign Up </Text>
                  </View>
                </TouchableOpacity>
              </Block>
            </Block>
          </Block>
        </Block>
      </ImageBackground>
    </Block>
    </SafeView>
  );
}

const styles = StyleSheet.create({
  loginContainer: {
    width: width * 0.9,
    height: height * 0.78,
    backgroundColor: "#F4F5F7",
    borderRadius: 4,
    shadowColor: argonTheme.COLORS.BLACK,
    shadowOffset: {
      width: 0,
      height: 4
    },
    shadowRadius: 8,
    shadowOpacity: 0.1,
    elevation: 1,
    overflow: "hidden"
  },
  inputIcons: {
    marginRight: 12
  },
  passwordCheck: {
    paddingLeft: 15,
    paddingTop: 13,
    paddingBottom: 30
  },
  button: {
    width: width - theme.SIZES.BASE * 4,
    height: theme.SIZES.BASE * 3,
    shadowRadius: 0,
    shadowOpacity: 0
  },
  footerButtonContainer: {
    marginVertical: 15,
    justifyContent: 'center',
    alignItems: 'center'
  },
  signUpText: {
    flexGrow: 1,
    alignItems: 'center',
    justifyContent: 'flex-end',
    paddingVertical: 5,
    paddingLeft: 100,
    flexDirection: 'row'
  }
});