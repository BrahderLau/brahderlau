import React, { useState } from 'react'
import styled from 'styled-components'
import SendIcon from '@material-ui/icons/Send';
import { shortcutButton, messageLeftBarButtons, messageRightBarButtons } from '../data/MessageButtons'
import Tooltip from "@material-ui/core/Tooltip";

function ChatInput({ sendMessage }) {

    const [input, setInput] = useState("");
    const send = (e) => {
        e.preventDefault(); //prevent refreshing page
        if(!input) return;
        sendMessage(input);
        setInput("");
    }

    return (
        <Container>
            <InputContainer>
                <MessageInput>  
                    <form>
                        <input 
                            onChange={(e)=>setInput(e.target.value)}
                            type="text"
                            value={input}
                            placeholder="Message here..." />
                        <SendButton 
                            type="submit"
                            onClick={send}>
                            <Send />
                        </SendButton>
                    </form>
                </MessageInput>
                <MessageBar>
                    <LeftMessageBar>
                        <ShortcutMessageButton>
                            <Tooltip title={shortcutButton.text}>
                            {shortcutButton.icon}
                            </Tooltip>
                        </ShortcutMessageButton>
                        {
                            messageLeftBarButtons.map(item => (
                                <LeftMessageButton>
                                    
                                    <Tooltip title={item.text}>
                                    {item.icon}
                                    </Tooltip>
                                </LeftMessageButton>
                            ))
                        }
                    </LeftMessageBar>
                    <RightMessageBar>
                        {
                            messageRightBarButtons.map(item => (
                                <RightMessageButton>
                                    
                                    <Tooltip title={item.text}>
                                    {item.icon}
                                    </Tooltip>
                                </RightMessageButton> 
                            ))
                        }
                    </RightMessageBar>  
                </MessageBar>
            </InputContainer>
        </Container>
    )
}

export default ChatInput

const Container = styled.div`
    padding-left: 20px;
    padding-right: 20px;
    padding-bottom: 24px;
`
const InputContainer = styled.div`
    border: 1px solid #808D8E;
    border-radius: 4px;

    form {
        display: flex;
        height: 42px;
        align-items: center;
        padding-left: 10px;
        input {
            flex: 1; //flex 1 means it takes up space as much as it could
            border: none;
            font-size: 13px;
        }

        input:focus {
            outline: none;
        }
    } 
`

const MessageInput = styled.div`
    border-bottom: 1px solid #808D8E;// rgb(83, 39, 83,.13);
`

const SendButton = styled.button`
    background: #007a5a;
    border-radius: 2px;
    width: 32px;
    height: 32px;
    display: flex;
    justify-content: center;
    align-items: center;
    margin-right: 5px;
    cursor: pointer;

    .MuiSvgIcon-root {
        width: 18px;
    }

    :hover {
        background: #ffa500;//rgb(83, 39, 83,.13);
    }
`

const Send = styled(SendIcon)`
    color: #D9D9D9;
`

const MessageBar = styled.div`
    display: flex;
    padding-left: 8px;
    padding-right: 8px;
    padding-top: 8px;
    padding-bottom: 8px;
    align-items: center;
    justify-content: space-between;
`

const LeftMessageBar = styled.div`
    display: flex;
`

const ShortcutMessageButton = styled.div`
    border-right: 1px solid rgb(83, 39, 83,.13);
    :hover {
        background: #ffa500;//rgb(245,245,245);
    }
    padding-left: 3px;
    padding-right: 3px;
    margin-left: 5px;
    margin-right: 5px;
    cursor: pointer;
`


const RightMessageBar = styled.div`
    display: flex;
`

const LeftMessageButton = styled.div`
    :hover {
        background: #ffa500;//rgb(245,245,245);
    }
    padding-left: 3px;
    padding-right: 3px;
    margin-left: 5px;
    margin-right: 5px;
    cursor: pointer;
`

const RightMessageButton = styled.div`
    :hover {
        background: #ffa500;//rgb(245,245,245);
    }
    padding-left: 3px;
    padding-right: 3px;
    margin-left: 5px;
    margin-right: 5px;
    cursor: pointer;
`

// styled.span

// styled.p

// styled.div

// styled.button