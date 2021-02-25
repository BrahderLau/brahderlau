import firebase from 'firebase'

const firebaseConfig = {
    apiKey: "AIzaSyAUcjdMRgVF1IjWunGUJijiA5iWb9x_STE",
    authDomain: "slack-clone-challenge-f3c3f.firebaseapp.com",
    projectId: "slack-clone-challenge-f3c3f",
    storageBucket: "slack-clone-challenge-f3c3f.appspot.com",
    messagingSenderId: "823516192636",
    appId: "1:823516192636:web:8c9df1a9de774a2b85cef9"
};

const firebaseApp = firebase.initializeApp(firebaseConfig)
const db = firebaseApp.firestore();

export default db; //gonna use db anywhere