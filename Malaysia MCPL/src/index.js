import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter, Route, Switch, Redirect } from "react-router-dom";

import "@fortawesome/fontawesome-free/css/all.min.css";
import "assets/styles/tailwind.css";

// layouts

import Main from "layouts/Main.js";
// import Auth from "layouts/Auth.js";

// // views without layouts

// import Landing from "views/Landing.js";
// import Profile from "views/Profile.js";
// import Index from "views/Index.js";

ReactDOM.render(
  <BrowserRouter>
    <Switch>
      {/* add routes with layouts */}
      <Route path="/home" component={Main} />
      <Route path="/auth" component={Main} />
      <Route path="/match" component={Main} />
      <Route path="/team" component={Main} />
      <Route path="/player" component={Main} />
      <Route path="/user" component={Main} />
      <Route path="/admin" component={Main} />
      {/* add routes without layouts */}
      {/* <Route path="/landing" exact component={Landing} />
      <Route path="/profile" exact component={Profile} />
      <Route path="/" exact component={Index} /> */}
      {/* add redirect for first page */}
      <Redirect to="/home" />
    </Switch>
  </BrowserRouter>,
  document.getElementById("root")
);