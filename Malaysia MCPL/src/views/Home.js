import React from 'react'
import styled from 'styled-components'

export default function Home(color) {
    return (
        <>
            <div
            className={
            "relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded " +
        "bg-white"
            }
            >
                        <Container>
            <img
                alt="..."
                src={require("assets/img/HOME_BG_IMG.jpg")}
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
`



