import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";

// components

import AdminNavbar from "components/Navbars/AdminNavbar.js";
import Sidebar from "components/Sidebar/Sidebar.js";
import HeaderStats from "components/Headers/HeaderStats.js";
import FooterAdmin from "components/Footers/FooterAdmin.js";
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

import FooterSmall from "components/Footers/FooterSmall.js";

export default function Main() {
  return (
    <div>
      <Sidebar />
      
      <div className="relative md:ml-64 bg-gray-200">
        <AdminNavbar />
        {/* Header */}
        <HeaderStats />
        <div className="px-4 py-4 md:px-10 mx-auto w-full -m-24">
          <Switch>
            <Route path="/" exact component={Home} />
            <Route path="/auth/login" exact component={Login} />
            <Route path="/auth/register" exact component={Register} />
            <Route path="/team/leaderboard" exact component={Leaderboard} />
            <Route path="/team/list" exact component={TeamList} />
            <Redirect from="/team" to="/" />
          </Switch>
          <Footer/>
        </div>
      </div>
    </div>
  );
}
