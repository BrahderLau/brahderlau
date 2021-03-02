import './App.css';
import { useEffect, useState } from 'react'
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom'
import Chat from './components/Chat'
import Login from './components/Login'
import Header from './components/Header'
import Sidebar from './components/Sidebar'
import db, { auth } from './firebase'
import styled from 'styled-components'
import {ThemeProvider} from 'styled-components'
import { GlobalStyles } from "./components/GlobalStyles"
import { lightTheme, darkTheme } from "./components/Themes"
import { useDarkMode } from "./components/useDarkMode"

function App() {

  const [rooms, setRooms] = useState([])
  const [user, setUser] = useState(JSON.parse(localStorage.getItem('user')))
  const [theme, themeToggler, mountedComponent] = useDarkMode();

  const themeMode = theme === 'light' ? lightTheme : darkTheme;

  const getChannels = () => {
    db.collection('rooms').onSnapshot((snapshot) => {
      setRooms(snapshot.docs.map((doc) => {
        return { id: doc.id, name: doc.data().name }
      }))
    })
  }
  
  const signOut = () => {
    auth.signOut().then(()=>{
      localStorage.removeItem('user');
      setUser(null);
    })
  }

  useEffect(() => {
    getChannels();
    // return () => {
    //   ///clean up
    // }
  }, [])

  if(!mountedComponent) return <div/>

  return (
        <div className={`App`}>
          <Router>
            {
              !user ?
              <Login setUser={setUser}/>
              :
              <ThemeProvider theme={themeMode}>
              <>
              <GlobalStyles/>
              <Container>
                <Header signOut={signOut} user={user} theme={theme} themeToggler={themeToggler} />
                <Main>
                  {/* You can pass data between the components. */}
                  <Sidebar rooms={rooms}/> 
                    {/* from App.js */}

                  <Switch>
                    <Route path="/room/:channelId">
                      {/* Chat components */}
                      <Chat user={user}/>
                    </Route>
                    <Route path="/">
                      <Home>
                        <Title>
                          Welcome to Slack Clone
                        </Title>
                        <Subtitle>
                          + Select or Create Channels
                        </Subtitle>

                      </Home>
                    </Route>
                  </Switch>  
                </Main>     
              </Container>
              </>
    </ThemeProvider>
            }
          </Router>
        </div>

  );
}

export default App;

const Container = styled.div`
  width: 100%;
  height: 100vh;
  display: grid; //finding the height
  grid-template-rows: 38px minmax(0, 1fr);//height row#1, height row#2
`
const Main = styled.div` //The main is the container for the sidebar
  display: grid;
  grid-template-columns: 260px auto; //width column#1, width column#2
`
// div is a container

const Home = styled.div`
  width: 100%;
  height: 100vh;
  display: grid;
  grid-template-rows: 100px 50px;
  justify-content: center;
  align-items: center;

`

const Title = styled.div`
    font-size: 50px;
    font-weight: 500;
    display: flex;
`

const Subtitle = styled.div`
    font-size: 30px;
    display: flex;
    justify-content: center;
`


