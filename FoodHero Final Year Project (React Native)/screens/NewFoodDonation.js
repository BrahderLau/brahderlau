// Programmer Name :Mr.Lau Kah Hou, UC3F2005SE
// Program Name :NewFoodDonation.js
// Description :To create the page for food provider to fill up the new food donation form.
// First Written on :Saturdays, 28-November-2020
// Edited on :Sunday, 13-December-2020

import React, { useState, useEffect } from "react";
import {
  ScrollView,
  StyleSheet,
  Image,
  ImageBackground,
  Dimensions,
  StatusBar,
  KeyboardAvoidingView,
  Alert,
  View
} from "react-native";
import { Block, Text, theme } from "galio-framework";
import { Images, argonTheme } from "../constants";
import * as Yup from 'yup';
import * as Permissions from 'expo-permissions';
import * as ImagePicker from 'expo-image-picker';
import * as firebase from "firebase";
import 'firebase/storage';
import "firebase/firestore";
import Constants from 'expo-constants';
import DateTimePickerModal from "react-native-modal-datetime-picker";
import moment from 'moment';
import useStatusBar from '../hooks/useStatusBar';
import Form from '../components/Forms/Form';
import FormField from '../components/Forms/FormField';
import FormButton from '../components/Forms/FormButton';
import FormErrorMessage from '../components/Forms/FormErrorMessage';
import { Button } from "../components";
import { CheckBox } from 'react-native-elements';

const { width, height } = Dimensions.get("screen");
const cardWidth = width - theme.SIZES.BASE * 2;

const validationSchema = Yup.object().shape({
  location: Yup.string()
    .required()
    .label('Location'),
  foodItems: Yup.string()
    .required()
    .label('Food Items'),
  foodQuantity: Yup.string()
    .required()
    .label('Food Quantity')
});


