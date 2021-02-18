// Programmer Name :Mr.Lau Kah Hou, UC3F2005SE
// Program Name :ForgotPassword.js
// Description :To create the forgot password screen for both food provider and food distributor.
// First Written on :Wednesday, 9-December-2020
// Edited on :Wednesday, 9-December-2020

import React, { useState } from 'react';
import {
  View,
  StyleSheet,
  ImageBackground,
  Dimensions,
  StatusBar,
  KeyboardAvoidingView,
  TouchableOpacity,
  Alert
} from "react-native";

import * as Yup from 'yup';
import { Images, argonTheme } from "../constants";
import { Block, Text } from "galio-framework";
import SafeView from '../components/SafeView';
import Form from '../components/Forms/Form';
import FormField from '../components/Forms/FormField';
import FormButton from '../components/Forms/FormButton';
import { passwordReset } from '../components/Firebase/firebase';
import FormErrorMessage from '../components/Forms/FormErrorMessage';
import useStatusBar from '../hooks/useStatusBar';

const { width, height } = Dimensions.get("screen");

const validationSchema = Yup.object().shape({
  email: Yup.string()
    .label('Email')
    .email('Enter a valid email')
    .required('Please enter a registered email')
});

export default function ForgotPasswordScreen({ navigation }) {
  useStatusBar('light-content');

  const [customError, setCustomError] = useState('');

  async function handlePasswordReset(values) {
    const { email } = values;

    try {
      await passwordReset(email);
      Alert.alert(
        'Message',
        'Password Reset Successful! Please check your email.', 
        [
          {
            text: 'OK',
            onPress: () => navigation.goBack()
          }
        ]
      )
    } catch (error) {
      setCustomError(error.message);
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
                  Food Hero Food Distributor Login
                </Text>
              </Block>
              <Block flex center>
                <KeyboardAvoidingView
                    style={{ flex: 1 }}
                    behavior="padding"
                    enabled
                >
                  <Form
                    initialValues={{ email: '' }}
                    validationSchema={validationSchema}
                    onSubmit={values => handlePasswordReset(values)}
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
                      <Block middle>
                        <FormButton title="Forgot Password" />
                        {<FormErrorMessage error={customError} visible={true} />}
                      </Block>
                    </Form>
                  </KeyboardAvoidingView>
                  <View style={{flexDirection: 'row', justifyContent: 'center', alignItems: 'center'}}>
                    <Text style = {styles.signUpText}> Do not have an account?</Text>
                  </View>
                  <TouchableOpacity 
                    onPress={() => navigation.navigate('SignUpFoodDistributor')}
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
  signUpText: {
    flexGrow: 1,
    alignItems: 'center',
    justifyContent: 'flex-end',
    paddingVertical: 5,
    paddingLeft: 100,
    flexDirection: 'row'
  }
});
