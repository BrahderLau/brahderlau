import './App.css';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom'
import Chat from './components/Chat'
import Login from './components/Login'
import styled from 'styled-components'
import Header from './components/Header'
import Sidebar from './components/Sidebar'

function App() {
  return (
    <div className="App">
      <Router>
        <Container>
          <Header />
          <Main>
            <Sidebar />

            <Switch>
              <Route path="/room">
                {/* Chat components */}
                <Chat/>
              </Route>
              <Route path="/">
                {/* Login components */}
                <Login/>
              </Route>
            </Switch>  
          </Main>     
        </Container>
      </Router>
    </div>
  );
}

export default App;

const Container = styled.div`
  width: 100%;
  height: 100vh;
  display: grid; //finding the height
  grid-template-rows: 38px auto;//height row#1, height row#2
`
const Main = styled.div` //The main is the container for the sidebar
  // background: blue;
  display: grid;
  grid-template-columns: 260px auto //width column#1, width column#2
`
// div is a container 
