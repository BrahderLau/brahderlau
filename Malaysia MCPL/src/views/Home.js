import React from 'react'
//import styled from 'styled-components'

export default function Home() {
    return (
        <>
            <div className={
                "relative flex flex-col min-w-0 break-words w-full mb-12 rounded" +
                "bg-white"
                }
            >
                <div className="img-slider">
                    <div className ="slider-container">
                        <div className ="slide">
                            <img
                                alt="..."
                                //src={require("assets/img/home_bg_compressed.jpg")}
                                src={require("assets/img/home_bg_compressed_resized.png")} 
                            />   
                        </div>
                        <div className = "slide">
                            <img
                                alt="..."
                                src={require("assets/img/SCHEDULE_WEEK2_1.jpg")}
                                //src={require("assets/img/home_bg_compressed.png")} 
                            />   
                        </div>
                        <div className = "slide">
                            <img
                                alt="..."
                                src={require("assets/img/SCHEDULE_WEEK2_2.jpg")}
                                //src={require("assets/img/home_bg_compressed.png")} 
                            />   
                        </div>                
                    </div>
                </div>
            </div>
        </>

    )
}


