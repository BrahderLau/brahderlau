import React, { useEffect, useState } from 'react'
import styled from 'styled-components'
import InfoOutlinedIcon from '@material-ui/icons/InfoOutlined';
import ChatInput from './ChatInput'
import ChatMessage from './ChatMessage';
import db from '../firebase'
import { useParams } from 'react-router-dom';
import firebase from 'firebase'

function Chat({ user }) {

    let { channelId } =  useParams(); // it will look at the id in the url
    const [ channel, setChannel ] = useState();
    const [ messages, setMessages ] = useState([]);

    const getMessages = () => {
        db.collection('rooms')
        .doc(channelId)
        .collection('messages')
        .orderBy('timestamp', 'asc')
        .onSnapshot((snapshot)=>{
            let messages = snapshot.docs.map((doc)=>doc.data());
            setMessages(messages);
        })
    }

    const sendMessage = (text) => { //taking input of text
        if(channelId) {
            let payload = { //data of the text messages
                text: text,
                user: user.name,
                userImage: user.photo,
                timestamp: firebase.firestore.Timestamp.now()
            }

            db.collection("rooms").doc(channelId).collection('messages').add(payload);
        }
    }

    const getChannel = () => {
        db.collection('rooms')
        .doc(channelId)
        .onSnapshot((snapshot)=>{ //snapshot is the data about the channel
           setChannel(snapshot.data());
        })
    }

    useEffect(() => {
        getChannel();
        getMessages();
    }, [channelId])

    return (
        <Container>
            <Header>
                <Channel>
                    <ChannelName>
                        # { channel && channel.name}
                    </ChannelName>
                    <ChannelInfo>
                        Sample Channel Info
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
                {
                    messages &&
                    messages.length > 0 && //Check if messages exist
                    messages.map((data, index)=>(
                        <ChatMessage 
                            text={data.text}
                            name={data.user}
                            image={data.userImage}
                            timestamp={data.timestamp}
                            key={index}
                        />
                    ))
                }
            </MessageContainer>
            <ChatInput sendMessage={sendMessage}/>
        </Container>
    )
}

export default Chat

const Container = styled.div`
    display: grid; //grid is going to split the components into three rows.
    grid-template-rows: 64px auto min-content; // first, second(auto because the chat expands), third
    min-height: 0;
`

const Header = styled.div`
    height: 64px;
    display: flex;
    align-items: center;
    padding-left: 20px;
    padding-right: 20px;
    justify-content: space-between;
    border-bottom: 1px solid #606060;//rgb(83, 39, 83,.13);
`

const Channel = styled.div`
    
`

const ChannelName = styled.div`
    font-weight: 700;
`

const ChannelInfo = styled.div`
    font-weight: 400;
    //color: #606060;
    font-size: 13px;
    margin-top: 8px;
`

const ChannelDetails = styled.div`
    display: flex;
    align-items: center;
    //color: #606060;
`

const Info = styled(InfoOutlinedIcon)`
    margin-left: 10px;
    cursor: pointer;
`

const MessageContainer = styled.div`
    display: flex;
    flex-direction: column;
    overflow-y: scroll;
`