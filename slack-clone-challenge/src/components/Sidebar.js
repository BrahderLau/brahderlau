import React from 'react'
import styled from 'styled-components'
import AddCircleOutlineIcon from '@material-ui/icons/AddCircleOutline';
import { sidebarItemsData } from '../data/SidebarData'
import AddIcon from '@material-ui/icons/Add';
import DeleteIcon from '@material-ui/icons/Delete';
import db from '../firebase'
import { useHistory } from 'react-router-dom'
import { green } from '@material-ui/core/colors';

//history allows us to go from one page to another page and so forth.

function Sidebar(props) {

    const history = useHistory();

    const goToChannel = (id) => {
        if (id){
            console.log(id);
            history.push(`/room/${id}`) //this will give a link to uniquely identify these channels.
        }
    }
    const addChannel = () => {
        const promptName = prompt("Enter Channel name");
        if(promptName){
            db.collection('rooms').add({
                name: promptName
            })
        }
    }

    return (
        <Container>
            <WorkspaceContainer>
                <AppInfo>
                    <Logo>
                        <img src="http://assets.stickpng.com/images/5cb480cd5f1b6d3fbadece79.png" />
                    </Logo>
                    <Name>
                        Slack Clone
                    </Name>
                </AppInfo>
                <NewMessage>
                    <AddCircleOutlineIcon/>
                </NewMessage>
            </WorkspaceContainer>
            <MainChannels>
                {
                    //looping every single main navigation items
                    sidebarItemsData.map(item => (
                        <MainChannelItem>
                            {item.icon}
                            {item.text}
                        </MainChannelItem>
                    ))
                }
            </MainChannels>
            <ChannelsContainer>
                <ChannelAction>
                    <div>
                        Channels
                    </div>
                    <DeleteChannel>
                        <DeleteIcon onClick={DeleteChannel}/>
                    </DeleteChannel>
                    <NewChannel>
                        <AddIcon onClick={addChannel}/>
                    </NewChannel>
                </ChannelAction> 
                <ChannelsList>
                    {
                        //looping every single main channel items
                        // channelItemsData.map(item => (
                        //     <Channel>
                        //         {item.title}
                        //     </Channel>
                        // ))
                        props.rooms.map(item => (
                            <Channel onClick={()=>goToChannel(item.id)}>
                                # {item.name}
                            </Channel>
                        ))
                    }
                </ChannelsList>
            </ChannelsContainer>
        </Container>
    )
}

export default Sidebar

const Container = styled.div`
    //background: #3F0E40;
    border-right: 1px solid #606060;
`

const WorkspaceContainer = styled.div`
    //color: white;
    height: 64px;
    display: flex;
    align-items: center;
    padding-left: 19px;
    justify-content: space-between;
    border-bottom: 1px solid #606060;// #532753;
`

const Name = styled.div`
    margin-left: 10px;
`

const NewMessage = styled.div`
    width: 36px;
    height: 36px;
    //background: white;
    //color: #3F0E40;
    fill: #3F0E40;
    display: flex;
    justify-content: center;
    align-items: center;
    border-radius: 50%; // 50% means 50% of the whole width / full concanve
    margin-right: 20px;
    cursor: pointer;
`

const MainChannels = styled.div`
    padding-top: 20px;
    padding-bottom: 20px;
    border-bottom: 1px solid #606060;// #532753;
`

const MainChannelItem = styled.div`
    //color: rgb(188,177,188);
    display: grid;
    grid-template-columns: 15% auto;
    height: 28px;
    align-items: center;
    padding-left: 19px;
    cursor: pointer;
    :hover {
        background: #ffa500;//#350D36;
    }
`

const ChannelsContainer = styled.div`
    //color: rgb(188,171,188);
    margin-top: 10px;
`

const ChannelAction = styled.div`
    display: flex;
    justify-content: space-between;
    align-items: center;
    height: 28px;
    padding-left: 19px;
    padding-right: 12px;
`

const ChannelsList = styled.div`

`

const Channel = styled.div`
    height: 28px;
    display: flex;
    align-items: center;
    padding-left: 19px;
    cursor: pointer;
    :hover {
        background: #ffa500;//#350D36;
    }
`
const NewChannel = styled.div`
    cursor: pointer;
    :hover {
        background: #ffa500;//#350D36;
    }
    padding-top: 5px;
`

const DeleteChannel = styled.div`
    cursor: pointer;
    :hover {
        background: #ffa500;//#350D36;
    }
    padding-top: 5px;
    margin-left: 108px;
`

const Logo = styled.div`
    width: 28px;
    height: 28px;


    img {
        width: 100%
    }
    
`

const AppInfo = styled.div`
    display: flex;
    align-items: center;
`