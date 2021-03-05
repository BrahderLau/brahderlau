import React, { useState } from "react";
import { Switch, Route, Redirect } from "react-router-dom";

// components

//import AdminNavbar from "components/Navbars/AdminNavbar.js";
import Sidebar from "components/Sidebar/Sidebar.js";
import HeaderStats from "components/Headers/HeaderStats.js";
import Footer from "components/Footers/Footer.js"

// views

import Home from "views/Home.js";
import Login from "views/auth/Login.js"
import Register from "views/auth/Register.js"

import LiveMatch from "views/match/LiveMatch.js"
import Schedule from "views/match/Schedule.js"
// import Dashboard from "views/team/Dashboard.js";
// import Maps from "views/team/Maps.js";
// import Settings from "views/team/Settings.js";
import Leaderboard from "views/team/Leaderboard.js";
import TeamList from "views/team/TeamList.js";

import TopScorer from "views/player/TopScorer.js";
import PlayerList from "views/player/PlayerList.js";

import Profile from "views/user/Profile.js";
import MyTeam from "views/user/MyTeam.js";

import NewMatch from "views/admin/CreateMatch.js"
import MatchList from "views/admin/MatchList.js"
import ManageUser from "views/admin/ManageUser.js"
import ManageTeam from "views/admin/ManageTeam.js"

export default function Main() {

  const [user, setUser] = useState(JSON.parse(localStorage.getItem('user')))

  return (
    <div>
      <Sidebar user={user}/>
      <div className="relative md:ml-64 bg-gray-700">
        
        {/* Header */}
        <HeaderStats />
        <div className="px-4 py-4 md:px-10 mx-auto w-full -m-24 bg-yellow-200 ">
          <Switch>
            <Route path="/home" exact component={Home} />
            <Route path="/auth/login" exact component={Login} />
            <Route path="/auth/register" exact render={() => <Register setUser={setUser} />} />
            <Route path="/match/live" exact component={LiveMatch} />
            <Route path="/match/schedule" exact component={Schedule} />
            <Route path="/team/leaderboard" exact component={Leaderboard} />
            <Route path="/team/team-list" exact component={TeamList} />
            <Route path="/player/top-scorer" exact component={TopScorer} />
            <Route path="/player/player-list" exact component={PlayerList} />
            <Route path="/user/profile" exact component={Profile} />
            <Route path="/user/myteam" exact component={MyTeam} />
            <Route path="/admin/create-match" exact component={NewMatch} />
            <Route path="/admin/match-list" exact component={MatchList} />
            <Route path="/admin/manage-user" exact component={ManageUser} />
            <Route path="/admin/manage-team" exact component={ManageTeam} />
            <Redirect to="/home" />
          </Switch>
          <Footer/>
        </div>
      </div>
    </div>
  );
}
