import React, { useState, useEffect } from "react";
import db, { storage,auth } from "../../firebase.js";
import { Formik, Form, Field, ErrorMessage } from "formik";
import * as Yup from "yup";
import swal from 'sweetalert';
import { Autocomplete } from '@material-ui/lab'
import { TextField } from '@material-ui/core'

function MyTeam() {

    const teamData = [
        {
            name: "Rakyat Catur",
            currentRank: 1
        },
        {
            name: "Rafflesia",
            currentRank: 1
        },
        {
            name: "GotrA",
            currentRank: 1
        }
    ]

    const options = teamData.map((option) => {
        const firstLetter = option.name[0].toUpperCase();
        
        return {
          firstLetter: /[0-9]/.test(firstLetter) ? '0-9' : firstLetter,
          ...option,
        };
    });

    return (
        <div className="container mx-auto px-4 h-full">
             <div className="flex content-center items-center justify-center h-full">
                <div className="w-full lg:w-6/12 px-4">
                    <div className="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-gray-300 border-0">
                        <div className="rounded-t bg-white mb-0 px-6 py-6">  
                            <h6 className="text-left text-gray-800 text-xl font-bold">Team Details</h6>   
                        </div>

                        <div className="px-4 lg:px-10 py-10 pt-0 flex-col">      
                            
                            <h6 className="text-gray-500 text-sm mt-3 mb-6 font-bold uppercase">
                                Join a team
                            </h6>

                            <div className="flex-col flex items-center">
                            
                                <Autocomplete
                                    id="grouped-demo"
                                    options={options.sort((a, b) => -b.firstLetter.localeCompare(a.firstLetter))}
                                    className="p-2 mb-2 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150" 
                                    groupBy={(option) => option.firstLetter}
                                    getOptionLabel={(option) => option.name}
                                    clearOnEscape
                                    style={{ width: 300 }}
                                    renderInput={(params) => <TextField {...params} label="Team List" variant="outlined" />}
                                />

                                <button
                                    className="bg-gray-900 text-white active:bg-blue-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none ease-linear transition-all duration-150"
                                    type="button"
                                >
                                    Apply To Join
                                </button>              

                            </div>
                            
                            <hr className="mt-6 border-b-1 border-gray-400" />
                            
                            <h6 className="text-gray-500 text-sm mt-3 mb-6 font-bold uppercase">
                               OR... Create a team
                            </h6>

                            <div className="flex-col flex items-center">
                            
                                <div className="py-16">
                                    <img
                                        alt="..."
                                        src="http://turniir.ee/sites/default/files/teamimages/default-logo.png"
                                        className="shadow-xl rounded-full h-auto align-middle border-none absolute -m-16 -ml-20 lg:-ml-16 max-w-150-px"
                                    />
                                </div>
                        
                           
                        
                                <Formik
                                    //initialValues={initialValues}
                                    //validationSchema={validationSchema}
                                    onSubmit={(values, { setSubmitting, resetForm }) => {

                                    }}
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
                                            
                                            <div className="flex-col flex items-center">
                                            
                                            <label
                                                className="pt-8 block uppercase text-gray-700 text-xs font-bold mb-2"
                                                htmlFor="profilePicture"
                                            >
                                                <i className="fas fa-camera mr-2"></i>
                                                <span>Upload Team Logo</span>
                                            </label>
                                            <Field 
                                                type="file"
                                                name="file"
                                                onChange={(event) =>{
                                                    event.preventDefault();
                                                    let imageFile = event.target.files[0];
                                                    if(imageFile) {
                                                        //setFieldValue("profilePicture", imageFile);
                                                    }
                                                }}
                                                className={
                                                    "pl-10 mb-2 placeholder-gray-400 text-gray-700 text-sm focus:outline-none w-full ease-linear transition-all duration-150"
                                                }
                                            />
                                        
                            
                                            <label
                                                className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                                htmlFor="teamName"
                                            >
                                                Team Name
                                            </label>
                                            <Field
                                                name="teamName"
                                                type="text"
                                                className={
                                                    "px-3 py-3 mb-2 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                                    + (touched.teamName && errors.teamName ? "error" : null)
                                                }
                                                
                                                //value={values.teamName}
                                                placeholder="Team Name"
                                                onChange={handleChange}
                                                onBlur={handleBlur}
                                            />
                                            <ErrorMessage 
                                                name="teamName" 
                                                component="div" 
                                                className= "block text-red-500 text-xs font-bold mb-2 py-2"
                                            /> 

                                                <label
                                                className="block uppercase text-gray-700 text-xs font-bold mb-2"
                                                htmlFor="teamFounder"
                                            >
                                                Team Founder
                                            </label>
                                            <Field
                                                name="teamFounder"
                                                type="text"
                                                className={
                                                    "px-3 py-3 mb-2 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                                    + (touched.teamFounder && errors.teamFounder ? "error" : null)
                                                }
                                                
                                                //value={values.displayName}
                                                placeholder="Team Founder"
                                                onChange={handleChange}
                                                onBlur={handleBlur}
                                            />
                                            <ErrorMessage 
                                                name="teamFounder" 
                                                component="div" 
                                                className= "block text-red-500 text-xs font-bold mb-2 py-2"
                                            /> 
                                            
                                            <button
                                                className="bg-gray-900 text-white active:bg-blue-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none ease-linear transition-all duration-150"
                                                type="button"
                                            >
                                                Create Team
                                            </button>  
                                            </div>
                                        </Form>
                                    )}
                                </Formik>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
      );
}

export default MyTeam