export default function NewFoodDonation() {

  useStatusBar('light-content');
  const [submitError, setSubmitError] = useState("");
  const [cookDateTime, setCookDateTime] = useState();
  const [pickupDateTime, setPickupDateTime] = useState();
  const [eatDateTime, setEatDateTime] = useState();
  const [type, setType] = useState();
  const [isDateTimePickerVisible, setDatePickerVisibility] = useState(false);
  const [image, setImage] = useState(null);
  const [imageUrl, setImageUrl] = useState(null);
  const [checked, setChecked] = useState(false)

  // *** Start of Image Picker section ***
  useEffect(() => {
    getPermissionAsync()
  }, [])

  const uploadImageToFirebase = async (uri, userUID) => {

    const blob = await new Promise((resolve, reject) => {
        const xhr = new XMLHttpRequest();
        xhr.onload = () => {
            resolve(xhr.response);
        };
        xhr.onerror = function(e) {
          console.log(e);
          reject(new TypeError('Network request failed'));
        };
        xhr.responseType = 'blob';
        xhr.open('GET', uri, true);
        xhr.send(null);
    });

    const dateTimeUpload = moment().format("dddd, MMMM Do YYYY, h:mm:ss")
    const ref = firebase
        .storage()
        .ref()
        .child(`foodImages/${dateTimeUpload}/${userUID}`);

    const snapshot = await ref.put(blob);

    // We're done with the blob, close and release it
    blob.close();

    return await snapshot.ref.getDownloadURL();
  };

  const getPermissionAsync = async () => {
      if (Constants.platform.ios) {const { status } = await 
        Permissions.askAsync(Permissions.CAMERA_ROLL)
        if (status !== 'granted') {
            alert('Sorry, we need camera roll permissions to make this work!')
        }
      }
  }

  const _pickImage = async () => {
    try{
      let pickerResult = await ImagePicker.launchImageLibraryAsync({
        mediaTypes: ImagePicker.MediaTypeOptions.All,
        base64: true,
        allowsEditing: true,
        aspect: [4, 4],
        quantity: 1
      })
      if (!pickerResult.cancelled) {
        setImage(pickerResult.uri)
      }
    }
    catch(error){
      Alert.alert(error);
    }
  }

  const _takePhoto = async () => {
    
    const {
    status: cameraPerm
    } = await Permissions.askAsync(Permissions.CAMERA)
    
    const {
      status: cameraRollPerm
    } = await Permissions.askAsync(Permissions.CAMERA_ROLL)

    // only if user allows permission to camera AND camera roll
    if (cameraPerm === 'granted' && cameraRollPerm === 'granted') {

      let pickerResult = await ImagePicker.launchCameraAsync({
          base64: true,
          allowsEditing: true,
          aspect: [4, 4],
          quantity: 1
      })
      
      if (!pickerResult.cancelled) {
        setImage(pickerResult.uri)
      }
    } 
  }

  // *** End of Image Picker section ***
  // *** Start of Date Time Picker section ***
  const showDateTimePicker = (type) => {
    setDatePickerVisibility(true);
    setType(type);
  };

  const hideDateTimePicker = () => {
    setDatePickerVisibility(false);
  };

  const handleConfirm = (datetime) => {   

    if(type==="cook"){
    setCookDateTime(moment(datetime).format("dddd, MMMM Do YYYY, h:mm a"));
    }
    else if(type=="pickup"){
      setPickupDateTime(moment(datetime).format("dddd, MMMM Do YYYY, h:mm a"));
    }
    else if(type==="eat"){
      setEatDateTime(moment(datetime).format("dddd, MMMM Do YYYY, h:mm a"));
    }
    hideDateTimePicker();
  };

  // *** End of Date Time Picker section ***

  async function handleOnSubmit(values, actions) {
    const { 
      location, 
      foodItems,
      foodQuantity,
    } = values;

    try {
      const currentUser = firebase.auth().currentUser;
      const uploadedImage = await uploadImageToFirebase(image,currentUser.uid);
      const db = firebase.firestore();
      db.collection("foodDonation")
        .add({
          location: values.location,
          foodItems: values.foodItems,
          foodQuantity: values.foodQuantity,
          cookedDateTime: cookDateTime,
          bestBeforeDateTime: eatDateTime,
          expectedPickUpDateTime: pickupDateTime,
          imageUrl: uploadedImage,
          foodRequestSubmittedAt: moment().format("dddd, MMMM Do YYYY, h:mm:ss a"),
          foodProviderId: currentUser.uid,
          foodDonationProcessStatus: "Requested",
          isCompleted: false
        })
        .then(() => {
          db.collection("foodProvider")
            .doc(currentUser.uid)
            .update({
              count: firebase.firestore.FieldValue.increment(1)
            })
        })
        .then(() => {
          //Reset fields
          setCookDateTime("");
          setPickupDateTime("");
          setEatDateTime("");
          setImage(null);
          setImageUrl(null);
          setSubmitError("");
          Alert.alert('Successful! Your food donation request will be accepted by any food distributor soon!');
        });
    } catch (error) {
      setSubmitError(error.message);
    }
  }
    
  return (
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
                <Text color="#8898AA" size={16}>
                  New Food Donation Information Form
                </Text>
              </Block>
              <Block flex center marginLeft={-47}>
                <ScrollView
                  pagingEnabled={true}
                  decelerationRate={0}
                  snapToAlignment="center"
                  showsHorizontalScrollIndicator={false}
                  style={{ width, marginLeft: 82}}
                >
                  <KeyboardAvoidingView
                    style={{ flex: 1 }}
                    behavior="padding"
                    enabled
                  >
                    <Form
                      initialValues={{
                        location: '',
                        foodItems: '',
                        quantity: '',
                        cookedDateTime: '',
                        expectedPickUpDateTime: '',
                        bestBeforeDateTime: ''
                      }}
                      validationSchema={validationSchema}
                      onSubmit={async (values, { resetForm }) =>  {
                        await handleOnSubmit(values)
                        resetForm()
                      }}
                    >
                      <FormField
                        name="location"
                        leftIcon="google-maps"
                        placeholder="Enter location"
                      />
                      <FormField
                        name="foodItems"
                        leftIcon="food"
                        placeholder="Enter food items"
                      />
                      <FormField
                        name="foodQuantity"
                        leftIcon="basket"
                        placeholder="Enter food quantity (pax)"
                        keyboardType="numeric"
                      />
                      <FormField
                        name="cookedDateTime"
                        leftIcon="calendar-clock"
                        placeholder="Select cook date and time"
                        onTouchStart={ () => showDateTimePicker("cook")}
                        value={cookDateTime}
                        editable={false}
                      />   
                      <FormField
                        name="expectedPickUpDateTime"
                        leftIcon="calendar-clock"
                        placeholder="Select expected pick up date and time"
                        onTouchStart={ () => showDateTimePicker("pickup")}
                        value={pickupDateTime}
                        editable={false}
                      />
                      <FormField
                        name="bestBeforeDateTime"
                        leftIcon="calendar-clock"
                        placeholder="Select best before date and time"
                        onTouchStart={ () => showDateTimePicker("eat")}
                        value={eatDateTime}
                        editable={false}
                      /> 
                      <View>
                        <DateTimePickerModal
                          isVisible={isDateTimePickerVisible}
                          mode="datetime"
                          onConfirm={handleConfirm}
                          onCancel={hideDateTimePicker}
                          headerTextIOS="Pick Date and Time"
                        />
                      </View>  
                      <View style={styles.container}>
                      <Text style={{marginBottom: 10}}>Upload a photo of the food:</Text>
                        <Block>
                          <View style={styles.emptyProfile}>
                            {image && <Image style={styles.profile} source={{ uri: image }} />}
                          </View>
                        </Block>
                      </View>
                      <View style={styles.container}>
                        <View style={styles.row} >
                          <Button color="primary" small onPress={_pickImage}>Gallery</Button>
                          <Button color="primary" small onPress={_takePhoto}>Camera</Button> 
                        </View>
                      </View>
                      <View style={styles.checkboxContainer}>
                          <CheckBox
                             title="I assure that the food quality and hygiene has maintained."
                             checked={checked}
                             onPress={() => setChecked(check => !checked)}
                          />
                      </View>
                      <Block middle style={{ width, marginLeft: -20}}>
                      <FormButton title={'Submit'} onReset/>
                      {<FormErrorMessage error={submitError} visible={true}/>}
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
  );
}

const styles = StyleSheet.create({
  signUpContainer: {
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
  createButton: {
    width: width * 0.5,
    marginTop: 25
  },
  textCon: {
    width: 320,
    flexDirection: 'row',
    justifyContent: 'space-between'
  },
  container: {
    flex: 1,
    padding: 30,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: '#fff'
  },
  image: {
    width: 300, 
    height: 300, 
    backgroundColor: 'gray',

  },
  row: {flexDirection: 'row'},
  button: { 
    padding: 13,
    margin: 15,
  },
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    paddingRight:50
  },
  profile: {
    width: 190,
    height: 190,
    borderRadius: 100,
    justifyContent: 'center',
    alignItems: 'center',
  },
  emptyProfile: {
      width: 200,
      height: 200,
      borderRadius: 100,
      backgroundColor: '#c1b78d',
      borderWidth: 5,
      borderColor: '#fff',
      shadowColor: 'black',
      shadowOffset: { width: 0, height: 3 },
      shadowRadius: 3,
      shadowOpacity: 0.3,
      elevation: 5,
  },
  checkboxContainer: {
    flexDirection: "row",
    marginRight: 50
  }
});