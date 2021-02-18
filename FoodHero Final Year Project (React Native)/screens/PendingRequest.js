// Programmer Name :Mr.Lau Kah Hou, UC3F2005SE
// Program Name :PendingRequest.js
// Description :To display the pending requests for all food distributor
// First Written on :Monday, 14-December-2020
// Edited on :Saturday, 19-December-2020

import React, { useState, useEffect } from "react";
import {
  ScrollView,
  StyleSheet,
  Image,
  TouchableWithoutFeedback,
  Dimensions,
  View,
  Alert
} from "react-native";
import { Block, Text, theme } from "galio-framework";
import { argonTheme } from "../constants/";
import * as firebase from "firebase";
import 'firebase/storage';
import "firebase/firestore";
import useStatusBar from '../hooks/useStatusBar';
import { Button } from "../components";
import moment from 'moment';
import {useIsMounted} from 'react-tidy';

const { width } = Dimensions.get("screen");
const thumbMeasure = (width - 48 - 32) / 3;
const cardWidth = width - theme.SIZES.BASE * 2;

export default function PendingRequest() {

  useStatusBar('light-content');
  const [pendingRequestList, setPendingRequestList] = useState([]);
  const [isEmpty, setIsEmpty] = useState();
  const isMounted = useIsMounted();
  const [lastUpdated, setLastUpdated] = useState();

  useEffect(() => {

    if(isMounted){
      getLastUpdate()
      getAllPendingRequest()
    }
    //If unmounted, do some clean up to clear the resources to prevent slowing done the applciation
    return () => {
      pendingRequestList ? setPendingRequestList(pendingRequestList => []) : setPendingRequestList([]);
      isEmpty ? setIsEmpty(isEmpty => "") : setIsEmpty("");
    }
  },[lastUpdated]);

  const getLastUpdate = async () => {
    try {
      if(!lastUpdated){
        const currentUser = firebase.auth().currentUser;
        const db = firebase.firestore();
        await db.collection("foodDistributor")
        .doc(currentUser.uid)
        .onSnapshot(documentSnapshot => {
          if(documentSnapshot){
            if(lastUpdated  !== documentSnapshot.data().lastUpdated){
              setLastUpdated(documentSnapshot.data().lastUpdated)
        }}});
      }
    } catch (err) {
      console.log(err);
    }
  }

  const getAllPendingRequest = async () => {
    try{
      const db = firebase.firestore();
      let allPendingRequest = [];
      await db.collection("foodDonation")
        // Get all pending food donations request
      .where("foodDonationProcessStatus", "==", "Requested")
      .orderBy("foodRequestSubmittedAt", "asc")
      .onSnapshot(querySnapshot => {
        if (querySnapshot.size) {
          querySnapshot.forEach(doc => {
            allPendingRequest.push({ ...doc.data() });
          })
          //Check if is empty updated before
          isEmpty
          ? setIsEmpty(isEmpty => "")
          : setIsEmpty("");

          setTimeout(() => {
            setPendingRequestList(allPendingRequest)
          }, 1000);
        }
        else {
          setIsEmpty("No pending food donation request from food provider right now. Check it again later!");
        }
      });
    } catch (err) {
      console.log(err);
    };
  }

  const getDocumentId = async (index) => {
    try {
      const selectedRequest = pendingRequestList[index];
      const db = firebase.firestore();
      const document = [];
      await db.collection("foodDonation")
      .where("foodRequestSubmittedAt", "==", selectedRequest.foodRequestSubmittedAt)
      .onSnapshot(querySnapshot => {
        querySnapshot.forEach(documentSnapshot => {
          document.push({
            ...documentSnapshot.data(),
            key: documentSnapshot.id
        });
        //Wait until successfully getting the document id
        setTimeout(() => {
          if(document[0].key){
            acceptRequest(document[0].key);
            sendNotificationToUser(document[0].foodProviderId,document[0].foodRequestSubmittedAt)
            changeLastUpdated();
          }
        }, 1000);
      })});
      Alert.alert("Request accepted successful!");
    }
    catch (err) {
      console.log(err);
    }
  }

  const acceptRequest = async (docId) => {
    try {
      
      const currentUser = firebase.auth().currentUser;
      const db = firebase.firestore();
      await db.collection("foodDonation")
      .doc(docId)
      .update({
          foodDistributorId: currentUser.uid,
          foodRequestAcceptedAt: moment().format("dddd, MMMM Do YYYY, h:mm a"),
          foodDonationProcessStatus: "Accepted"
      });
    } catch (err) {
      console.log(err);
    }
  }

  const changeLastUpdated = async () => {
    try {
      const currentDT = moment().format("dddd, MMMM Do YYYY, h:mm:ss a");
      const currentUser = firebase.auth().currentUser;
      const db = firebase.firestore();
      await db.collection("foodDistributor")
      .doc(currentUser.uid)
      .update({
        lastUpdated: currentDT
      });
      setLastUpdated(lastUpdated);
    } catch (err) {
      console.log(err);
    }
  }

  const sendNotification = async (token,foodRequestSubmittedAt) => {
    console.log("token:" + token);
    const bodyData = 'The food donation request you submitted at ' + foodRequestSubmittedAt + ' is accepted!'
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

  const sendNotificationToUser = async (foodProviderId,foodRequestSubmittedAt) => {
    //const currentUser = firebase.auth().currentUser;
    //const fd = await firebase.firestore().collection("foodDistributor").doc(currentUser.uid).get();
    //fd.docs.map(user => sendNotification(user.data().token))
    await firebase
    .firestore()
    .collection("foodProvider")
    .doc(foodProviderId)
    .get().then(user => {
      if(user.exists){
        sendNotification(user.data().token,foodRequestSubmittedAt)
      }
    })
  }

  const renderFood = (item, index) => {
    try{
      return (
        <TouchableWithoutFeedback
          key={`food-${item.foodRequestSubmittedAt}-${index.toString()}`}
        >
          <Block center style={styles.foodItem}>
            <Image
              resizeMode="cover"
              style={styles.foodImage}
              source={{ uri: item.imageUrl }}
            />
            <Block left style={{ paddingHorizontal: 10, marginTop: 20, marginLeft: 7}}>
              <Text left size={16}>
              Food Donation Processs Status:
              </Text>
              <Text left bold size={16}>
                {item.foodDonationProcessStatus}
              </Text>
              <Text left size={16}>
                {'\n'}Food Request Submitted At:
              </Text>
              <Text left bold size={16}>
                {item.foodRequestSubmittedAt}
              </Text>
              <Text left size={16}>
                {'\n'}Food Items:
              </Text>
              <Text left bold size={16}>
                {item.foodItems}
              </Text>
              <Text left size={16}>
                {'\n'}Food Quantity:
              </Text>
              <Text left bold size={16}>
                {item.foodQuantity}
              </Text>
              <Text left size={16}>
                {'\n'}Food Cooked At:
              </Text>
              <Text left bold size={16}>
                {item.cookedDateTime}
              </Text>
              <Text left size={16}>
                {'\n'}Expected Pick Up Date and Time:
              </Text>
              <Text left bold size={16}>
                {item.expectedPickUpDateTime}
              </Text>
              <Text left size={16}>
                {'\n'}Food Last Until:
              </Text>
              <Text left bold size={16}>
                {item.bestBeforeDateTime}
              </Text>
            </Block>
            <View style={styles.container}>
                <Button color="primary" onPress={()=> getDocumentId(index)}>Accept</Button>
            </View>
          </Block>
        </TouchableWithoutFeedback>
      );
    }
    catch(err){
        console.log(err);
    }
  };
  return (
    <Block flex style={styles.group}>
      <Block flex style={{ marginTop: 30 }}>
      {/* <Button color="primary" onPress={()=> sendNotificationToAllUsers()}> Send Notifications </Button> */}
      <Text center bold size={20} >{isEmpty}</Text>
        <ScrollView>
          <ScrollView
            horizontal={true}
            pagingEnabled={true}
            decelerationRate={0}
            scrollEventThrottle={16}
            snapToAlignment="center"
            showsHorizontalScrollIndicator={false}
            snapToInterval={cardWidth + theme.SIZES.BASE * 0.375}
            contentContainerStyle={{
              paddingHorizontal: theme.SIZES.BASE / 2
            }}
          >
            {pendingRequestList &&
              pendingRequestList.map((item, index) =>
                renderFood(item, index)
            )}
          </ScrollView>
        </ScrollView>
      </Block>
    </Block>
  );
}

const styles = StyleSheet.create({
  title: {
    paddingBottom: theme.SIZES.BASE,
    paddingHorizontal: theme.SIZES.BASE * 2,
    marginTop: 22,
    color: argonTheme.COLORS.HEADER
  },
  group: {
    paddingTop: theme.SIZES.BASE,
    marginTop: 40
  },
  albumThumb: {
    borderRadius: 4,
    marginVertical: 4,
    alignSelf: "center",
    width: thumbMeasure,
    height: thumbMeasure
  },
  category: {
    backgroundColor: theme.COLORS.WHITE,
    marginVertical: theme.SIZES.BASE / 2,
    borderWidth: 0
  },
  categoryTitle: {
    height: "100%",
    paddingHorizontal: theme.SIZES.BASE,
    backgroundColor: "rgba(0, 0, 0, 0.5)",
    justifyContent: "center",
    alignItems: "center"
  },
  imageBlock: {
    overflow: "hidden",
    borderRadius: 4
  },
  foodItem: {
    width: cardWidth - theme.SIZES.BASE * 2,
    marginHorizontal: theme.SIZES.BASE,
    shadowColor: "black",
    shadowOffset: { width: 0, height: 7 },
    shadowRadius: 10,
    shadowOpacity: 0.2
  },
  foodImage: {
    width: 220,
    height: 220,
    borderRadius: 3
  },
  location: {
    paddingTop: theme.SIZES.BASE,
    paddingBottom: theme.SIZES.BASE / 2
  },
  foodQuantity: {
    paddingTop: theme.SIZES.BASE
    // paddingBottom: theme.SIZES.BASE * 2,
  },
  container: {
    alignItems: 'center',
    justifyContent: 'center',
    paddingBottom: 50
  }
});

