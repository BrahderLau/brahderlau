import React, { useState, useEffect } from "react";
import db, { storage,auth } from "../../../src/firebase.js";
import { Formik, Form, Field, ErrorMessage } from "formik";
import * as Yup from "yup";
import swal from 'sweetalert';

function Profile() {

  const [isEdit, setIsEdit] = useState(false);
  const [initialValues, setInitialValues] = useState({})
  // eslint-disable-next-line
  const passwordRegExp = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})/

//   const FILE_SIZE = 160 * 1024;
  
//   const SUPPORTED_FORMATS = [
//       "image/jpg",
//       "image/jpeg",
//       "image/gif",
//       "image/png"
//   ];
    
  const validationSchema = Yup.object().shape({
    // file: Yup
    //     .mixed()
    //     .nullable()
    //     .test(
    //         'fileSize', 
    //         "File Size is too large", 
    //         (value) => !value || (value && value.size <= FILE_SIZE)
    //     )
    //     .test(
    //         'fileFormat',
    //         'Unsupported file type',
    //         (value) => !value || (value => value && SUPPORTED_FORMATS.includes(value.type))
    //     ),
    displayName: Yup
        .string()
        .required( '*Display Name Is Required')
        .min(2, '*Display Name Must Have At Least 2 Characters')
        .max(20, "*Display Name Can't Be Longer Than 20 Charcters") 
        .label('displayName'),
    fullName: Yup
        .string()
        .required( '*Full Name Is Required')
        .min(2, '*Full Name Must Have At Least 2 Characters')
        .max(50, "*Full Name Can't Be Longer Than 50 Charcters") 
        .label('fullName'),
    firstName: Yup
        .string()
        .required( '*First Name Is Required')
        .min(2, '*First Name Must Have At Least 2 Characters')
        .max(50, "*First Name Can't Be Longer Than 50 Charcters") 
        .label('firstName'),
    lastName: Yup
        .string()
        .required( '*Last Name Is Required')
        .min(2, '*Last Name Must Have At Least 2 Characters')
        .max(50, "*Last Name Can't Be Longer Than 50 Charcters") 
        .label('lastName'),
    NRIC: Yup.string()
        .required( '*NRIC Is Required')
        .min(12, '*NRIC Must Be Exactly 12 Numbers')
        .max(12, '*NRIC Must Be Exactly 12 Numbers') 
        .label('NRIC'),
    gender: Yup.string()
        //.required( 'Gender Is Required')
        .label('gender'),
    DOB: Yup.date()
        //.required ( 'Date Of Birth Is Required')
        .nullable()
        .max(new Date(), "*Date Can't Be Later Than Today")
        .label('DOB'),
    // email: Yup.string()
    //     .required( '*Email Is Required')
    //     .email( '*Email Is Invalid')
    //     .label('*email'),
    contactNumber: Yup.string()
        //.required( 'Contact Number Is Required')
        .min(10, '*Contact Number Must Be At Least 10 Numbers')
        .max(11, "*Contact Number Can't Be More Than 11 Numbers")
        .label('contactNumber'),
    location: Yup.string()
        .min(2, '*Location Must Have At Least 2 Characters')
        .label('contactNumber'),
    IGN: Yup.string()
        .min(2, '*Account IGN Must Have At Least 2 Characters')
        .max(20, "*Account IGN Can't Be Longer Than 20 Charcters") 
        .label('accountIGN'),
    accountId: Yup.string()
        .min(6, '*Account Server Must Be At Least 6 Numbers')
        .max(12, "*Account Server Can't Be More Than 12 Numbers")
        .label('accountId'),
    accountServer: Yup.string()
        .min(4, '*Account Server Must Be Eaxct 4 Numbers')
        .max(4, "*Account Server Must Be Exaft 4 Numbers")
        .label('accountServer'),
  });

  const genderGroup = [
    //{label: "", value: "Select Gender"},
    {label: "male", value: "male"},
    {label: "female", value: "female"}
  ]

  const getMe = async () => {
    auth.onAuthStateChanged(async(user) => {
        if(user){
            await db.collection("user")
            .doc(auth.currentUser.uid)
            .get()
            .then(async(doc) => {
                if(doc.exists){
                    let meData = doc.data();
                    //process DOB format from firebase
                    if (meData.DOB) { 
                        if(meData.DOB.includes("/")){
                            const [year, month, day] =  meData.DOB.split('/')
                            const newDOB = [day, year, month].join('-')
                            meData.DOB = newDOB              
                        }
                    }

                    //set the data to the initial values of form
                    await setInitialValues({ 
                        displayName: meData.displayName ? meData.displayName:"" ,
                        fullName: meData.fullName ? meData.fullName:"",
                        firstName: meData.firstName ? meData.firstName:"",
                        lastName: meData.lastName ? meData.lastName:"",
                        NRIC: meData.NRIC ? meData.NRIC:"",
                        DOB: meData.DOB ? meData.DOB:"",
                        gender: meData.gender ? meData.gender:"",
                        email: meData.email ? meData.email:"",
                        contactNumber: meData.contactNumber ? meData.contactNumber:"",
                        location: meData.location ? meData.location: "",
                        profilePicture: meData.profilePicture ? meData.profilePicture:"",
                        IGN: meData.IGN ? meData.IGN:"",
                        accountId: meData.accountId ? meData.accountId:"",
                        accountServer: meData.accountServer ? meData.accountServer:"",
                    })    
                }
            })
            // .then(() => {
            //     // db.collection("user")
            //     // .doc(auth.currentUser.uid)
            //     // .collection('playerStats')
            //     // .limit(1)
            //     // .get()
            //     // .then((query) => {
            //     //     //query.size;
            //     // })
            // })  
            .catch((error) => {
                swal({
                  title: error.code,
                  text: error.message,
                  icon: "error",
                })
            });
        }
    })
  }

  const saveProfile = (userData) => {
      const path = `${auth.currentUser.uid}`///${userData.profilePicture.name}`
      const fileRef = storage.ref("images/users").child(path);
      const uploadTask = fileRef.put(userData.profilePicture);
      uploadTask.on(
          "stage_changed",
          snapshot => {},
          error => {
            swal({
                title: error.code,
                text: error.message,
                icon: "error",
            })
          },
          () => {
              storage
                .ref("images/users")
                .child(path)
                .getDownloadURL()
                .then(url => {
                    userData.profilePicture = url;
                    var data = JSON.parse(localStorage.getItem('user'));
                    data.profilePicture = userData.profilePicture;
                    localStorage.setItem('user', JSON.stringify(data));
                    postData(userData)
                })
                .catch((error) => {
                    swal({
                      title: error.code,
                      text: error.message,
                      icon: "error",
                    })
                });
          }
      )
  }

  const postData = async (userData) => {
    let docId
    await db.collection("user")
    .doc(auth.currentUser.uid)
    .get()
    .then((doc) => {
         docId = doc.id
    })
    .then(async()=>{
        db.collection("user")
        .doc(docId)
        .update(userData)
        .then(()=>{
          swal({
              title: "Successful",
              text: "Profile Updated Successful!",
              icon: "success",
            })
            .then(()=>{
              window.location.reload();
            })
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

  const editOnClick = (event) => {
      event.preventDefault()
      setIsEdit(true)   
  }

  const cancelOnClick = (event) => {
    event.preventDefault()
    setIsEdit(false)
}

  useEffect(()=>{   
    getMe()
    return () => { };
}, [])

  return (
    <>
        <Formik
            initialValues={initialValues}
            enableReinitialize
            validationSchema={validationSchema}
            onSubmit={(values, { setSubmitting, resetForm }) => {
                saveProfile(values);
                setSubmitting(true);
                // updateProfile(values);
                // setTimeout(() => {
                //     resetForm();
                //     setSubmitting(false);
                // }, 500);
            }}
            // onReset={(values, { setSubmitting, resetForm}) => {
            //     console.log(values)
            // }}
        >   
            {( {
                values,
                errors, 
                touched, 
                isValid, 
                dirty,
                handleChange,
                handleReset,
                handleSubmit,
                handleBlur,
                setFieldValue,
                isSubmitting  
            }) => (
                <Form onSubmit={handleSubmit}>
                    <div className="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-gray-200 border-0">
                        <div className="rounded-t bg-white mb-0 px-6 py-6">
                            <div className="text-center flex justify-between">
                                <h6 className="text-gray-800 text-xl font-bold">My Account</h6>
                                <div>
                                    {
                                        !isEdit
                                        ?
                                            <button
                                                className="mb-2 bg-gray-900 text-white active:bg-blue-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-4 ease-linear transition-all duration-150"
                                                type="button"
                                                onClick={editOnClick}
                                            >
                                                Edit Profile
                                            </button>
                                        :
                                            <button
                                                className="mb-2 bg-gray-900 text-white active:bg-blue-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-4 ease-linear transition-all duration-150"
                                                type="reset"
                                                onClick={(e) =>{
                                                    handleReset()
                                                    cancelOnClick(e)
                                                }}
                                            >
                                                Cancel
                                            </button>
                                    }
                                    
                                    <button
                                        className="bg-gray-900 text-white active:bg-blue-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none ease-linear transition-all duration-150"
                                        type="button"
                                    >
                                        Change Password
                                    </button>
                                </div>          
                            </div>
                        </div>

                        <div className="flex-col px-4 lg:px-10 py-10 pt-0">
             
                        <div className="w-full justify-center flex flex-col align-middle items-center mt-6">        
                            <img
                                alt="Avatar"
                                src={initialValues.profilePicture? initialValues.profilePicture : "https://devshift.biz/wp-content/uploads/2017/04/profile-icon-png-898-450x450.png"}
                                className="shadow-xl rounded-full h-auto align-middle border-none max-w-150-px"
                            />

                            <a href="#Pablo" title="User Profile">
                                {isEdit ?
                                    <div className="flex flex-col items-center align-middle justify-center">
                                        {/* <i className="fas fa-camera mt-4 hover:text-gray-600 flex items-center">
                                            <span className="px-2 text-xs uppercase py-3 font-bold block"> 
                                               
                                            </span>
                                        </i> */}
                                        <label
                                            className="py-3 block uppercase text-gray-700 text-xs font-bold mb-2"
                                            htmlFor="profilePicture"
                                        >
                                            <i className="fas fa-camera mr-2"></i>
                                            <span>Upload Profile Picture</span>
                                        </label>
                                        <Field 
                                            type="file"
                                            name="file"
                                            onChange={(event) =>{
                                                event.preventDefault();
                                                let imageFile = event.target.files[0];
                                                if(imageFile) {
                                                    setFieldValue("profilePicture", imageFile);
                                                }
                                            }}
                                            className={
                                                "pl-16 placeholder-gray-400 text-gray-700 text-sm focus:outline-none w-full ease-linear transition-all duration-150"
                                            }
                                        />
                                        {/* <ErrorMessage 
                                            name="file" 
                                            component="div" 
                                            className= "block text-red-500 text-xs font-bold mb-2 py-2"
                                        /> */}
                                    </div>
                                    
                                    
                                    :
                                    <></>
                                }
                                
                            </a>
                        </div>
                        
                        <h6 className="text-gray-500 text-sm mt-3 mb-6 font-bold uppercase">
                            User Information
                        </h6>
                        
                        <div className="flex flex-wrap">
                            
                            <div className="w-full lg:w-6/12 px-4">
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
                                        className={
                                            "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                            + (touched.displayName && errors.displayName ? "error" : null)
                                        }
                                        disabled={!isEdit}
                                        value={values.displayName}
                                        placeholder="Display Name"
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                    />
                                    <ErrorMessage 
                                        name="displayName" 
                                        component="div" 
                                        className= "block text-red-500 text-xs font-bold mb-2 py-2"
                                    />
                                </div>
                            </div>

                            <div className="w-full lg:w-6/12 px-4">
                                <div className="relative w-full mb-3">
                                    <label
                                        className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                        htmlFor="fullName"
                                    >
                                        Full Name
                                    </label>
                                    <Field
                                        name="fullName"
                                        type="text"
                                        className={
                                            "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                            + (touched.fullName && errors.fullName ? "error" : null)
                                        }
                                        disabled={!isEdit}
                                        value={values.fullName}
                                        placeholder="Full Name"
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                    />
                                    <ErrorMessage 
                                        name="fullName" 
                                        component="div" 
                                        className= "block text-red-500 text-xs font-bold mb-2 py-2"
                                    />
                                </div>
                            </div>
                        
                            <div className="w-full lg:w-6/12 px-4">
                                <div className="relative w-full mb-3">
                                    <label
                                        className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                        htmlFor="firstName"
                                    >
                                        First Name
                                    </label>
                                    <Field
                                        name="firstName"
                                        type="text"
                                        className={
                                            "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                            + (touched.firstName && errors.firstName ? "error" : null)
                                        }
                                        disabled={!isEdit}
                                        value={values.firstName}
                                        placeholder="First Name"
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                    />
                                    <ErrorMessage 
                                        name="firstName" 
                                        component="div" 
                                        className= "block text-red-500 text-xs font-bold mb-2 py-2"
                                    />
                                </div>
                            </div>
                            
                            <div className="w-full lg:w-6/12 px-4">
                                <div className="relative w-full mb-3">
                                    <label
                                        className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                        htmlFor="lastName"
                                    >
                                        Last Name
                                    </label>
                                    <Field
                                        name="lastName"
                                        type="text"
                                        className={
                                            "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                            + (touched.lastName && errors.lastName ? "error" : null)
                                        }
                                        disabled={!isEdit}
                                        value={values.lastName}
                                        placeholder="Last Name"
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                    />
                                    <ErrorMessage 
                                        name="lastName" 
                                        component="div" 
                                        className= "block text-red-500 text-xs font-bold mb-2 py-2"
                                    />
                                </div>
                            </div>

                            <div className="w-full lg:w-6/12 px-4">
                                <div className="relative w-full mb-3">
                                    <label
                                        className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                        htmlFor="NRIC"
                                    >
                                        NRIC
                                    </label>
                                    <Field
                                        name="NRIC"
                                        type="text"
                                        className={
                                            "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                            + (touched.NRIC && errors.NRIC ? "error" : null)
                                        }
                                        disabled={!isEdit}
                                        value={values.NRIC}
                                        placeholder="NRIC"
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                    />
                                    <ErrorMessage 
                                        name="NRIC" 
                                        component="div" 
                                        className= "block text-red-500 text-xs font-bold mb-2 py-2"
                                    />
                                </div>
                            </div>
                            
                            <div className="w-full lg:w-6/12 px-4">
                                <div className="relative w-full mb-3">
                                    <label
                                        className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                        htmlFor="Gender"
                                    >
                                        Gender
                                    </label>
                                    {
                                        !isEdit
                                        ? (
                                            <Field
                                                name="gender"
                                                type="text"
                                                className={
                                                    "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                                    + (touched.gender && errors.gender ? "error" : null)
                                                }
                                                disabled={!isEdit}
                                                value={values.gender}
                                                //placeholder={values.gender === "" ? "Select A Gender" : values.gender}
                                                onChange={handleChange}
                                                onBlur={handleBlur}
                                            />)
                                        : (
                                            <Field
                                                name="gender"
                                                component="select"
                                                className="px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                                value={values.gender}
                                                //placeholder={values.gender === "" ? "Select A Gender" : values.gender}
                                                onChange={handleChange}
                                                onBlur={handleBlur}
                                            >
                                                {genderGroup.map(group => (
                                                <option key={group.label} value={group.value}>
                                                    {group.value}
                                                </option>
                                                ))}
                                            </Field>
                                        )
                                    }
                                    
                                    <ErrorMessage 
                                        name="gender" 
                                        component="div" 
                                        className= "block text-red-500 text-xs font-bold mb-2 py-2"
                                    />
                                </div>
                            </div>
                            
                            <div className="w-full lg:w-6/12 px-4">
                                <div className="relative w-full mb-3">
                                    <label
                                        className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                        htmlFor="Gender"
                                    >
                                        Date of Birth
                                    </label>
                                    <Field 
                                        name="DOB"
                                        type="date"
                                        className={
                                            "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                            + (touched.DOB && errors.DOB ? "error" : null)
                                        }
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                        disabled={!isEdit}
                                        value={values.DOB}
                                    />
                                    <ErrorMessage 
                                        name="DOB" 
                                        component="div" 
                                        className= "block text-red-500 text-xs font-bold mb-2 py-2"
                                    />
                                </div>
                            </div>
                            
                            <div className="w-full lg:w-6/12 px-4">
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
                                        className={
                                            "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                            + (touched.email && errors.email ? "error" : null)
                                        }
                                        disabled={true}
                                        value={values.email}
                                        placeholder="Email"
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                    />
                                    <ErrorMessage 
                                        name="email" 
                                        component="div" 
                                        className= "block text-red-500 text-xs font-bold mb-2 py-2"
                                    />
                                </div>
                            </div>
                            
                            <div className="w-full lg:w-6/12 px-4">
                                <div className="relative w-full mb-3">
                                    <label
                                        className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                        htmlFor="contactNumber"
                                    >
                                        Contact Number
                                    </label>
                                    <Field
                                        name="contactNumber"
                                        type="tel"
                                        className={
                                            "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                            + (touched.contactNumber && errors.contactNumber ? "error" : null)
                                        }
                                        disabled={!isEdit}
                                        value={values.contactNumber}
                                        placeholder="Contact Number"
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                    />
                                    <ErrorMessage 
                                        name="contactNumber" 
                                        component="div" 
                                        className= "block text-red-500 text-xs font-bold mb-2 py-2"
                                    />
                                </div>
                            </div>

                            <div className="w-full lg:w-6/12 px-4">
                                <div className="relative w-full mb-3">
                                    <label
                                        className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                        htmlFor="location"
                                    >
                                        Location
                                    </label>
                                    <Field
                                        name="location"
                                        type="text"
                                        className={
                                            "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                            + (touched.location && errors.location ? "error" : null)
                                        }
                                        disabled={!isEdit}
                                        value={values.location}
                                        placeholder="Location"
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                    />
                                    <ErrorMessage 
                                        name="location" 
                                        component="div" 
                                        className= "block text-red-500 text-xs font-bold mb-2 py-2"
                                    />
                                </div>
                            </div>
                        </div>
                        
                        <hr className="mt-6 border-b-1 border-gray-400" />

                        <h6 className="text-gray-500 text-sm mt-3 mb-6 font-bold uppercase">
                            Player Information
                        </h6>

                        <div className="flex flex-wrap">
                            <div className="w-full lg:w-4/12 px-4">
                                <div className="relative w-full mb-3">
                                    <label
                                        className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                        htmlFor="IGN"
                                    >
                                        Account In-Game Name (IGN)
                                    </label>
                                    <Field
                                        name="IGN"
                                        type="text"
                                        className={
                                            "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                            + (touched.IGN && errors.IGN ? "error" : null)
                                        }
                                        disabled={!isEdit}
                                        value={values.IGN}
                                        placeholder="Account In-Game Name"
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                    />
                                    <ErrorMessage 
                                        name="IGN" 
                                        component="div" 
                                        className= "block text-red-500 text-xs font-bold mb-2 py-2"
                                    />
                                </div>
                            </div>

                            <div className="w-full lg:w-4/12 px-4">
                                <div className="relative w-full mb-3">
                                    <label
                                        className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                        htmlFor="accountId"
                                    >
                                        Account ID
                                    </label>
                                    <Field
                                        name="accountId"
                                        type="text"
                                        className={
                                            "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                            + (touched.accountId && errors.accountId ? "error" : null)
                                        }
                                        disabled={!isEdit}
                                        value={values.accountId}
                                        placeholder="Account ID"
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                    />
                                    <ErrorMessage 
                                        name="accountId" 
                                        component="div" 
                                        className= "block text-red-500 text-xs font-bold mb-2 py-2"
                                    />
                                </div>
                            </div>
                            <div className="w-full lg:w-4/12 px-4">
                                <div className="relative w-full mb-3">
                                    <label
                                        className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                        htmlFor="accountServer"
                                    >
                                        Account Server
                                    </label>
                                    <Field
                                        name="accountServer"
                                        type="text"
                                        className={
                                            "px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                            + (touched.accountServer && errors.accountServer ? "error" : null)
                                        }
                                        disabled={!isEdit}
                                        value={values.accountServer}
                                        placeholder="Account Server"
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                    />
                                    <ErrorMessage 
                                        name="accountServer" 
                                        component="div" 
                                        className= "block text-red-500 text-xs font-bold mb-2 py-2"
                                    />
                                </div>
                            </div>
                        </div>

                        <hr className="mt-6 border-b-1 border-gray-400" />

                        <h6 className="text-gray-500 text-sm mt-3 mb-6 font-bold uppercase">
                            Player Stats
                        </h6>

                        <div className="flex flex-wrap">

                            <div className="w-full lg:w-6/12 px-4">
                                <div className="relative w-full mb-3">
                                    <label
                                        className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                        htmlFor="grid-password"
                                    >
                                        Team Name
                                    </label>
                                    <input
                                        type="text"
                                        className="px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                        disabled={true}  
                                        placeholder="N/A"                                
                                    />
                                </div>
                            </div>

                            <div className="w-full lg:w-6/12 px-4">
                                <div className="relative w-full mb-3">
                                    <label
                                        className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                        htmlFor="grid-password"
                                    >
                                       Current Ranking
                                    </label>
                                    <input
                                        type="text"
                                        className="px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                        disabled={true}
                                        placeholder="N/A"          
                                    />
                                </div>
                            </div>
                            
                            <div className="w-full lg:w-6/12 px-4">
                                <div className="relative w-full mb-3">
                                    <label
                                        className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                        htmlFor="grid-password"
                                    >
                                        Games Played
                                    </label>
                                    <input
                                        type="text"
                                        className="px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                        disabled={true}  
                                        placeholder="N/A"                                           
                                    />
                                </div>
                            </div>

                            <div className="w-full lg:w-6/12 px-4">
                                <div className="relative w-full mb-3">
                                    <label
                                        className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                        htmlFor="grid-password"
                                    >
                                        Games Won
                                    </label>
                                    <input
                                        type="text"
                                        className="px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                        disabled={true}  
                                        placeholder="N/A"                                          
                                    />
                                </div>
                            </div>

                            <div className="w-full lg:w-6/12 px-4">
                                <div className="relative w-full mb-3">
                                    <label
                                        className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                        htmlFor="grid-password"
                                    >
                                        In-Game Score (IGS)
                                    </label>
                                    <input
                                        type="text"
                                        className="px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                        disabled={true}
                                        placeholder="N/A"          
                                    />
                                </div>
                            </div>

                            <div className="w-full lg:w-6/12 px-4">
                                <div className="relative w-full mb-3">
                                    <label
                                        className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                        htmlFor="grid-password"
                                    >
                                        Player Value
                                    </label>
                                    <input
                                        type="text"
                                        className="px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                        disabled={true}  
                                        placeholder="N/A"                                          
                                    />
                                </div>
                            </div>

                        </div>

                        {/* <hr className="mt-6 border-b-1 border-gray-400" /> */}

                        {/* <h6 className="text-gray-500 text-sm mt-3 mb-6 font-bold uppercase">
                            About Me
                        </h6>
                        <div className="flex flex-wrap">
                            <div className="w-full lg:w-12/12 px-4">
                                <div className="relative w-full mb-3">
                                <label
                                    className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                    htmlFor="grid-password"
                                >
                                    About me
                                </label>
                                <textarea
                                    type="text"
                                    className="px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                    //defaultValue="A beautiful UI Kit and Admin for React & Tailwind CSS. It is Free and Open Source."
                                    disabled={isDisabled}
                                    rows="4"
                                ></textarea>
                                </div>
                            </div>
                        </div> */}
                            <div className="text-center mt-6">
                                {isEdit ?
                                    <button
                                        className= {
                                            "bg-gray-900 text-white active:bg-gray-700 text-sm font-bold uppercase px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 w-1/4 ease-linear transition-all duration-150"
                                            + (dirty && isValid ? "" : "disabled-btn")
                                        }
                                        disabled={!(dirty && isValid) && isSubmitting}
                                        type="submit"
                                    >
                                        Save
                                    </button>
                                    :
                                    <></>
                                }
                            </div>
                        </div>
                    </div>
                </Form>    
            )}
        </Formik>
    </>
  );
}

export default Profile