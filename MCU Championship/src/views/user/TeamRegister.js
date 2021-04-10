import React, { useState, useRef } from "react";
import db, { storage,auth } from "../../firebase.js";
import { Formik, Form, Field, ErrorMessage } from "formik";
import * as Yup from "yup";
import swal from 'sweetalert';
import { Autocomplete } from '@material-ui/lab'
import { TextField, Button, Slider } from '@material-ui/core'
import Cropper from 'react-easy-crop'
// import getCroppedImg from '../../components/ImageUtil/cropImage.js'

function MyTeam() {

    const validationSchema = Yup.object().shape({
        teamName: Yup.string()
          .required( '*Team Name Is Required')
          .min(2, '*Team Name Must Have At Least 2 Characters')
          .max(20, "*Team Name Can't Be Longer Than 20 Charcters") 
          .label('teamName'),
        teamFounder: Yup.string()
        .required( '*Team Founder Is Required')
        .min(2, '*Team Founder Must Have At Least 2 Characters')
        .max(50, "*Team Founder Can't Be Longer Than 50 Charcters") 
        .label('teamFounder'),
    });

    const initialValues = {
        teamName: "",
        teamFounder: "",
      };
    
    const teamLogo = "http://turniir.ee/sites/default/files/teamimages/default-logo.png"

    const inputRef = useRef();
    
    const triggerFileSelectPopup = () => inputRef.current.click();
    
    const [image, setImage] = useState(null);
    const [croppedArea, setCroppedArea] = useState(null);
    const [crop, setCrop] = useState({ x:0, y:0 })
    const [zoom, setZoom] = useState(1)
    const [isOpen, setIsOpen] = useState(false)

    const onCropComplete = (croppedAreaPercentage, croppedAreaPixels) => {
        console.log(croppedAreaPercentage, croppedAreaPixels)
        setCroppedArea(croppedAreaPixels);

    }

    const onSelectFile = (event) => {
        if(event.target.files && event.target.files.length > 0) {
            setIsOpen(!isOpen);
            const reader = new FileReader()
            reader.readAsDataURL(event.target.files[0])
            reader.addEventListener("load", () => {
                console.log(reader.result);
                setImage(reader.result);
            });
        }
        console.log(event)
    }
    
    const teamData = [
        {
            name: "Rafflesia",
        },
        {
            name: "KEA",
        },
        {
            name: "Alturo",
        },
        {
            name: "AXC",
        },
        {
            name: "Lord Revivers",
        },
        {
            name: "Rakyat Catur",
        },
        {
            name: "GotrA",
        },
        {
            name: "DENDAN",
        },
        {
            name: "King Mahkota",
        },
        {
            name: "BTB The Knights",
        },
        {
            name: "The Chaos",
        },
        {
            name: "BeruangPadu Alpha MC",
        },
        {
            name: "KESPOC VET",
        },
        {
            name: "RCGS",
        },
        {
            name: "Bungkus Awal",
        },
        {
            name: "Squad Gagak Hitam",
        },
        {
            name: "WAIBBA",
        },
        {
            name: "ZEG",
        },
        {
            name: "Sundrome",
        },
        {
            name: "PURGE CHESS",
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
        <div className="container mx-auto h-full">
             <div className="flex content-center items-center justify-center h-full">
                <div className="w-full lg:w-full px-4">
                    <div className="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-gray-300 border-0">
                        <div className="rounded-t bg-white mb-0 px-6 py-6"> 
                        {/* py-6  */}
                            <h6 className="text-left text-gray-800 text-xl font-bold">Team Registration</h6>   
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
                                    style={{ width: 210 }}
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
                            
                            <h6 className="text-gray-500 text-sm mt-3 font-bold uppercase mb-4">
                               OR... Create a team
                            </h6>

                            <div className="flex-col flex items-center">                        
                                            
                                <div className="flex-col flex items-center">

                                    <Formik
                                        initialValues={initialValues}
                                        validationSchema={validationSchema}
                                        onSubmit={(values, { setSubmitting, resetForm }) => {
                                            setSubmitting(true);
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
                                                "mb-2 px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                                + (touched.teamName && errors.teamName ? "error" : null)
                                            }
                                            //disabled={!isEdit}
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
                                            htmlFor="teamName"
                                        >
                                            Team Founder
                                        </label>
                                        <Field
                                            name="teamFounder"
                                            type="text"
                                            className={
                                                "mb-2 px-3 py-3 placeholder-gray-400 text-gray-700 bg-white rounded text-sm shadow focus:outline-none focus:shadow-outline w-full ease-linear transition-all duration-150"
                                                + (touched.teamFounder && errors.teamFounder ? "error" : null)
                                            }
                                            //disabled={!isEdit}
                                            //value={values.teamFounder}
                                            placeholder="Team Founder"
                                            onChange={handleChange}
                                            onBlur={handleBlur}
                                        />
                                        <ErrorMessage 
                                            name="teamFounder" 
                                            component="div" 
                                            className= "block text-red-500 text-xs font-bold mb-2 py-2"
                                        />

                                        <div>
                                            {
                                                image ?
                                                <>
                                                    <div>
                                                        <Cropper 
                                                            image={image} 
                                                            crop={crop} 
                                                            zoom={zoom} 
                                                            aspect={1} 
                                                            onCropChange={setCrop} 
                                                            onZoomChange={setZoom} 
                                                            onCropComplete={onCropComplete}
                                                        />
                                                    </div>
                                                </>
                                                : null
                                            }
                                        </div>

                                        <div className="container-buttons">
                                            {
                                                !image ?
                                                    <div>
                                                        <Button
                                                            variant="contained"
                                                            component="label"
                                                            color="primary"
                                                        >
                                                            <i className="fas fa-camera mr-2 text-white"></i>
                                                            Upload Team Logo
                                                            <input
                                                                type="file"
                                                                hidden
                                                                //name="file"
                                                                accept="image/*"
                                                                ref={inputRef}
                                                                onChange={onSelectFile}
                                                            />
                                                        </Button>  
                                                    </div>
                                                : null
                                            }
                                        </div>
                                        {
                                            
                                            image ?
                                                <div className="subcontainer-buttons">
                                                    <div className="slider">
                                                        <Slider 
                                                            min={1} 
                                                            max={3} 
                                                            step={0.1} 
                                                            value={zoom}
                                                            onChange={(e,zoom)=> setZoom(zoom)} 
                                                        />
                                                    </div>
                                                    <div>
                                                        <Button
                                                            variant="contained"
                                                            component="label"
                                                            color="primary"
                                                            style={{ marginRight: "10px" }}
                                                        >
                                                            Confirm
                                                        </Button>
                                                        <Button
                                                            variant="contained"
                                                            component="label"
                                                            color="primary"
                                                            onClick={() => setImage()}
                                                        >
                                                            Cancel
                                                        </Button>
                                                    </div>
                                                </div>
                                            : null
                                        }
                                        
                                        {!image ?
                                            <div className="align-middle justify-center flex mt-6">
                                                <button
                                                    className="bg-gray-900 text-white active:bg-blue-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none ease-linear transition-all duration-150"
                                                    type="button"
                                                >
                                                    Create Team
                                                </button>  
                                            </div>
                                            : null
                                        }    
                                    </Form>    
                                    )}
                                </Formik>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    );
}

export default MyTeam
