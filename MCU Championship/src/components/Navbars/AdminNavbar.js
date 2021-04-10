import React from "react";
import { Link } from "react-router-dom";
import { AuthConsumer } from "../../authContext.js"
import UserDropdown from "components/Dropdowns/UserDropdown.js";
import styled from "styled-components";
import Can from "../Can.js";

export default function Navbar() {
  return (
    <>
      {/* Navbar */}
      <nav className="absolute top-0 left-0 w-full z-10 bg-transparent md:flex-row md:flex-no-wrap md:justify-start flex items-center p-4 py-2">
        <div className="w-full mx-auto items-center flex justify-between md:flex-no-wrap md:px-10 px-4">
          {/* Form */}
          {/* <form className="md:flex flex-row flex-wrap items-center lg:ml-auto mr-3">
            <div className="relative flex w-full flex-wrap items-stretch">
              <span className="z-10 h-full leading-snug font-normal absolute text-center text-gray-400 absolute bg-transparent rounded text-base items-center justify-center w-8 pl-3 py-3">
                <i className="fas fa-search"></i>
              </span>
              <input
                type="text"
                placeholder="Search here..."
                className="px-3 py-3 placeholder-gray-400 text-gray-700 relative bg-white bg-white rounded text-sm shadow outline-none focus:outline-none focus:shadow-outline w-full pl-10"
              />
            </div>
          </form> */}
          
          <QuickNav>
            {/* <span className="text-white text-sm uppercase font-bold no-underline mr-4" >
              Navigation: 
            </span> */}
            <Link
              className={
                "text-xs uppercase font-bold block" +
                (window.location.href.indexOf("/home") !== -1
                  ? "text-blue-500 hover:text-blue-600"
                  : "text-gray-800 hover:text-gray-600")
              }
              to="/home"
            >
              <span className="text-white text-sm uppercase font-bold no-underline mr-4" >
                Home
              </span>
            </Link>
            <AuthConsumer>
              {({ user }) => (
                <Can
                role={user.role}
                perform="loginOrRegister:auth"
                no={() => (
                  <AuthNav>
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
                  </AuthNav>
                )}
                // no={() =>
                //   <div>
                //     {/* hide */}
                //   </div>
                // }
                />
              )}
            </AuthConsumer>
            
          </QuickNav>     
          {/* User */}
          <ul className="flex-col md:flex-row list-none items-center hidden md:flex">
            <UserDropdown />
          </ul>
        </div>
      </nav>
      {/* End Navbar */}
    </>
  );
}

const QuickNav = styled.div`
  display: flex;
  padding-top: 6px;
`

const AuthNav = styled.div`
  display: flex;
`