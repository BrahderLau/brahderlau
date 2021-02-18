// Programmer Name :Mr.Lau Kah Hou, UC3F2005SE
// Program Name :SignUpFoodProvider.js
// Description :To create the sign up page for food provider
// First Written on :Saturdays, 28-November-2020
// Edited on :Monday, 14-December-2020

import React, { useState, useEffect } from "react";
import {
  ScrollView,
  StyleSheet,
  Image,
  TouchableWithoutFeedback,
  Dimensions
} from "react-native";
//galio
import { Block, Text, theme } from "galio-framework";
//argon
import { argonTheme } from "../constants/";
import * as firebase from "firebase";
import 'firebase/storage';
import "firebase/firestore";
import useStatusBar from '../hooks/useStatusBar';

const { width } = Dimensions.get("screen");
const thumbMeasure = (width - 48 - 32) / 3;
const cardWidth = width - theme.SIZES.BASE * 2;

export default function FoodDonationHistory() {

  useStatusBar('light-content');
  const [foodDonationList, setFoodDonationList] = useState([]);
  const [isEmpty, setIsEmpty] = useState();

  useEffect(() => {
    getFilteredFoodDonations()
    return () => getFilteredFoodDonations();
  },[]);

  const getFilteredFoodDonations = async () => {
    try{
      const currentUser = firebase.auth().currentUser;
      const db = firebase.firestore();
      let donationList = [];
      await db.collection("foodDonation")
        // Filter food donations based on food provider id
        .where("foodProviderId", "==", currentUser.uid)
        .orderBy("foodRequestSubmittedAt", "desc")
        .onSnapshot(documentSnapshot => {
          if(documentSnapshot.size){
            documentSnapshot.forEach((foodDonation) => {
              donationList.push({ ...foodDonation.data() })
              //setFoodDonationList(e => [...e, foodDonation.data()]);
              //setFoodDonationList(e => e.concat(foodDonation.data()));
            })
            setFoodDonationList(donationList);
            setIsEmpty("");
          }
          else{
            setIsEmpty("You have not submit any food donation request. Add new food donation request now!");
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
            <Block left style={{ paddingHorizontal: 10, marginTop: 20, marginLeft: 7, paddingBottom: 80}}>
              <Text center bold size={20}>
                  *** Food Provider Section ***
              </Text>
              <Text left size={16}>
              {'\n'}Submitted At:
              </Text>
              <Text left bold size={16}>
                {item.foodRequestSubmittedAt}
              </Text>
              <Text left size={16}>
              {'\n'}Food Donation Processs Status: 
              </Text>
              <Text left bold size={16}>
                {item.foodDonationProcessStatus}
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
            {foodDonationList &&
              foodDonationList.map((item, index) =>
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
  }
});

