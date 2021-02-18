// Programmer Name :Mr.Lau Kah Hou, UC3F2005SE
// Program Name :HomeFoodProvider.js
// Description :To create the home screen for Food Provider
// First Written on :Saturday, 21-November-2020
// Edited on :Wednesday, 9-December-2020

import React, { useEffect, useState } from 'react';
import { View, Alert, ImageBackground, StyleSheet, Dimensions } from 'react-native';
import { Block, Text } from 'galio-framework';
import Images from "../constants/Images";
import * as firebase from 'firebase';
import * as Notifications from 'expo-notifications';
import * as Permissions from 'expo-permissions';
import Constants from 'expo-constants';
import moment from 'moment';

const { height, width } = Dimensions.get('screen');

export default function HomeFoodProvider() {

  const [name, setName] = useState('');
  const [count, setCount] = useState(0);

  useEffect(() => {
    registerForPushNotificationsAsync()
    getUserInfo()
    getRequestedFoodDonations()
    return () => getUserInfo();
  },[])
  
  const registerForPushNotificationsAsync = async () => {
    let token;
    if (Constants.isDevice) {
      const { status: existingStatus } = await Permissions.getAsync(Permissions.NOTIFICATIONS);
      let finalStatus = existingStatus;
      if (existingStatus !== 'granted') {
        const { status } = await Permissions.askAsync(Permissions.NOTIFICATIONS);
        finalStatus = status;
      }
      if (finalStatus !== 'granted') {
        alert('Failed to get push token for push notification!');
        return false;
      }
      token = (await Notifications.getExpoPushTokenAsync()).data;
      console.log(token);
    } else {
      alert('Must use physical device for Push Notifications');
    }

    if(token){
      const res = await firebase
      .firestore()
      .collection('foodProvider')
      .doc(firebase.auth().currentUser.uid)
      .set({token}, {merge: true}) // merge = true ensures that the token is not tampered with
    } 

    if (Platform.OS === 'android') {
      Notifications.setNotificationChannelAsync('default', {
        name: 'default',
        importance: Notifications.AndroidImportance.MAX,
        vibrationPattern: [0, 250, 250, 250],
        lightColor: '#FF231F7C',
      });
    }
  
    return token;
  }

  const getRequestedFoodDonations = async () => {
    try{
      const currentUser = firebase.auth().currentUser;
      const db = firebase.firestore();
      await db.collection("foodDonation")
        // Filter food donations based on food provider id
        .where("foodProviderId", "==", currentUser.uid)
        .where("foodDonationProcessStatus", "==", "Requested")
        .onSnapshot(documentSnapshot => {
          if(documentSnapshot.size){
            documentSnapshot.forEach((foodDonation) => {
              if(foodDonation.data().foodDonationProcessStatus === "Requested"){

                var duration = moment(foodDonation.data().bestBeforeDateTime,"dddd, MMMM Do YYYY, h:mm a").fromNow(true);

                if(duration.includes("minutes")){
                  var number = duration.match(/\d/g);
                  number = number.join("");
                  if(number <= 30){
                    sendNotificationToUser(foodDonation.data().foodRequestSubmittedAt,duration)
                  }
                }
                else{
                  console.log("Food is still fresh...")
                }
              }
            })
          }
        });
    } catch (err) {
      console.log(err);
    };
  }

  const sendNotification = async (token,foodRequestSubmittedAt, duration) => {
    const bodyData = 'The food donation request you submitted at ' + foodRequestSubmittedAt + ' is going to be expired in ' + duration + '. Please throw it away!'
    const message = {
      to: token,
      sound: 'default',
      title: 'New Message',
      body: bodyData,
      data: { data: 'goes here' },
    };
  
    await fetch('https://exp.host/--/api/v2/push/send', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Accept-encoding': 'gzip, deflate',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(message),
    });
  }

  const sendNotificationToUser = async (foodRequestSubmittedAt, duration) => {
    const currentUser = firebase.auth().currentUser;
    await firebase.firestore().collection("foodProvider").doc(currentUser.uid).get().then(user => {
      
      if(user.exists){
        sendNotification(user.data().token,foodRequestSubmittedAt, duration)
      }
    })
  }

  const getUserInfo = async () => {
    try{
      const currentUser = firebase.auth().currentUser;
      await firebase
      .firestore()
      .collection("foodProvider")
      .doc(currentUser.uid)
      .onSnapshot(documentSnapshot => {
        if(documentSnapshot){
          const string1 = "You Have Rescued Food ";
          const string2 = " Times. Good Job Hero!";
          setName(documentSnapshot.data().name);
          documentSnapshot.data().count === 0
          ? setCount("Start Rescueing Food Now, Hero!")
          : setCount(string1 + documentSnapshot.data().count + string2)
        }
        else{
          Alert.alert('No information about the food provider found!')
        }
      });
    }
    catch(error){
      console.log(error);
    }
  }

  return (
    <Block flex center style={styles.home}>
      <Block flex center>
        <ImageBackground
          source={Images.Onboarding}
          style={{ height, width, zIndex: 1 }}
        />      
      </Block>
      <Block>
        <View style={{ flex: 1 }} >
          <Text bold size={26} style={styles.homeText}>{name}</Text>
        </View>
        <View>
          <Text size={20} style={styles.homeText}>
            {count}
          </Text>
        </View>
      </Block>
    </Block>
  );
}


const styles = StyleSheet.create({
  home: {
    width: width,    
  },
  homeText: {
    flexDirection: 'row', 
    justifyContent: 'center', 
    alignItems: 'center', 
    paddingBottom: 100, 
    paddingTop: 15,
    textAlign: 'center'
  }
});
