// Programmer Name :Mr.Lau Kah Hou, UC3F2005SE
// Program Name :completedRequest.js
// Description :To display the completed requests handled by the food distributor
// First Written on :Tuesday, 15-December-2020
// Edited on :Thursday, 17-December-2020

import React, { useState, useEffect, useRef } from "react";
import {
  ScrollView,
  StyleSheet,
  Image,
  TouchableWithoutFeedback,
  Dimensions
} from "react-native";
import { Block, Text, theme } from "galio-framework";
import * as firebase from "firebase";
import 'firebase/storage';
import "firebase/firestore";
import useStatusBar from '../hooks/useStatusBar';
import {useIsMounted} from 'react-tidy';
import Spinner from '../components/Spinner';

const { width } = Dimensions.get("screen");
const cardWidth = width - theme.SIZES.BASE * 2;

export default function CompletedRequest() {

  useStatusBar('light-content');
  const [completedRequestList, setCompletedRequestList] = useState([]);
  const [isEmpty, setIsEmpty] = useState();
  const isMounted = useIsMounted();
  const [lastUpdated, setLastUpdated] = useState();

  useEffect(() => {
    
    if(isMounted){ 
      getLastUpdate();
      getAllCompletedRequest();
    }
    //If unmounted, do some clean up to clear the resources to prevent slowing done the applciation
    return () => {
      completedRequestList ? setCompletedRequestList(completedRequestList => []) : setCompletedRequestList([]);
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
              console.log("first time getting last updated [COMPLETED REQUEST]");
        }}});
      }
    } catch (err) {
      console.log(err);
    }
  }

  const getAllCompletedRequest = async () => {
    try{
      const currentUser = firebase.auth().currentUser;
      const db = firebase.firestore();
      let allCompletedRequest = [];
      await db.collection("foodDonation")
        // Get all completed food donations request
      .where("foodDistributorId", "==", currentUser.uid)
      .where("isCompleted", "==", true )
      //.orderBy("foodRequestSubmittedAt", "asc")
      .onSnapshot(querySnapshot => {
        if (querySnapshot.size) {
          querySnapshot.forEach(doc => {
            allCompletedRequest.push({ ...doc.data() });
          })

          //Check if is empty updated before
          isEmpty
          ? setIsEmpty(isEmpty => "")
          : setIsEmpty("");

          setTimeout(() => {
            setCompletedRequestList(allCompletedRequest) 
          }, 1000);
        }
        else {
          setIsEmpty("No completed food donation request from food provider right now. Check it out in pending or active request tab!");
        }
      });
    } catch (err) {
      console.log(err);
    };
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
            <Block left style={{ paddingHorizontal: 10, marginTop: 20, marginLeft: 7, paddingBottom: 50}}>
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
                  {'\n'}*** Food Distributor Section ***
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
                  {item.foodPickedUpAt}
                </Text>
                <Text left size={16}>
                  {'\n'}Food Delivered At: 
                </Text>
                <Text left bold size={16}>
                  {item.foodDeliveredAt}
                </Text>
                <Text left size={16}>
                  {'\n'}Food Recipient Name: 
                </Text>
                <Text left bold size={16}>
                  {item.foodRecipientName || "N/A"}
                </Text>
            </Block>
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
            {completedRequestList &&
              completedRequestList.map((item, index) =>
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
  }
});

