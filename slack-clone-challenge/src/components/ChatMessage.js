import React from 'react'
import styled from 'styled-components'

function ChatMessage() {
    return (
        <Container>
            <UserAvatar>
                <img src="https://brahderlau.netlify.app/static/media/brahderlauPotraitNew.92fa9133.png" />
            </UserAvatar>
            <MessageContent>
                <Name>
                    BrahderLau
                    <span>2/23/2021 11:13:55 AM</span>
                </Name>
                <Text>
                    This is the best Challenge
                </Text>
            </MessageContent>
        </Container>
    )
}

export default ChatMessage

const Container = styled.div`
    padding: 8px 20px; //first is vertical padding, second is horizonal padding
    display: flex;
    align-items: center;
    :hover {
        background: #FFFAF0;
    }
`

const UserAvatar = styled.div`
    width: 36px;
    height: 36px;
    border-radius: 2px;
    overflow: hidden;
    
    img {
        width: 100%
    }
`

const MessageContent = styled.div`
    display: flex;
    flex-direction: column;
    padding-left: 8px;
`

const Name = styled.span`
    font-weight: 900;
    font-size: 15px;
    line-height: 1.4;
    span {
        margin-left: 8px;
        font-weight: 400;
        color: rgb(97,96,97);
        font-size: 13px;
    }
`

const Text = styled.span`

`