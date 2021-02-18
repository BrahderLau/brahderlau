// Programmer Name :Mr.Lau Kah Hou, UC3F2005SE
// Program Name :ActiveRequest.js
// Description :To display the current active requests accepted by the food distributor
// First Written on :Tuesday, 15-December-2020
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
//galio
import { Block, Text, theme } from "galio-framework";
import * as firebase from "firebase";
import 'firebase/storage';
import "firebase/firestore";
import useStatusBar from '../hooks/useStatusBar';
import { Button } from "../components";
import moment from 'moment';
import {useIsMounted} from 'react-tidy';

const { width } = Dimensions.get("screen");
const cardWidth = width - theme.SIZES.BASE * 2;

export default function ActiveRequest() {

  useStatusBar('light-content');
  const [activeRequestList, setActiveRequestList] = useState([]);
  const [isEmpty, setIsEmpty] = useState();
  const isMounted = useIsMounted();
  const [lastUpdated, setLastUpdated] = useState();

  useEffect(() => {
    if(isMounted){
      getLastUpdate();
      getAllActiveRequest();
    }
    //If unmounted, do some clean up to clear the resources to prevent slowing done the applciation
    return () => {
      activeRequestList ? setActiveRequestList(activeRequestList => []) : setActiveRequestList([]);
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

  const getAllActiveRequest = async () => {
    try{
      console.log("getting all active request");
      const currentUser = firebase.auth().currentUser;
      const db = firebase.firestore();
      let allActiveRequest = [];
      await db.collection("foodDonation")
      // Get all active food donations request
      .where("foodDistributorId", "==", currentUser.uid)
      .where("isCompleted", "==", false )
      //.orderBy("foodRequestSubmittedAt", "asc")
      .onSnapshot(querySnapshot => {
        if (querySnapshot.size) {
          querySnapshot.forEach(doc => {
            allActiveRequest.push({ ...doc.data() });
            
          })

          //Check if is empty updated before
          isEmpty
          ? setIsEmpty(isEmpty => "")
          : setIsEmpty("");
          setTimeout(() => {
            if(activeRequestList.length === allActiveRequest.length){
              //already get the latest dont need to reload
            }
            else{
              setActiveRequestList(allActiveRequest)
            }
          }, 1000);
        }
        else {
          setIsEmpty("No active food donation request from food provider right now. Check it again later!");
        }
      });
    } catch (err) {
      console.log(err);
    };
  }

  const getDocumentId = async (index,fieldToUpdate) => {
    try {
      const selectedRequest = activeRequestList[index];
      const field = fieldToUpdate;
      const db = firebase.firestore();
      const document = [];
      await new Promise((resolve) => 
      db.collection("foodDonation")
      .where("foodRequestSubmittedAt", "==", selectedRequest.foodRequestSubmittedAt)
      .onSnapshot(querySnapshot => {
        querySnapshot.forEach(documentSnapshot => {
          document.push({
            ...documentSnapshot.data(),
            key: documentSnapshot.id
        })
        if(document[0].key){
          resolve();
        }
      })}));
      if(document[0].key){
        updateStatus(field, document[0].key)  
      }
    }
    catch (err) {
      console.log(err);
    }
  }

  const updateStatus = async (field,docId) => {
    try {
      const db = firebase.firestore();
      if(field==="Picked Up Status"){
        await db.collection("foodDonation")
        .doc(docId)
        .update({
            foodPickedUpAt: moment().format("dddd, MMMM Do YYYY, h:mm a"),
            foodDonationProcessStatus: "Picked Up"
        })
      }
      else{
        await AsyncAlert(docId);
      }
      changeLastUpdated();
      Alert.alert("Update " + field + " successful!");
    } catch (error) {
      console.log(error);
    }
  }

  const AsyncAlert = (docId) => new Promise((resolve) => {
    Alert.prompt(
      'Message',
      'Enter the name of the food recipient (Optional).',
      [
        {
          text: 'OK',
          onPress: (foodReceivedBy) => {
            updateCompleted(foodReceivedBy, docId);
            resolve("DONE");
          }
        }
      ]
    );
  });

  const updateCompleted = async (name, docId) => {
    try{
      const currentUser = firebase.auth().currentUser;
      const db = firebase.firestore();
      await db.collection("foodDonation")
        .doc(docId)
        .update({
            foodDonationProcessStatus: "Delivered",
            foodDeliveredAt: moment().format("dddd, MMMM Do YYYY, h:mm a"),
            foodRecipientName: name,
            isCompleted: true
        })
        .then(() => {
            db.collection("foodDistributor")
            .doc(currentUser.uid)
            .update({
              count: firebase.firestore.FieldValue.increment(1)
            })
        });
    }
    catch (error) {
      console.log(error);
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

  const showUpdatePickedUpButton = (index) => {
      if(!activeRequestList[index].foodPickedUpAt){
          return(
            <Button color="primary" onPress={()=> getDocumentId(index,"Picked Up Status")}>Update Picked Up</Button>
          );
      }
  }

  const showUpdateDeliveredButton = (index) => {
    if(!activeRequestList[index].foodDeliveredAt){
        return(
          <Button color="primary" onPress={()=> getDocumentId(index,"Delivered Status")}>Update Delivered</Button>
        );
    }
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
                <Text center bold size={20}>
                  *** Food Provider Section ***
                </Text>
                <Text left size={16}>
                  {'\n'}Food Donation Processs Status: 
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
                <Text center bold size={20}>
                  {'\n'}*** Food distributor Section ***
                </Text>
                <Text left size={16}>
                  {'\n'}Food Request Accepted At: 
                </Text>
                <Text left bold size={16}>
                  {item.foodRequestAcceptedAt}
                </Text>
                <Text left size={16}>
                  {'\n'}Food Picked Up At: 
                </Text>
                <Text left bold size={16}>
                  {item.foodPickedUpAt || "N/A"}
                </Text>
            </Block>
            <View style={styles.container}>
                {showUpdatePickedUpButton(index)}
                {showUpdateDeliveredButton(index)}
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
            {activeRequestList &&
              activeRequestList.map((item, index) =>
                renderFood(item, index)
            )}
          </ScrollView>
        </ScrollView>
      </Block>
    </Block>
  );
}

const styles = StyleSheet.create({
  group: {
    paddingTop: theme.SIZES.BASE,
    marginTop: 40
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
  container: {
    alignItems: 'center',
    justifyContent: 'center',
    paddingBottom: 20
  }
});

