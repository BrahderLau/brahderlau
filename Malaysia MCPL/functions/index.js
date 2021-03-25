const functions = require("firebase-functions");
const admin = require('firebase-admin')
const firebase = require('firebase');
const app = require('express')();

admin.initializeApp();

const config = {
  apiKey: "AIzaSyC-5jd4AVkW3SOqPv6Cw_W6sawYIJm-wG8",
  authDomain: "malaysia-mcpl.firebaseapp.com",
  projectId: "malaysia-mcpl",
  storageBucket: "malaysia-mcpl.appspot.com",
  messagingSenderId: "350263329449",
  appId: "1:350263329449:web:126dd978d9d4c669889fb8"
};

const firebaseApp = firebase.initializeApp(config)
const db = firebaseApp.firestore();
const auth = firebase.auth();

const { body, validationResult } = require('express-validator');

// const isEmail = (email) => {
//   const regEx = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
//   if(email.match(regEx)) return true;
//   else return false;
// }

// const isEmpty = (string) => {
//   if(string.trim() === '') return true;//check if user submits an empty field with space
//   else return false;
// }

const userCreationValidators = [
  
  body('firstName')
    .notEmpty().withMessage("First name required!")
    .trim() //remove whitespace to check the actual number of characters
    .isLength({min: 2}).withMessage("Minimum 2 characters!")
    .isLength({max: 50}).withMessage("Maximum 50 characters!"),
  body('lastName')
    .notEmpty().withMessage("Last name required!")
    .trim()
    .isLength({min: 2}).withMessage("Minimum 2 characters!")
    .isLength({max: 50}).withMessage("Maximum 50 characters!"),
  body('displayName')
    .notEmpty().withMessage("Display name required!")
    .trim()
    .isLength({min: 2}).withMessage("2 characters!")
    .isLength({max: 20}).withMessage("50 characters!"),
  body('NRIC')
    .notEmpty().withMessage("NRIC required!")
    .isNumeric().withMessage("Numbers only!")
    .isLength({min:12, max: 12}).withMessage("12 numbers only!"),
  body('gender')
    .notEmpty().withMessage("Gender required!"),
  body('DOB')
    .notEmpty().withMessage("DOB required!"),
    //.isISO8601().toDate().withMessage("Invalid date of birth!"),
  body('email')
    .isEmail().withMessage("Email is invalid!"),
  body('password')
    .matches(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).{8,}$/, "i")
    .withMessage('Password should be combination of one uppercase , one lower case, one special char, one digit and min 8 , max 20 char long'),
  body('confirmPassword')
    .notEmpty().withMessage("Confirm password required!")
    .custom((value, { req }) => {
      if (value !== req.body.password) {
          throw new Error('Confirm password does not match');
        }
        // Indicates the success of this synchronous custom validator
        return true;
    })
 ];

//register route
app.post('/manualRegister', userCreationValidators, (req, res) => {
  const errors = validationResult(req);
  if (!errors.isEmpty()) {
    return res.status(400).json({ errors: errors.array() });
  }
  // const newUser = {
  //   firstName: req.body.firstName,
  //   lastName: req.body.lastName,
  //   displayName: req.body.displayName,
  //   NRIC: req.body.NRIC,
  //   gender: req.body.gender,
  //   DOB: req.body.DOB,
  //   email: req.body.email,
  //   password: req.body.password,
  //   confirmPassword: req.body.confirmPassword,
  // }

  // let errors = {};
  // if(isEmpty(newUser.firstName)) errors.firstName = 'First name must not be empty'
  // if(isEmpty(newUser.lastName)) errors.lastName = 'Last name must not be empty'

  // if(!errors.firstName || !errors.lastName) {
  //   newUser.fullName = newUser.firstName + " " + newUser.lastName;
  // }

  // if(isEmpty(newUser.displayName)) errors.displayName = 'Display name must not be empty'
  // if(isEmpty(newUser.NRIC)) errors.NRIC = 'NRIC must not be empty'
  // if(isEmpty(newUser.gender)) errors.gender = 'Gender must not be empty'
  // if(isEmpty(newUser.DOB)) errors.DOB = 'Date of birth must not be empty'

  // if(isEmpty(newUser.email)) {
  //   errors.email = 'Email must not be empty'
  // } else if(!isEmail(newUser.email)){
  //   errors.email = 'Must be a valid email address'
  // }
  // if(isEmpty(newUser.password)) errors.password = 'Password must not be empty'
  // if(newUser.password !== newUser.confirmPassword) errors.confirmPassword = 'Passwords must match';
  // if(isEmpty(newUser.confirmPassword)) errors.confirmPassword = 'Confirm password must not be empty'

  // if(Object.keys(errors).length > 0) return res.status(400).json(errors);
  
  // db.doc(`/user/${newUser.handle}`).get()
  //   .then(doc => {
  //     if (doc.exists) {
  //       return res.status(400).json({ handle: 'this handle is already taken'});
  //     }
  //     else{
  //       return auth
  //       .createUserWithEmailAndPassword(newUser.email, newUser.password);
  //     } 
  //   })
  let token, uid;
  auth
  .createUserWithEmailAndPassword(req.body.email, req.body.password)
  .then((data) => {
    return data.user.getIdToken();
  })
  .then(idToken => {
    token = idToken;
    uid = auth.currentUser.uid;
    req.body.role = "user"
    req.body.createdAt = new Date().toISOString()
    req.body.uid = uid;
    //remove password and confirm password 
    const { password, confirmPassword, ...userData } = req.body;
    console.log(userData)
    return db.doc(`/user/${uid}`).set(userData) ;
  })
  .then(() => {
    return res.status(201).json({ token });
  })
  .catch((err) => {
    console.error(err);
    if (err.code === 'auth/email-already-in-use') {
      return res.status(400).json({ email: 'Email is already in use'})
    }
    else {
      return res.status(500).json({ error: err.code });
    }
  })

})

app.get(`/user`,(req, res) => {

  admin
    .firestore()
    .collection('user')
    .orderBy('createdAt', 'desc')
    .get()
    .then(data => {
      let users = [];
      data.forEach(doc => {
        users.push({
          //uid: doc.id,
          ...doc.data()
        });
      });
      return res.json(users);
    })
    .catch(err => console.error(err));
  //response.send("Hello from Firebase!");
});

app.post(`/teams`,(req, res) => {

  const newTeam = {
    teamName: req.body.teamName,
    teamFounder: req.body.teamFounder,
    createdAt: new Date().toISOString()
  };

  admin.firestore()
    .collection('team')
    .add(newTeam)
    .then(doc => {
      res.json({ message: `document ${doc.id} created successfully`});
    })
    .catch(err => {
      res.status(500).json({ error: 'Something went wrong'})
      console.error(err);
    })
})

// https://baseurl.com/api/

exports.api = functions.region('asia-southeast2').https.onRequest(app);