import firebase from 'firebase'

const prodFirebaseConfig = {
    apiKey: "AIzaSyC-5jd4AVkW3SOqPv6Cw_W6sawYIJm-wG8",
    authDomain: "malaysia-mcpl.firebaseapp.com",
    projectId: "malaysia-mcpl",
    storageBucket: "malaysia-mcpl.appspot.com",
    messagingSenderId: "350263329449",
    appId: "1:350263329449:web:126dd978d9d4c669889fb8"
};

// const devFirebaseConfig = {
//     apiKey: "AIzaSyB8waOFdv3cmJJP7AyKwjy2JBZnmrxZsqA",
//     authDomain: "malaysia-mcpl-dev.firebaseapp.com",
//     projectId: "malaysia-mcpl-dev",
//     storageBucket: "malaysia-mcpl-dev.appspot.com",
//     messagingSenderId: "391792506506",
//     appId: "1:391792506506:web:980019bd6f17c67bf21f73"
// };

const firebaseApp = firebase.initializeApp(prodFirebaseConfig)
const db = firebaseApp.firestore();
const auth = firebase.auth();
const googleProvider = new firebase.auth.GoogleAuthProvider()
googleProvider.addScope('https://www.googleapis.com/auth/user.birthday.read');
googleProvider.addScope('https://www.googleapis.com/auth/user.gender.read');

const facebookProvider = new firebase.auth.FacebookAuthProvider();
facebookProvider.addScope('user_birthday');
facebookProvider.addScope('user_gender');

export {auth, googleProvider, facebookProvider};
export default db; //gonna use db anywhere