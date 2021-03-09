import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter, Route, Switch, Redirect } from "react-router-dom";

import "@fortawesome/fontawesome-free/css/all.min.css";
import "assets/styles/tailwind.css";

// layouts

import Main from "layouts/Main.js";

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
      <Redirect to="/home" />
    </Switch>
  </BrowserRouter>,
  document.getElementById("root")
);
