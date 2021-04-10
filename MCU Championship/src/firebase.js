import firebase from 'firebase'
import "firebase/storage"

const prodFirebaseConfig = {
    apiKey: "AIzaSyAlKtTA-ehPyFJpdKWNnO99WhTCteHQrQo",
    authDomain: "mcu-championship.firebaseapp.com",
    projectId: "mcu-championship",
    storageBucket: "mcu-championship.appspot.com",
    messagingSenderId: "404712575289",
    appId: "1:404712575289:web:da158380773998c25698e8",
    measurementId: "G-68BYGE6SFG"
};

const devFirebaseConfig = {
    apiKey: "AIzaSyAlKtTA-ehPyFJpdKWNnO99WhTCteHQrQo",
    authDomain: "mcu-championship.firebaseapp.com",
    projectId: "mcu-championship",
    storageBucket: "mcu-championship.appspot.com",
    messagingSenderId: "404712575289",
    appId: "1:404712575289:web:f84f995ef3b592cf5698e8",
    measurementId: "G-ZNE2N19ZTK"
};

const firebaseApp = firebase.initializeApp(devFirebaseConfig)
const db = firebaseApp.firestore();
const storage = firebase.storage();
const auth = firebase.auth();
const googleProvider = new firebase.auth.GoogleAuthProvider()
// googleProvider.addScope('https://www.googleapis.com/auth/user.birthday.read');
// googleProvider.addScope('https://www.googleapis.com/auth/user.gender.read');

const facebookProvider = new firebase.auth.FacebookAuthProvider();
facebookProvider.addScope('user_birthday');
facebookProvider.addScope('user_gender');

export {auth, storage, googleProvider, facebookProvider};
export default db; //gonna use db anywhere
