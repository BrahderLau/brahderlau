import React from 'react'
import styled from 'styled-components'
import InfoIcon from '@material-ui/icons/Info'

function Chat() {
    return (
        <Container>
            <ChannelHeaderContainer>
                <ChannelContainer>
                    <ChannelTitle>
                        # Channel 1
                    </ChannelTitle>
                    <ChannelDescription>
                        This is the first channel
                    </ChannelDescription>
                </ChannelContainer>
                <ChannelDetailContainer>
                    <div>
                        Details
                    </div>
                    <InfoIconButton>
                        <InfoIcon />
                    </InfoIconButton>          
                </ChannelDetailContainer>

            </ChannelHeaderContainer>
            <MainChatContainer>

            </MainChatContainer>
        </Container>
    )
}

export default Chat

const Container = styled.div`
    background: white;
`

const ChannelHeaderContainer = styled.div`
    height: 64px;
    display: flex;
    align-items: center;
    padding-left: 19px;
    justify-content: space-between;
    border-bottom: 1px solid rgb(220,220,220);
`

const ChannelContainer = styled.div`
    
`

const ChannelTitle = styled.div`
    font-weight: bold;
`

const ChannelDescription = styled.div`

`

const ChannelDetailContainer = styled.div`
    display: flex;
    align-items: center;
    margin-right: 19px;
`

const InfoIconButton = styled.div`
    margin-left: 16px;
    margin-top: 5px;
    cursor: pointer;
`

const MainChatContainer = styled.div`

`
