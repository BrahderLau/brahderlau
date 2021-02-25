import React from 'react'
import styled from 'styled-components'
import InfoOutlinedIcon from '@material-ui/icons/InfoOutlined';
import ChatInput from './ChatInput'
import ChatMessage from './ChatMessage';

function Chat() {
    return (
        <Container>
            <Header>

                <Channel>
                    <ChannelName>
                        # Channel 1
                    </ChannelName>
                    <ChannelInfo>
                        This is the first channel
                    </ChannelInfo>
                </Channel>
                <ChannelDetails>
                    <div>
                        Details
                    </div>
                    <Info>
                        <InfoOutlinedIcon />
                    </Info>          
                </ChannelDetails>

            </Header>
            <MessageContainer>
                <ChatMessage />
            </MessageContainer>
            <ChatInput>

            </ChatInput>
        </Container>
    )
}

export default Chat

const Container = styled.div`
    background: white;
    display: grid; //grid is going to split the components into three rows.
    grid-template-rows: 64px auto min-content // first, second(auto because the chat expands), third
`

const Header = styled.div`
    height: 64px;
    display: flex;
    align-items: center;
    padding-left: 20px;
    padding-right: 20px;
    justify-content: space-between;
    border-bottom: 1px solid rgb(83, 39, 83,.13);
`

const Channel = styled.div`
    
`

const ChannelName = styled.div`
    font-weight: 700;
`

const ChannelInfo = styled.div`
    font-weight: 400;
    color: #606060;
    font-size: 13px;
    margin-top: 8px
`

const ChannelDetails = styled.div`
    display: flex;
    align-items: center;
    color: #606060;
`

const Info = styled(InfoOutlinedIcon)`
    margin-left: 10px;
`

const MessageContainer = styled.div`

`