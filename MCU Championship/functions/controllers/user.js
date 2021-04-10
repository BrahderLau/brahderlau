const { db, admin, auth } = require('../util/admin')
const { isEmpty, validateLoginCredentials } = require('../util/validators')
const { validationResult } = require('express-validator');

exports.getAllUsers = (req, res) => {
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
}

exports.manualRegister = (req, res) => {
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
      req.body.role = "user";
      req.body.createdAt = new Date().toISOString();
      req.body.uid = uid;
      //req.body.handle = "user";
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
}


exports.manualLogin = (req,res) => {
    const existingUser = {
      email: req.body.email,
      password: req.body.password
    };

    const { valid, errors } = validateLoginCredentials(existingUser)

    if(!valid) return res.status(400).json(errors);
    
    auth.signInWithEmailAndPassword(existingUser.email, existingUser.password)
      .then(data => {
        return data.user.getIdToken();
      })
      .then(token => {
        return res.json({ token });
      })
      .catch(err => {
        console.error(err);
        if(err.code === 'auth/wrong-password'){
          return res.status(403).json({ general: 'Wrong credentials, please try again' });
        } else return res.status(500).json({ error: err.code })
      })
}
  