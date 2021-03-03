import React from "react";
import { Redirect } from "react-router-dom";

import { AuthConsumer } from "../authContext.js";

const HomePage = () => (
  <AuthConsumer>
    {({ authenticated }) =>
      authenticated ? (
        <Redirect to="/home" />
      ) : (
        <div>
            <Link
              className={
                "text-xs uppercase font-bold block " +
                (window.location.href.indexOf("/auth/login") !== -1
                  ? "text-blue-500 hover:text-blue-600"
                  : "text-gray-800 hover:text-gray-600")
              }
              to="/auth/login"
            >
              <span className="text-white text-sm uppercase font-bold no-underline mr-4" >
                Login
              </span>
            </Link>
            <Link
              className={
                "text-xs uppercase font-bold block " +
                (window.location.href.indexOf("/auth/register") !== -1
                  ? "text-blue-500 hover:text-blue-600"
                  : "text-gray-800 hover:text-gray-600")
              }
              to="/auth/register"
            >
              <span className="text-white text-sm uppercase font-bold no-underline" >
                Register
              </span>
            </Link>
        </div>
      )
    }
  </AuthConsumer>
);

export default HomePage;