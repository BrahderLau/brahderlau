import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";

// components

import AdminNavbar from "components/Navbars/AdminNavbar.js";
import Sidebar from "components/Sidebar/Sidebar.js";
import HeaderStats from "components/Headers/HeaderStats.js";
import FooterAdmin from "components/Footers/FooterAdmin.js";

// views

import Dashboard from "views/team/Dashboard.js";
import Maps from "views/team/Maps.js";
import Settings from "views/team/Settings.js";
import Leaderboard from "views/team/Leaderboard.js";
import List from "views/team/List.js";

export default function Main() {
  return (
    <>
      <Sidebar />
      <div className="relative md:ml-64 bg-gray-200">
        <AdminNavbar />
        {/* Header */}
        <HeaderStats />
        <div className="px-4 md:px-10 mx-auto w-full -m-24">
          <Switch>
            <Route path="/team/dashboard" exact component={Dashboard} />
            <Route path="/team/maps" exact component={Maps} />
            <Route path="/team/settings" exact component={Settings} />
            <Route path="/team/leaderboard" exact component={Leaderboard} />
            <Route path="/team/list" exact component={List} />
            <Redirect from="/team" to="/team/dashboard" />
          </Switch>
          <FooterAdmin />
        </div>
      </div>
    </>
  );
}
