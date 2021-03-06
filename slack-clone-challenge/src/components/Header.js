import React, { useState } from 'react'
import styled from "styled-components"
import AccessTimeIcon from '@material-ui/icons/AccessTime'
import HelpOutlineIcon from '@material-ui/icons/HelpOutline'
import Toggle from "./Toggler"

function Header( {user, signOut, theme, themeToggler} ) { //destructuring
    
    return (
        //You can name anything you want other than container
        <Container>
            <Main>
                <ToggleButton>
                    <Toggle theme={theme} toggleTheme={themeToggler} />
                    {/* <DarkTheme light={lightTheme} dark={darkTheme} />
                    {/* <DarkModeToggle
                        onChange={setIsDarkMode}
                        checked={isDarkMode}
                        size={50} 
                    /> */}
                </ToggleButton>
                <AccessTimeIcon />
                <SearchContainer>
                    <Search>
                        <input type="text" placeholder="Search..." />
                    </Search>
                </SearchContainer>
                <HelpOutlineIcon />
            </Main>
            <UserContainer>
                <Name>
                    {user.name}
                </Name>
                <UserImage onClick={signOut}>
                    <img src={user.photo ? user.photo : "https://i.imgur.com/6VBx3io.png"} />
                </UserImage>
            </UserContainer>
        </Container>
    )
}

export default Header

const Container = styled.div`
    //background: #350d36;
    display: flex;
    align-items: center;
    justify-content: center;
    position: relative;
    z-index: 10px;
    box-shadow: 0 1px 0 0 rgb(255 255 255 / 10%);
    border-bottom: 1px solid #606060;
`

const Main = styled.div`
    display: flex;
    margin-right: 16px;
    margin-left: 16px;
`

const SearchContainer = styled.div`
    min-width: 400px;
    margin-left: 16px;
    margin-right: 16px;
`

const Search = styled.div`
    box-shadow: inset 0 0 0 1px #606060;// rgb(104 74 104);
    width: 100%;
    border-radius: 6;
    display: flex;
    align-items: center;

    input {
        background-color: transparent;
        border: none;
        padding-left: 8px;
        padding-right: 8px;
        color: #606060;
        padding-top: 4px;
        padding-bottom: 4px;
    }

    input:focus { //remove border when search input is clicked
        outline: none;
    }
`
const UserContainer = styled.div`
    display: flex;
    align-items: center;
    padding-right: 16px;
    position: absolute; //absolute means it will always be there no matter what (ignore parent container's position)
    right: 0;
    //padding means inside (the amount of space given outside of the elements)
    //margin means outside (the amount of space from the outside (pushing things outside))
`

const Name = styled.div`
    padding-right: 16px;
`

const UserImage = styled.div`
    width: 28px;
    height: 28px;
    border: 2px solid white;
    border-radius: 3px;
    cursor: pointer;

    img {
        width: 100%
    }
`
const ToggleButton = styled.div`
    position: absolute;
    left: 0;
    margin-left: 15px;
`
