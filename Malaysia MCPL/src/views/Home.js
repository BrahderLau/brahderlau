import React from 'react'
import styled from 'styled-components'

export default function Home(color) {
    return (
        <>
            <div
                className={
                    "relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded" +
                    "bg-white"
                }
            >
                <Container>
                    <img
                        alt="..."
                        //src={require("assets/img/BG_EXAMPLE.jpg")}
                        src={require("assets/img/home_bg_compressed.png")}
                        
                    />                 
                </Container>
            </div>
        </>

    )
}

const Container = styled.div`
    display: flex;
    align-items: center;
    justify-content: center;
    //padding-top: 132px;
`



