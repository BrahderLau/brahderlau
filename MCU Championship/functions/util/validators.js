const { body } = require('express-validator');

const isEmail = (email) => {
  const regEx = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  if(email.match(regEx)) return true;
  else return false;
}

const isEmpty = (string) => {
  if(string.trim() === '') return true;//check if user submits an empty field with space
  else return false;
}

exports.userCreationValidators = [
  
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

 exports.validateLoginCredentials = (data) => {
    let errors = {};
  
    if(isEmpty(data.email)) {
      errors.email = 'Email must not be empty'
    } else if(!isEmail(data.email)){
      errors.email = 'Must be a valid email address'
    }
    if(isEmpty(data.password)) errors.password = 'Password must not be empty'

    return {
        errors,
        valid: Object.keys(errors).length === 0 ? true : false
    }
 }