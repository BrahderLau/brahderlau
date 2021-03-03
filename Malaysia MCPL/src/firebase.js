import firebase from 'firebase'

const firebaseConfig = {
    apiKey: "AIzaSyC-5jd4AVkW3SOqPv6Cw_W6sawYIJm-wG8",
    authDomain: "malaysia-mcpl.firebaseapp.com",
    projectId: "malaysia-mcpl",
    storageBucket: "malaysia-mcpl.appspot.com",
    messagingSenderId: "350263329449",
    appId: "1:350263329449:web:126dd978d9d4c669889fb8"
};

const firebaseApp = firebase.initializeApp(firebaseConfig)
const db = firebaseApp.firestore();
const auth = firebase.auth();
const googleProvider = new firebase.auth.GoogleAuthProvider();
//const facebookProvider = new firebase.auth.facebookProvider();

export {auth, googleProvider};
export default db; //gonna use db anywhere