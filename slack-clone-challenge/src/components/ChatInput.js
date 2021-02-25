import React from 'react'
import styled from 'styled-components'
import SendIcon from '@material-ui/icons/Send';
import { shortcutButton, messageLeftBarButtons, messageRightBarButtons } from '../data/MessageButtons'
import Tooltip from "@material-ui/core/Tooltip";

function ChatInput() {
    return (
        <Container>
            <InputContainer>
                <MessageInput>  
                    <form>
                        <input type="text" placeholder="Message # Channel 1" />
                        <SendButton>
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
    border-bottom: 1px solid rgb(83, 39, 83,.13);
`

const SendButton = styled.div`
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
        background: rgb(83, 39, 83,.13);
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
        background: rgb(245,245,245);
    }
    padding-left: 3px;
    padding-right: 3px;
    margin-left: 5px;
    margin-right: 5px;
`


const RightMessageBar = styled.div`
    display: flex;
`

const LeftMessageButton = styled.div`
    :hover {
        background: rgb(245,245,245);
    }
    padding-left: 3px;
    padding-right: 3px;
    margin-left: 5px;
    margin-right: 5px;
`

const RightMessageButton = styled.div`
    :hover {
        background: rgb(245,245,245);
    }
    padding-left: 3px;
    padding-right: 3px;
    margin-left: 5px;
    margin-right: 5px;
`

// styled.span

// styled.p

// styled.div

// styled.button