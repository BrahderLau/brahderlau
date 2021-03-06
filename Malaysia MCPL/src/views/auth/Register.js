import React from "react";
// import { Link } from "react-router-dom";
import { Formik, Form, Field, ErrorMessage } from "formik";
import * as Yup from "yup";
import db, {auth, googleProvider, facebookProvider} from "../../../src/firebase.js";
import { useHistory } from 'react-router-dom'
import { Select, MenuItem } from '@material-ui/core'
import swal from 'sweetalert';
//import axios from 'axios';

export default function Register(props) {

  const history = useHistory(); 

  // eslint-disable-next-line
  const passwordRegExp = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})/

  const validationSchema = Yup.object().shape({
    firstName: Yup.string()
      .required( 'First Name Is Required')
      .min(2, 'First Name Must Have At Least 2 Characters')
      .max(50, "First Name Can't Be Longer Than 50 Charcters") 
      .label('firstName'),
    lastName: Yup.string()
      .required( 'Last Name Is Required')
      .min(2, 'Last Name Must Have At Least 2 Characters')
      .max(50, "Last Name Can't Be Longer Than 50 Charcters") 
      .label('lastName'),
    displayName: Yup.string()
      .required( 'Display Name Is Required')
      .min(2, 'Display Name Must Have At Least 2 Characters')
      .max(20, "Display Name Can't Be Longer Than 20 Charcters") 
      .label('displayName'),
    gender: Yup.string()
      .required( 'Gender Is Required')
      .label('gender'),
    DOB: Yup.date()
      .required ( 'Date Of Birth Is Required')
      .nullable()
      .max(new Date(), "Date Can't Be Later Than Today")
      .label('DOB'),
    email: Yup.string()
      .required( 'Email Is Required')
      .email( 'Email Is Invalid')
      .label('Email'),
    password: Yup.string()
      .required( 'Password Is Required')
      .matches(passwordRegExp, "Password Must Contain 8 Characters, One Uppercase, One Lowercase, One Number and One Special Case Character")
      .label('Password'),
    confirmPassword: Yup.string()
      .oneOf([Yup.ref('password')], 'Confirm Password Does Not Match With Password')
      .required('Confirm Password Is Required')
      .label('confirmPassword'),
  });

  const initialValues = {
    firstName: "",
    lastName: "",
    displayName: "",
    email: "",
    gender: "",
    DOB: "",
    password: "",
    confirmPassword: ""
  };

  //When manually registered...
  const manualRegister = async (user) => {
    await auth.createUserWithEmailAndPassword(user.email, user.password)
    .then(async(userCredential) => {
      // Signed in 
      var user = userCredential.user;
      //create user
      user.fullName = user.firstName + " " + user.lastName;
      user.role = "user";
      //remove password and confirmPassword
      const { password,confirmPassword, ...userData } = user;
      db.collection("user").add({
          firstName: userData.firstName,
          lastName: userData.lastName,
          fullName: userData.fullName,
          displayName: userData.displayName,
          email: userData.email,
          gender: userData.gender,
          DOB: userData.DOB,
          role: "user"   
        }).then(()=>{
          const newUser = {
            displayName: userData.displayName,
            role: userData.role
          }
          //save in a state
          props.setUser(newUser);
          //save in a local storage ; cookies is used for communication between backend and frontend in the server
          localStorage.setItem('user', JSON.stringify(newUser));

          swal({
            title: "Successful",
            text: "Account created successful!",
            icon: "success",
          })
          .then(()=>{
            history.push(`/home`)
          })
      })
    })
    .catch((error) => {
      if(error.code === "auth/email-already-in-use"){
        error.message += " Please proceed with login."
      }
      swal({
        title: error.code,
        text: error.message,
        icon: "error",
      })
    });
  };

  //When register using GOOGLE or FACEBOOK...
  const thirdPartyRegister = (e, provider) => {
    // Step 1.
    // User tries to sign in to Facebook.
    e.preventDefault();
    if (provider === "facebook") {
      auth.signInWithPopup(facebookProvider).then(async (result) => {
        let userInfo = result.additionalUserInfo;
        if (userInfo.isNewUser === true) {
          const { email, name, first_name, last_name, gender, birthday, picture} = userInfo.profile;
          await db.collection('user')
          .add({
            uid: auth.currentUser.uid,
            firstName: first_name,
            lastName: last_name,
            fullName: name,
            displayName: first_name,
            email: email,
            gender: gender,
            DOB: birthday,
            profilePicture: picture.data.url,
            role: "user"        
          })
          .then(() =>{
            const newUser = {
              displayName: first_name,
              profilePicture: picture.data.url,
              role: "user"
            }
            //save in a state
            props.setUser(newUser);
            //save in a local storage ; cookies is used for communication between backend and frontend in the server
            localStorage.setItem('user', JSON.stringify(newUser));
            swal({
              title: "Successful",
              text: "Account created successful!",
              icon: "success",
            })
            .then(()=>{
              history.push(`/home`)
            })
            .catch((error) => {
              swal({
                title: error.code,
                text: error.message,
                icon: "error",
              })
            });
          })
          .catch((error) => {
            swal({
              title: error.code,
              text: error.message,
              icon: "error",
            })
          });
        }
        else {
          await db.collection('user')
          .where("uid", "==", auth.currentUser.uid)
          .get()
          .then((querySnapshot) => {
            querySnapshot.forEach((doc) => {
                // doc.data() is never undefined for query doc snapshots
              const {displayName, profilePicture, role} = doc.data();
              const existingUser = {
                displayName: displayName,
                profilePicture: profilePicture,
                role: role
              }
              //save in a state
              props.setUser(existingUser);
              //save in a local storage ; cookies is used for communication between backend and frontend in the server
              localStorage.setItem('user', JSON.stringify(existingUser));
              swal({
                title: "Successful",
                text: "Account Login Successful!",
                icon: "success",
              })
              .then(()=>{
                history.push(`/home`)
              })
              .catch((error) => {
                swal({
                  title: error.code,
                  text: error.message,
                  icon: "error",
                })
              });
            });
          })
        }
        
      })
      .catch((error) => {
        swal({
          title: error.code,
          text: error.message,
          icon: "error",
        }) 
      });
    }
    else {
      auth.signInWithPopup(googleProvider).then(async (result) => {
        // {
        //   // TO DO: GET BIRTHDAY AND GENDER FROM PEOPLE API
        //   //var token = result.credential.accessToken;
        //   //var userInfo = result.user;
        //   // console.log(userInfo)
        //   // var API = "350263329449-hjed93bupvlminta23i0efcgi4a2ovk9.apps.googleusercontent.com";
        //   // const response = await axios({
        //   //   method: 'GET',
        //   //   headers: {
        //   //     Authorization: `Bearer ${token}`,
        //   //   },
        //   //   url: `https://people.googleapis.com/v1/people/${userInfo.uid}?personFields=genders`,
        //   // })
        //   // .then(()=>{
        //   //   console.log(response); // You should have the info here
        //   // })
        //   // .catch((error)=>{
        //   //   swal({
        //   //     title: error.code,
        //   //     text: error.message,
        //   //     icon: "error",
        //   //   })
        //   // })
        // }
        let userInfo = result.additionalUserInfo;
        if (userInfo.isNewUser === true) {
          const { email, name, family_name, given_name, picture} = userInfo.profile;
          await db.collection('user')
          .add({
            firstName: given_name,
            lastName: family_name,
            fullName: name,
            displayName: given_name,
            email: email,
            profilePicture: picture,
            role: "user"        
          })
          .then(() =>{
            const newUser = {
              displayName: given_name,
              profilePicture: picture,
              role: "user"
            }
            //save in a state
            props.setUser(newUser);
            //save in a local storage ; cookies is used for communication between backend and frontend in the server
            localStorage.setItem('user', JSON.stringify(newUser));
            swal({
              title: "Successful",
              text: "Account created successful!",
              icon: "success",
            })
            .then(()=>{
              history.push(`/home`)
            })
            .catch((error) => {
              swal({
                title: error.code,
                text: error.message,
                icon: "error",
              })
            });
          })
          .catch((error) => {
            swal({
              title: error.code,
              text: error.message,
              icon: "error",
            })
          });
        }
        else {
          await db.collection('user')
            .where("uid", "==", auth.currentUser.uid)
            .get()
            .then((querySnapshot) => {
              querySnapshot.forEach((doc) => {
                  // doc.data() is never undefined for query doc snapshots
                const {displayName, profilePicture, role} = doc.data();
                const existingUser = {
                  displayName: displayName,
                  profilePicture: profilePicture,
                  role: role
                }
                //save in a state
                props.setUser(existingUser);
                //save in a local storage ; cookies is used for communication between backend and frontend in the server
                localStorage.setItem('user', JSON.stringify(existingUser));
                swal({
                  title: "Successful",
                  text: "Account Login Successful!",
                  icon: "success",
                })
                .then(()=>{
                  history.push(`/home`)
                })
                .catch((error) => {
                  swal({
                    title: error.code,
                    text: error.message,
                    icon: "error",
                  })
                });
            });
          });
        } 
      })
      .catch((error) => {
        swal({
          title: error.code,
          text: error.message,
          icon: "error",
        }) 
      });
    }
  }

  const registerForm = () => {
    
    return(
      <Formik
        initialValues={initialValues}
        validationSchema={validationSchema}
        onSubmit={(values, { setSubmitting, resetForm }) => {
          setSubmitting(true);
          manualRegister(values);
          setTimeout(() => {
            resetForm();
            setSubmitting(false);
          }, 500);
        }}
      >   
        {( {
            values,
            errors, 
            touched, 
            isValid, 
            dirty,
            handleChange,
            handleSubmit,
            handleBlur,
            isSubmitting
          }) => (
            <Form onSubmit={handleSubmit}> 
              <div className="relative w-full mb-3 flex items-center">
                <label
                  className="block uppercase text-gray-700 text-xs font-bold mb-2"
                  htmlFor="firstName"
                >
                  First Name
                </label>
                <Field 
                  name="firstName"
                  type="text"
                  className= {
                    "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-1/2 ease-linear transition-all duration-150" 
                    + (touched.firstName && errors.firstName ? "error" : null)
                  }
                  placeholder="First Name"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.firstName}
                />
                <label
                  className="block uppercase text-gray-700 text-xs font-bold mb-2 pl-4"
                  htmlFor="firstName"
                >
                  Last Name
                </label>
                <Field 
                  name="lastName"
                  type="text"
                  className= {
                    "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-1/2 ease-linear transition-all duration-150" 
                    + (touched.lastName && errors.lastName ? "error" : null)
                  }
                  placeholder="Last Name"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.lastName}
                />
              </div>
              <div className="relative w-full mb-3 flex-col items-center">
                <ErrorMessage 
                    name="firstName" 
                    component="div" 
                    className= "block text-red-500 text-xs font-bold mb-2 py-2"
                  />
                <ErrorMessage 
                  name="lastName" 
                  component="div" 
                  className= "block text-red-500 text-xs font-bold mb-2 py-2"
                />
              </div>
              <div className="relative w-full mb-3">
                <label
                  className="block uppercase text-gray-700 text-xs font-bold mb-2"
                  htmlFor="displayName"
                >
                  Display Name
                </label>
                <Field 
                  name="displayName"
                  type="text"
                  className= {
                    "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150" 
                    + (touched.displayName && errors.displayName ? "error" : null)
                  }
                  placeholder="Display Name"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.displayName}
                />
                <ErrorMessage 
                  name="displayName" 
                  component="div" 
                  className= "block text-red-500 text-xs font-bold mb-2 py-2"
                />
              </div>
              <div className="relative w-full mb-3">
                <label
                  className="block uppercase text-gray-700 text-xs font-bold mb-2"
                  htmlFor="Gender"
                >
                  Gender
                </label>
                <Select
                  labelId="gender-label"
                  id="gender"
                  name="gender"
                  className= {
                    "px-3 py-2 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150" 
                    + (touched.gender && errors.gender ? "error" : null)
                  }
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.gender}
                  displayEmpty
                >
                  <MenuItem value="" disabled>Select Your Gender</MenuItem>
                  <MenuItem value="Male">Male</MenuItem>
                  <MenuItem value="Female">Female</MenuItem>
                </Select>
                <ErrorMessage 
                  name="gender" 
                  component="div" 
                  className= "block text-red-500 text-xs font-bold mb-2 py-2"
                />
              </div>
              <div className="relative w-full mb-3">
                <label
                  className="block uppercase text-gray-700 text-xs font-bold mb-2"
                  htmlFor="DOB"
                >
                  Date of Birth
                </label>
                <Field 
                  name="DOB"
                  type="date"
                  className= {
                    "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150" 
                    + (touched.DOB && errors.DOB ? "error" : null)
                  }
                  placeholder="First Name"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.DOB}
                />
                <ErrorMessage 
                  name="DOB" 
                  component="div" 
                  className= "block text-red-500 text-xs font-bold mb-2 py-2"
                />
              </div>
              <div className="relative w-full mb-3">
                <label
                  className="block uppercase text-gray-700 text-xs font-bold mb-2"
                  htmlFor="email"
                >
                  Email
                </label>
                <Field 
                  name="email"
                  type="email"
                  className= {
                    "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150" 
                    + (touched.email && errors.email ? "error" : null)
                  }
                  placeholder="Email"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.email}
                />
                <ErrorMessage 
                  name="email" 
                  component="div" 
                  className= "block text-red-500 text-xs font-bold mb-2 py-2"
                />
              </div>
              <div className="relative w-full mb-3">
                <label
                  className="block uppercase text-gray-700 text-xs font-bold mb-2"
                  htmlFor="password"
                >
                  Password
                </label>
                <Field 
                  name="password"
                  type="password"
                  className= {
                    "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150" 
                    + (touched.password && errors.password ? "error" : null)
                  }
                  placeholder="Password"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.password}
                />
                <ErrorMessage 
                  name="password" 
                  component="div" 
                  className= "block text-red-500 text-xs font-bold mb-2 py-2"
                />
              </div>
              <div className="relative w-full mb-3">
                <label
                  className="block uppercase text-gray-700 text-xs font-bold mb-2"
                  htmlFor="confirmPassword"
                >
                  Confirm Password
                </label>
                <Field 
                  name="confirmPassword"
                  type="password"
                  className= {
                    "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150" 
                    + (touched.confirmPassword && errors.confirmPassword ? "error" : null)
                  }
                  placeholder="Confirm Password"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.confirmPassword}
                />
                <ErrorMessage 
                  name="confirmPassword" 
                  component="div" 
                  className= "block text-red-500 text-xs font-bold mb-2 py-2"
                />
              </div>
              <div>
                <label className="inline-flex items-center cursor-pointer">
                  <input
                    id="customCheckLogin"
                    type="checkbox"
                    className="form-checkbox text-gray-800 ml-1 w-5 h-5 ease-linear transition-all duration-150"
                  />
                  <span className="ml-2 text-sm font-semibold text-gray-700">
                    I agree with the{" "}
                    <a
                      href="#pablo"
                      className="text-blue-500"
                      onClick={(e) => e.preventDefault()}
                    >
                      Privacy Policy
                    </a>
                  </span>
                </label>
              </div>
              <div className="text-center mt-6">
                <button
                  className= {
                    "bg-gray-900 text-white active:bg-gray-700 text-sm font-bold uppercase px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 w-full ease-linear transition-all duration-150"
                    + (dirty && isValid ? "" : "disabled-btn")
                  }
                  disabled={!(dirty && isValid) && isSubmitting}
                  type="submit"
                >
                  Create Account
                </button>
              </div>
            </Form>
          )}
      </Formik>
    );
  }

  return (
    <>
      <div className="container mx-auto px-4 h-full">
        <div className="flex content-center items-center justify-center h-full">
          <div className="w-full lg:w-6/12 px-4">
            <div className="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-gray-300 border-0">
              <div className="rounded-t mb-0 px-6 py-6">
                <div className="text-center mb-3">
                  <h6 className="text-gray-600 text-sm font-bold">
                    Sign up with
                  </h6>
                </div>
                <div className="btn-wrapper text-center">
                  <button
                    className="bg-white active:bg-gray-100 text-gray-800 font-normal px-4 py-2 rounded outline-none focus:outline-none mr-1 mb-1 uppercase shadow hover:shadow-md inline-flex items-center font-bold text-xs ease-linear transition-all duration-150"
                    type="button"
                    onClick={(e)=> thirdPartyRegister(e,"google")}
                  >
                    <img
                      alt="..."
                      className="w-5 mr-1"
                      src={require("assets/img/google.svg")}
                    />
                    Google
                  </button>
                  <button
                    className="bg-white active:bg-gray-100 text-gray-800 font-normal px-4 py-2 rounded outline-none focus:outline-none mr-2 mb-1 uppercase shadow hover:shadow-md inline-flex items-center font-bold text-xs ease-linear transition-all duration-150"
                    type="button"
                    onClick={(e)=> thirdPartyRegister(e,"facebook")}
                  >
                    <img
                      alt="..."
                      className="w-5 mr-1"
                      src={require("assets/img/facebook.svg")}
                    />
                    Facebook
                  </button>
                </div>
                <hr className="mt-6 border-b-1 border-gray-400" />
              </div>
              <div className="flex-auto px-4 lg:px-10 py-10 pt-0">
                <div className="text-gray-500 text-center mb-3 font-bold">
                  <small>Or sign up with credentials</small>
                </div>
                {registerForm()}
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
