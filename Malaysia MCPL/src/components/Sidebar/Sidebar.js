/*eslint-disable*/
import React, {useEffect, useState} from "react"
import { Link } from "react-router-dom"
import {auth} from "../../../src/firebase.js";
// import { AuthConsumer } from "../../authContext.js"
// import Can from "../Can.js"
import styled from 'styled-components'
//import AdminNavbar from "components/Navbars/AdminNavbar.js";


//import NotificationDropdown from "components/Dropdowns/NotificationDropdown.js";
//import UserDropdown from "components/Dropdowns/UserDropdown.js";


export default function Sidebar({user, setUser}) {

  const [collapseShow, setCollapseShow] = useState("hidden");

  const logOut = () => { 

    auth.signOut().then(()=>{
      swal({
        title: "Are you sure?",
        text: "Are you sure you want to log out?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
      })
      .then((willLogOut) => {
        if (willLogOut) {
          swal("Account Logged Out Successful!", {
            icon: "success",
          });
          setUser(null);
          localStorage.removeItem('user');
          setCollapseShow("hidden");
        }
      });
    })
  }

  return(
    <>
      <nav className="md:left-0 md:block md:fixed md:top-0 md:bottom-0 md:overflow-y-auto md:flex-row md:flex-no-wrap md:overflow-hidden shadow-xl bg-white flex flex-wrap items-center justify-between relative md:w-64 z-10 py-4 px-6">
        <div className="md:flex-col md:items-stretch md:min-h-full md:flex-no-wrap px-0 flex items-center justify-between w-full mx-auto">
          {/* Toggler */}
          <button
            className="cursor-pointer text-black opacity-50 md:hidden px-3 py-1 text-xl leading-none bg-transparent rounded border border-solid border-transparent"
            type="button"
            onClick={() => setCollapseShow("bg-white m-2 py-3 px-6")}
          >
            <i className="fas fa-bars"></i>
          </button>
          {/* Brand */}
          <div className="flex flex-wrap justify-center md:flex-row">
            <span className="text-black font-bold text-base uppercase lg:inline-block font-semibold pb-4">
                Malaysia MCPL (Beta)
            </span> 
            <div className="w-6/12 sm:w-4/12 px-6">
              <img
                src={user && user.profilePicture ? user.profilePicture : "https://devshift.biz/wp-content/uploads/2017/04/profile-icon-png-898-450x450.png"}
                alt="..."
                className="w-full rounded-full align-middle border-none shadow-md"
                >
              </img>
            </div>
              
          </div>
          {/* User */}
          {/* <ul className="md:hidden items-center flex flex-wrap list-none">
            <li className= {
              "inline-block relative"
            }>
              <UserDropdown />
            </li>
          </ul> */}
          {/* Collapse */}
          <div
            className={
              "md:flex md:flex-col md:items-stretch md:opacity-100 md:relative md:mt-4 md:shadow-none shadow absolute top-0 left-0 right-0 z-40 overflow-y-auto overflow-x-hidden h-auto items-center flex-1 rounded " +
              collapseShow              
            }
          >
            {/* Collapse header */}
            <div className="md:min-w-full md:hidden block pb-4 mb-4 border-b border-solid border-gray-300">
              <div className="flex flex-wrap">
                <div className="w-6/12 md:block text-left md:pb-2 text-gray-700 mr-0 inline-block whitespace-no-wrap text-sm uppercase font-bold p-4 px-0 ">
                    Malaysia MCPL (Beta)
                </div>
                
                <div className="w-6/12 flex justify-end">
                  <button
                    type="button"
                    className="cursor-pointer text-black opacity-50 md:hidden px-3 py-1 text-xl leading-none bg-transparent rounded border border-solid border-transparent"
                    onClick={() => setCollapseShow("hidden")}
                  >
                    <i className="fas fa-times"></i>
                  </button>
                </div>
              </div>
            </div>
            {/* Form */}
            {/* <form className="mt-6 mb-4 md:hidden">
              <div className="mb-3 pt-0">
                <input
                  type="text"
                  placeholder="Search"
                  className="px-3 py-2 h-12 border border-solid  border-gray-600 placeholder-gray-400 text-gray-700 bg-white rounded text-base leading-snug shadow-none outline-none focus:outline-none w-full font-normal"
                />
              </div>
            </form> */}

            {/* Divider */}
            {/* <hr className="my-4 md:min-w-full" /> */}
            
            <span className="md:block text-center md:pb-2 text-gray-700 mr-0 inline-block whitespace-no-wrap text-xs font-bold p-4 px-0">
              {user && user.displayName 
              ? `Welcome Back, ${user.displayName}!` 
              : "Welcome, Guest!"}
            </span>

            <ul className="md:flex-col md:min-w-full flex flex-col list-none md:mb-4">
              <li className="items-center">
                <Link
                  onClick={() => setCollapseShow("hidden")}
                  className={
                    "text-xs uppercase py-3 font-bold block " +
                    (window.location.href.indexOf("/home") !== -1
                      ? "text-blue-500 hover:text-blue-600"
                      : "text-gray-800 hover:text-gray-600")
                  }
                  to="/home"
                >
                  <i
                    className={
                      "fas fa-home mr-2 text-sm " +
                      (window.location.href.indexOf("/home") !== -1
                        ? "opacity-75"
                        : "text-gray-500")
                    }
                  ></i>{" "}
                  Home
                </Link>
              </li>
              {
                user 
                ?    
                <>
                  <li className="items-center">
                      <Link
                        onClick={logOut}
                        className={
                          "text-xs uppercase py-3 font-bold block " +
                          (window.location.href.indexOf("/logout") !== -1
                            ? "text-blue-500 hover:text-blue-600"
                            : "text-gray-800 hover:text-gray-600")
                        }
                        to="/logout"
                      >
                        <i
                          className={
                            "fas fa-sign-out-alt mr-2 text-sm " +
                            (window.location.href.indexOf("/logout") !== -1
                              ? "opacity-75"
                              : "text-gray-500")
                          }
                        ></i>{" "}
                        Log Out
                      </Link>
                    </li>
                  </>
                : 
                <>
                  <li className="items-center">
                    <Link
                      onClick={() => setCollapseShow("hidden")}
                      className={
                        "text-xs uppercase py-3 font-bold block " +
                        (window.location.href.indexOf("/auth/login") !== -1
                          ? "text-blue-500 hover:text-blue-600"
                          : "text-gray-800 hover:text-gray-600")
                      }
                      to="/auth/login"
                    >
                      <i
                        className={
                          "fas fa-fingerprint mr-2 text-sm " +
                          (window.location.href.indexOf("/auth/login") !== -1
                            ? "opacity-75"
                            : "text-gray-500")
                        }
                      ></i>{" "}
                      Login
                    </Link>
                  </li>

                  <li className="items-center">
                    <Link
                      onClick={() => setCollapseShow("hidden")}
                      className={
                        "text-xs uppercase py-3 font-bold block " +
                        (window.location.href.indexOf("/auth/register") !== -1
                          ? "text-blue-500 hover:text-blue-600"
                          : "text-gray-800 hover:text-gray-600")
                      }
                      to="/auth/register"
                    >
                      <i
                        className={
                          "fas fa-clipboard mr-2 text-sm " +
                          (window.location.href.indexOf("/auth/register") !== -1
                            ? "opacity-75"
                            : "text-gray-500")
                        }
                      ></i>{" "}
                      Register
                    </Link>
                  </li>
                </>
              }
              
            </ul> 
              {/* <li className="items-center">
                <Link
                  className="text-gray-800 hover:text-gray-600 text-xs uppercase py-3 font-bold block"
                  to="/auth/register"
                >
                  <i className="fas fa-clipboard-list text-gray-500 mr-2 text-sm"></i>{" "}
                  Register
                </Link>
              </li> */}
            

            {/* Divider */}
            <hr className="my-4 md:min-w-full" />
            {/* Heading */}
            <h6 className="md:min-w-full text-gray-600 text-xs uppercase font-bold block pt-1 pb-4 no-underline">
              Match
            </h6>
            {/* Navigation */}

            <ul className="md:flex-col md:min-w-full flex flex-col list-none md:mb-4">
              <li className="items-center">
                <Link
                  onClick={() => setCollapseShow("hidden")}
                  className={
                    "text-xs uppercase py-3 font-bold block " +
                    (window.location.href.indexOf("/match/live") !== -1
                      ? "text-blue-500 hover:text-blue-600"
                      : "text-gray-800 hover:text-gray-600")
                  }
                  to="/match/live"
                >
                  🔴 Live Match            
                </Link>
              </li>

              <li className="items-center">
                <Link
                  onClick={() => setCollapseShow("hidden")}
                  className={
                    "text-xs uppercase py-3 font-bold block " +
                    (window.location.href.indexOf("/match/schedule") !== -1
                      ? "text-blue-500 hover:text-blue-600"
                      : "text-gray-800 hover:text-gray-600")
                  }
                  to="/match/schedule"
                >
                  <i
                    className={
                      "fas fa-calendar-alt mr-2 text-sm " +
                      (window.location.href.indexOf("/match/schedule") !== -1
                        ? "opacity-75"
                        : "text-gray-500")
                    }
                  ></i>{" "}
                  Schedule
                </Link>
              </li>
            </ul>

            {/* Divider */}
            <hr className="my-4 md:min-w-full" />
            {/* Heading */}
            <h6 className="md:min-w-full text-gray-600 text-xs uppercase font-bold block pt-1 pb-4 no-underline">
              Team
            </h6>
            {/* Navigation */}

            <ul className="md:flex-col md:min-w-full flex flex-col list-none">
              {/* <li className="items-center">
                <Link
                  className={
                    "text-xs uppercase py-3 font-bold block " +
                    (window.location.href.indexOf("/admin/dashboard") !== -1
                      ? "text-blue-500 hover:text-blue-600"
                      : "text-gray-800 hover:text-gray-600")
                  }
                  to="/admin/dashboard"
                >
                  <i
                    className={
                      "fas fa-tv mr-2 text-sm " +
                      (window.location.href.indexOf("/admin/dashboard") !== -1
                        ? "opacity-75"
                        : "text-gray-400")
                    }
                  ></i>{" "}
                  Dashboard
                </Link>
              </li> */}

              {/* <li className="items-center">
                <Link
                  className={
                    "text-xs uppercase py-3 font-bold block " +
                    (window.location.href.indexOf("/team/settings") !== -1
                      ? "text-blue-500 hover:text-blue-600"
                      : "text-gray-800 hover:text-gray-600")
                  }
                  to="/team/settings"
                >
                  <i
                    className={
                      "fas fa-tools mr-2 text-sm " +
                      (window.location.href.indexOf("/team/settings") !== -1
                        ? "opacity-75"
                        : "text-gray-400")
                    }
                  ></i>{" "}
                  Settings
                </Link>
              </li> */}

              <li className="items-center">
                <Link
                  onClick={() => setCollapseShow("hidden")}
                  className={
                    "text-xs uppercase py-3 font-bold block " +
                    (window.location.href.indexOf("/team/leaderboard") !== -1
                      ? "text-blue-500 hover:text-blue-600"
                      : "text-gray-800 hover:text-gray-600")
                  }
                  to="/team/leaderboard"
                >
                  <i
                    className={
                      "fas fa-trophy mr-2 text-sm " +
                      (window.location.href.indexOf("/team/leaderboard") !== -1
                        ? "opacity-75"
                        : "text-gray-500")
                    }
                  ></i>{" "}
                  Leaderboard
                </Link>
              </li>

              <li className="items-center">
                <Link
                  onClick={() => setCollapseShow("hidden")}
                  className={
                    "text-xs uppercase py-3 font-bold block " +
                    (window.location.href.indexOf("/team/team-list") !== -1
                      ? "text-blue-500 hover:text-blue-600"
                      : "text-gray-800 hover:text-gray-600")
                  }
                  to="/team/team-list"
                >
                  <i
                    className={
                      "fas fa-users mr-2 text-sm " +
                      (window.location.href.indexOf("/team/team-list") !== -1
                        ? "opacity-75"
                        : "text-gray-500")
                    }
                  ></i>{" "}
                  Team List
                </Link>
              </li>

              {/* <li className="items-center">
                <Link
                  className={
                    "text-xs uppercase py-3 font-bold block " +
                    (window.location.href.indexOf("/admin/maps") !== -1
                      ? "text-blue-500 hover:text-blue-600"
                      : "text-gray-800 hover:text-gray-600")
                  }
                  to="/admin/maps"
                >
                  <i
                    className={
                      "fas fa-map-marked mr-2 text-sm " +
                      (window.location.href.indexOf("/admin/maps") !== -1
                        ? "opacity-75"
                        : "text-gray-400")
                    }
                  ></i>{" "}
                  Maps
                </Link>
              </li> */}
            </ul>

            {/* Divider */}
            <hr className="my-4 md:min-w-full" />
            {/* Heading */}
            <h6 className="md:min-w-full text-gray-600 text-xs uppercase font-bold block pt-1 pb-4 no-underline">
              Player
            </h6>
            {/* Navigation */}

            <ul className="md:flex-col md:min-w-full flex flex-col list-none md:mb-4">
              <li className="items-center">
                <Link
                  onClick={() => setCollapseShow("hidden")}
                  className={
                    "text-xs uppercase py-3 font-bold block " +
                    (window.location.href.indexOf("/player/top-scorer") !== -1
                      ? "text-blue-500 hover:text-blue-600"
                      : "text-gray-800 hover:text-gray-600")
                  }
                  to="/player/top-scorer"
                >
                  <i
                    className={
                      "fas fa-trophy mr-2 text-sm " +
                      (window.location.href.indexOf("/player/top-scorer") !== -1
                        ? "opacity-75"
                        : "text-gray-500")
                    }
                  ></i>{" "}
                  Top Scorer
                </Link>
              </li>

              <li className="items-center">
                <Link
                  onClick={() => setCollapseShow("hidden")}
                  className={
                    "text-xs uppercase py-3 font-bold block " +
                    (window.location.href.indexOf("/player/player-list") !== -1
                      ? "text-blue-500 hover:text-blue-600"
                      : "text-gray-800 hover:text-gray-600")
                  }
                  to="/player/player-list"
                >
                  <i
                    className={
                      "fas fa-user mr-2 text-sm " +
                      (window.location.href.indexOf("/player/player-list") !== -1
                        ? "opacity-75"
                        : "text-gray-500")
                    }
                  ></i>{" "}
                  Player List
                </Link>
              </li>
            </ul>

            {/* Divider */}
            <hr className="my-4 md:min-w-full" />
            {/* Heading */}
            <h6 className="md:min-w-full text-gray-600 text-xs uppercase font-bold block pt-1 pb-4 no-underline">
              User
            </h6>
            {/* Navigation */}

            <ul className="md:flex-col md:min-w-full flex flex-col list-none md:mb-4">

              <li className="items-center">
                <Link
                  onClick={() => setCollapseShow("hidden")}
                  className={
                    "text-xs uppercase py-3 font-bold block " +
                    (window.location.href.indexOf("/user/profile") !== -1
                      ? "text-blue-500 hover:text-blue-600"
                      : "text-gray-800 hover:text-gray-600")
                  }
                  to="/user/profile"
                >
                  <i
                    className={
                      "fas fa-user-edit mr-2 text-sm " +
                      (window.location.href.indexOf("/user/profile") !== -1
                        ? "opacity-75"
                        : "text-gray-500")
                    }
                  ></i>{" "}
                  Profile
                </Link>
              </li>

              <li className="items-center">
                <Link
                  onClick={() => setCollapseShow("hidden")}
                  className={
                    "text-xs uppercase py-3 font-bold block " +
                    (window.location.href.indexOf("/user/myteam") !== -1
                      ? "text-blue-500 hover:text-blue-600"
                      : "text-gray-800 hover:text-gray-600")
                  }
                  to="/user/myteam"
                >
                  <i
                    className={
                      "fab fa-teamspeak mr-2 text-sm " +
                      (window.location.href.indexOf("/user/myteam") !== -1
                        ? "opacity-75"
                        : "text-gray-500")
                    }
                  ></i>{" "}
                  My Team
                </Link>
              </li>
            </ul>
              
            {/* Divider */}
            {/* <hr className="my-4 md:min-w-full" /> */}
            {/* Heading */}
            {/* <h6 className="md:min-w-full text-gray-600 text-xs uppercase font-bold block pt-1 pb-4 no-underline">
              No Layout Pages
            </h6> */}
            {/* Navigation */}
{/* 
            <ul className="md:flex-col md:min-w-full flex flex-col list-none md:mb-4">
              <li className="items-center">
                <Link
                  className="text-gray-800 hover:text-gray-600 text-xs uppercase py-3 font-bold block"
                  to="/landing"
                >
                  <i className="fas fa-newspaper text-gray-500 mr-2 text-sm"></i>{" "}
                  Landing Page
                </Link>
              </li>

              <li className="items-center">
                <Link
                  className="text-gray-800 hover:text-gray-600 text-xs uppercase py-3 font-bold block"
                  to="/profile"
                >
                  <i className="fas fa-user-circle text-gray-500 mr-2 text-sm"></i>{" "}
                  Profile Page
                </Link>
              </li>
            </ul> */}

            {/* Divider */}
            {/* <hr className="my-4 md:min-w-full" /> */}
            {/* Heading */}
            {/* <h6 className="md:min-w-full text-gray-600 text-xs uppercase font-bold block pt-1 pb-4 no-underline">
              Documentation
            </h6> */}
            {/* Navigation */}
            {/* <ul className="md:flex-col md:min-w-full flex flex-col list-none md:mb-4">
              <li className="inline-flex">
                <a
                  href="https://www.creative-tim.com/learning-lab/tailwind/react/colors/notus"
                  target="_blank"
                  className="text-gray-800 hover:text-gray-600 text-sm block mb-4 no-underline font-semibold"
                >
                  <i className="fas fa-paint-brush mr-2 text-gray-400 text-base"></i>
                  Styles
                </a>
              </li>

              <li className="inline-flex">
                <a
                  href="https://www.creative-tim.com/learning-lab/tailwind/react/alerts/notus"
                  target="_blank"
                  className="text-gray-800 hover:text-gray-600 text-sm block mb-4 no-underline font-semibold"
                >
                  <i className="fab fa-css3-alt mr-2 text-gray-400 text-base"></i>
                  CSS Components
                </a>
              </li>

              <li className="inline-flex">
                <a
                  href="https://www.creative-tim.com/learning-lab/tailwind/angular/overview/notus"
                  target="_blank"
                  className="text-gray-800 hover:text-gray-600 text-sm block mb-4 no-underline font-semibold"
                >
                  <i className="fab fa-angular mr-2 text-gray-400 text-base"></i>
                  Angular
                </a>
              </li>

              <li className="inline-flex">
                <a
                  href="https://www.creative-tim.com/learning-lab/tailwind/js/overview/notus"
                  target="_blank"
                  className="text-gray-800 hover:text-gray-600 text-sm block mb-4 no-underline font-semibold"
                >
                  <i className="fab fa-js-square mr-2 text-gray-400 text-base"></i>
                  Javascript
                </a>
              </li>

              <li className="inline-flex">
                <a
                  href="https://www.creative-tim.com/learning-lab/tailwind/nextjs/overview/notus"
                  target="_blank"
                  className="text-gray-800 hover:text-gray-600 text-sm block mb-4 no-underline font-semibold"
                >
                  <i className="fab fa-react mr-2 text-gray-400 text-base"></i>
                  NextJS
                </a>
              </li>

              <li className="inline-flex">
                <a
                  href="https://www.creative-tim.com/learning-lab/tailwind/react/overview/notus"
                  target="_blank"
                  className="text-gray-800 hover:text-gray-600 text-sm block mb-4 no-underline font-semibold"
                >
                  <i className="fab fa-react mr-2 text-gray-400 text-base"></i>
                  React
                </a>
              </li>

              <li className="inline-flex">
                <a
                  href="https://www.creative-tim.com/learning-lab/tailwind/svelte/overview/notus"
                  target="_blank"
                  className="text-gray-800 hover:text-gray-600 text-sm block mb-4 no-underline font-semibold"
                >
                  <i className="fas fa-link mr-2 text-gray-400 text-base"></i>
                  Svelte
                </a>
              </li>

              <li className="inline-flex">
                <a
                  href="https://www.creative-tim.com/learning-lab/tailwind/vue/overview/notus"
                  target="_blank"
                  className="text-gray-800 hover:text-gray-600 text-sm block mb-4 no-underline font-semibold"
                >
                  <i className="fab fa-vuejs mr-2 text-gray-400 text-base"></i>
                  VueJS
                </a>
              </li>
            </ul> */}

            {/* Divider */}
            <hr className="my-4 md:min-w-full" />
            {/* Heading */}
            <h6 className="md:min-w-full text-gray-600 text-xs uppercase font-bold block pt-1 pb-4 no-underline">
              Admin
            </h6>
            {/* Navigation */}

            <ul className="md:flex-col md:min-w-full flex flex-col list-none md:mb-4">
              <li className="items-center">
                <Link
                  onClick={() => setCollapseShow("hidden")}
                  className={
                    "text-xs uppercase py-3 font-bold block " +
                    (window.location.href.indexOf("/admin/create-match") !== -1
                      ? "text-blue-500 hover:text-blue-600"
                      : "text-gray-800 hover:text-gray-600")
                  }
                  to="/admin/create-match"
                >
                  <i
                    className={
                      "fas fa-chess mr-2 text-sm" +
                      (window.location.href.indexOf("/admin/create-match") !== -1
                        ? "opacity-75"
                        : "text-gray-500")
                    }
                  ></i>{" "}
                  New Match
                </Link>
              </li>

              <li className="items-center">
                <Link
                  onClick={() => setCollapseShow("hidden")}
                  className={
                    "text-xs uppercase py-3 font-bold block " +
                    (window.location.href.indexOf("/admin/match-list") !== -1
                      ? "text-blue-500 hover:text-blue-600"
                      : "text-gray-800 hover:text-gray-600")
                  }
                  to="/admin/match-list"
                >
                  <i
                    className={
                      "fas fa-clipboard-list mr-2 text-sm " +
                      (window.location.href.indexOf("/admin/match-list") !== -1
                        ? "opacity-75"
                        : "text-gray-500")
                    }
                  ></i>{" "}
                  Match List
                </Link>
              </li>

              <li className="items-center">
                <Link
                  onClick={() => setCollapseShow("hidden")}
                  className={
                    "text-xs uppercase py-3 font-bold block " +
                    (window.location.href.indexOf("/admin/manage-user") !== -1
                      ? "text-blue-500 hover:text-blue-600"
                      : "text-gray-800 hover:text-gray-600")
                  }
                  to="/admin/manage-user"
                >
                  <i
                    className={
                      "fas fa-users-cog mr-2 text-sm " +
                      (window.location.href.indexOf("/admin/manage-user") !== -1
                        ? "opacity-75"
                        : "text-gray-500")
                    }
                  ></i>{" "}
                  Manage User
                </Link>
              </li>

              <li className="items-center">
                <Link
                  onClick={() => setCollapseShow("hidden")}
                  className={
                    "text-xs uppercase py-3 font-bold block " +
                    (window.location.href.indexOf("/admin/manage-team") !== -1
                      ? "text-blue-500 hover:text-blue-600"
                      : "text-gray-800 hover:text-gray-600")
                  }
                  to="/admin/manage-team"
                >
                  <i
                    className={
                      "fas fa-user mr-2 text-sm " +
                      (window.location.href.indexOf("/admin/manage-team") !== -1
                        ? "opacity-75"
                        : "text-gray-500")
                    }
                  ></i>{" "}
                  Manage Team
                </Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    </>
  );
}

const Logo = styled.div`
 size: 100%;
`