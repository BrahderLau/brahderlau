import React from 'react'
import { func, string } from 'prop-types';
import styled from "styled-components"

const Button = styled.button`
  background: ${({ theme }) => theme.background};
  border: 2px solid ${({ theme }) => theme.toggleBorder};
  color: ${({ theme }) => theme.text};
  border-radius: 30px;
  cursor: pointer;
  //font-size: 0.5rem;
  padding: 0.2rem;
  outline: none;
`
const Toggle = ({theme,  toggleTheme }) => {
    return (
        <Button onClick={toggleTheme} >
          <ButtonText>
            Switch Theme
          </ButtonText>
        </Button>
    );
};

Toggle.propTypes = {
    theme: string.isRequired,
    toggleTheme: func.isRequired,
}

const ButtonText = styled.span`
  font-size: 13px;
  color: white;
`

export default Toggle;