// Programmer Name :Mr.Lau Kah Hou, UC3F2005SE
// Program Name :SignUpFoodProvider.js
// Description :To create the sign up page for food provider
// First Written on :Saturdays, 14-November-2020
// Edited on :Wednesday, 9-December-2020

import React, { useState } from 'react';
import {
  StyleSheet,
  ScrollView,
  ImageBackground,
  Dimensions,
  StatusBar,
  KeyboardAvoidingView,
  Alert
} from "react-native";
import { Block, Text } from "galio-framework";
import { Images, argonTheme } from "../constants";
import * as Yup from 'yup';
import SafeView from '../components/SafeView';
import Form from '../components/Forms/Form';
import FormField from '../components/Forms/FormField';
import FormButton from '../components/Forms/FormButton';
import FormErrorMessage from '../components/Forms/FormErrorMessage';
import { registerWithEmail } from '../components/Firebase/firebase';
import useStatusBar from '../hooks/useStatusBar';
import * as firebase from "firebase";
import "firebase/firestore";

const { width, height } = Dimensions.get("screen");

const validationSchema = Yup.object().shape({
  name: Yup.string()
    .required()
    .label('Name'),
  phoneNumber: Yup.string()
    .required()
    .label('Phone number'),
  email: Yup.string()
    .required('Please enter a valid email')
    .email()
    .label('Email'),
  password: Yup.string()
    .required()
    .min(6, 'Password must have at least 6 characters')
    .label('Password'),
  confirmPassword: Yup.string()
    .oneOf([Yup.ref('password')], 'Confirm Password must match Password')
    .required('Confirm Password is required')
});

export default function RegisterScreen({ navigation }) {

  useStatusBar('light-content');

  const [passwordVisibility, setPasswordVisibility] = useState(true);
  const [rightIcon, setRightIcon] = useState('eye');
  const [confirmPasswordIcon, setConfirmPasswordIcon] = useState('eye');
  const [confirmPasswordVisibility, setConfirmPasswordVisibility] = useState(
    true
  );
  const [registerError, setRegisterError] = useState('');

  function handlePasswordVisibility() {
    if (rightIcon === 'eye') {
      setRightIcon('eye-off');
      setPasswordVisibility(!passwordVisibility);
    } else if (rightIcon === 'eye-off') {
      setRightIcon('eye');
      setPasswordVisibility(!passwordVisibility);
    }
  }

  function handleConfirmPasswordVisibility() {
    if (confirmPasswordIcon === 'eye') {
      setConfirmPasswordIcon('eye-off');
      setConfirmPasswordVisibility(!confirmPasswordVisibility);
    } else if (confirmPasswordIcon === 'eye-off') {
      setConfirmPasswordIcon('eye');
      setConfirmPasswordVisibility(!confirmPasswordVisibility);
    }
  }

  async function handleOnSignUp(values, actions) {
    const { email, password } = values;
    try {
      await registerWithEmail(email, password);
      const currentUser = firebase.auth().currentUser;
      const db = firebase.firestore();
      db.collection("foodProvider")
        .doc(currentUser.uid)
        .set({
          name: values.name,
          email: values.email,
          phoneNumber: values.phoneNumber,
          count: 0
        })
        .then(() => {
          Alert.alert(
            'Message',
            'Register Successful!', 
            [
              {
                text: 'OK',
                onPress: () => navigation.navigate("AppFoodProvider", { screen: 'HomeFoodProvider'})
              }
            ]
          )
        });
    } catch (error) {
      setRegisterError(error.message);
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
            <Block style={styles.signUpContainer}>
              <Block flex>
                <Block flex={0.17} middle>
                  <Text color="#8898AA" size={20}>
                    Food Provider Registration Form
                  </Text>
                </Block>
                <Block flex center>
                  <ScrollView
                    showsVerticalScrollIndicator={false}
                    style={{ width }}
                  >
                    <KeyboardAvoidingView
                      style={{ flex: 1 }}
                      behavior="padding"
                      enabled
                    >
                      <Form
                        initialValues={{
                          name: '',
                          phoneNumber: '',
                          email: '',
                          password: '',
                          confirmPassword: ''
                        }}
                        validationSchema={validationSchema}
                        onSubmit={async (values, { resetForm }) =>  {
                          await handleOnSignUp(values)
                          resetForm()
                        }}
                      >
                        <FormField
                          name="name"
                          leftIcon="account"
                          placeholder="Enter name"
                          autoFocus={true}
                        />
                        <FormField
                          name="phoneNumber"
                          leftIcon="phone"
                          placeholder="Enter phone number"
                          keyboardType="numeric"
                          textContentType="telephoneNumber"
                        />
                        <FormField
                          name="email"
                          leftIcon="email"
                          placeholder="Enter email"
                          autoCapitalize="none"
                          keyboardType="email-address"
                          textContentType="emailAddress"
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
                        <FormField
                          name="confirmPassword"
                          leftIcon="lock"
                          placeholder="Confirm password"
                          autoCapitalize="none"
                          autoCorrect={false}
                          secureTextEntry={confirmPasswordVisibility}
                          textContentType="password"
                          rightIcon={confirmPasswordIcon}
                          handlePasswordVisibility={handleConfirmPasswordVisibility}
                        />
                        <Block middle>
                        <FormButton title={'Register'}/>
                        {<FormErrorMessage error={registerError} visible={true} />}
                        </Block>
                      </Form>
                    </KeyboardAvoidingView>
                  </ScrollView>
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
  signUpContainer: {
    width: width * 0.95,
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
    overflow: "hidden",
  },
});

