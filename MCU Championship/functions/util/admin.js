const admin = require('firebase-admin')

const firebase = require('firebase');

const { config } = require('./config')

admin.initializeApp();
  
const firebaseApp = firebase.initializeApp(config)

const db = firebaseApp.firestore();

const auth = firebase.auth();

module.exports = { admin, db, auth };