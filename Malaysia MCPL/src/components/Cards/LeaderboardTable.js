import React from "react";
import PropTypes from "prop-types";
//import styled from 'styled-components';
import _ from 'lodash';
// components

//import TableDropdown from "components/Dropdowns/TableDropdown.js";
import {teamData} from "data/Team.js"
export default function LeaderboardTable({ color }) {

  const checkRankChanges = (previous, current) => {
    let rankChangeStatus = _.isEqual(previous,current) 
    ? "same"
    :  _.gt(previous, current) 
    ? "increase" 
    : "decrease"
    
    return rankChangeStatus;
  }

  const calcRankDiff = (previous, current) => {
    let result = _.subtract(previous, current)
    if (result !== 0) {
      if (result > 0) {
        result = '+' + result;
      } 
      
    }
    else {
      result = " ";
    }

    result = _.padStart(result, 3, ' ');
    return result
  }

  const sortByRank = (team) => {
    return _.sortBy(team, [function(data) { return data.teamBattleDetails["currentRanking"]}]);
  }

  const teamJsx = () => {
    return <tbody>
      {
        sortByRank(teamData).map(function(team, index) {
          return( 
          <tr className="border-b" key={index}>
            <th className="border-t-0 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4 text-left">
              <span
                className={
                  "ml-3 " +
                  +(color === "light" ? "text-gray-700" : "text-white")
                }
              >
                {team.teamBattleDetails["currentRanking"]}
              </span> 
              <span
                className={
                    checkRankChanges(team.teamBattleDetails["previousRanking"], team.teamBattleDetails["currentRanking"]) === "same"
                    ? "ml-3 fas fa-equals text-blue-500 mr-4"
                    : checkRankChanges(team.teamBattleDetails["previousRanking"], team.teamBattleDetails["currentRanking"]) === "increase"
                      ? "ml-3 fas fa-arrow-up text-green-500 mr-4"
                      : "ml-3 fas fa-arrow-down text-orange-500 mr-4"
                }
              >
                {calcRankDiff(team.teamBattleDetails["previousRanking"], team.teamBattleDetails["currentRanking"])}
              </span>
              <i 
                className = {
                  team.teamBattleDetails["currentRanking"] === 1
                  ? "ml-3 fas fa-crown text-orange-500"
                  : "ml-3"
                }
                   /> 
            </th>
            
            <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
              <div className="flex items-center text-center">
                <img
                  src={team.teamDetails["teamLogo"]}
                  className="h-12 w-12 bg-white rounded-full border"
                  alt="team logo"
                ></img>{" "}
                <span
                  className={
                    "pl-4 font-bold " +
                    +(color === "light" ? "text-gray-700" : "text-white")
                  }
                >
                  {team.teamName}
                </span>
              </div>
            </td>
            <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
              <div className="flex">
                <img
                  src={require("assets/img/team-1-800x800.jpg")}
                  alt="..."
                  className="w-10 h-10 rounded-full border-2 border-gray-100 shadow "
                ></img>
                <img
                  src={require("assets/img/team-2-800x800.jpg")}
                  alt="..."
                  className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                ></img>
                <img
                  src={require("assets/img/team-3-800x800.jpg")}
                  alt="..."
                  className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                ></img>
                <img
                  src={require("assets/img/team-4-470x470.png")}
                  alt="..."
                  className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                ></img>
              </div>
              <div className="flex">
                <img
                  src={require("assets/img/team-1-800x800.jpg")}
                  alt="..."
                  className="w-10 h-10 rounded-full border-2 border-gray-100 shadow "
                ></img>
                <img
                  src={require("assets/img/team-2-800x800.jpg")}
                  alt="..."
                  className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                ></img>
                <img
                  src={require("assets/img/team-3-800x800.jpg")}
                  alt="..."
                  className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                ></img>
                <img
                  src={require("assets/img/team-4-470x470.png")}
                  alt="..."
                  className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                ></img>
              </div>
            </td>
            <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
              {team.teamBattleDetails["matchCount"]}
            </td>
            <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
              {team.teamBattleDetails["winsCount"]}
            </td>
            <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
              {team.teamBattleDetails["losesCount"]}
            </td>
            <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
              {team.teamBattleDetails["drawCount"]}
            </td>
            <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
              {team.teamBattleDetails["totalPoints"]}
            </td>
            <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
              {team.teamBattleDetails["totalIGS"]}
            </td>
            {/* <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4 text-right">
              <TableDropdown />
            </td> */}      
          </tr>
          )  
        })}
    </tbody>
  }

  return (
    <>
      <div
        className={
          "relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded " +
          (color === "light" ? "bg-white" : "bg-blue-900 text-white")
        }
      >
        <div className="rounded-t mb-0 px-4 py-3 border-0">
          <div className="flex flex-wrap items-center">
            <div className="relative w-full px-4 max-w-full flex-grow flex-1">
              <h3
                className={
                  "font-semibold text-lg " +
                  (color === "light" ? "text-gray-800" : "text-white")
                }
              >
                Leaderboard  (Last Updated: 4 March 2021)
              </h3>
            </div>
          </div>
        </div>
        <div className="block w-full overflow-x-auto">
          <table className="items-center w-full bg-transparent border-collapse">
            <thead>
              <tr>
                <th
                  className={
                    "px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-no-wrap font-semibold text-left " +
                    (color === "light"
                      ? "bg-gray-100 text-gray-600 border-gray-200"
                      : "bg-blue-800 text-blue-300 border-blue-700")
                  }
                >
                  Ranking
                </th>
                <th
                  className={
                    "px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-no-wrap font-semibold text-left " +
                    (color === "light"
                      ? "bg-gray-100 text-gray-600 border-gray-200"
                      : "bg-blue-800 text-blue-300 border-blue-700")
                  }
                >
                  Team Logo & Name
                </th>
                <th
                  className={
                    "px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-no-wrap font-semibold text-left " +
                    (color === "light"
                      ? "bg-gray-100 text-gray-600 border-gray-200"
                      : "bg-blue-800 text-blue-300 border-blue-700")
                  }
                >
                  Team Members
                </th>
                <th
                  className={
                    "px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-no-wrap font-semibold text-left " +
                    (color === "light"
                      ? "bg-gray-100 text-gray-600 border-gray-200"
                      : "bg-blue-800 text-blue-300 border-blue-700")
                  }
                >
                  Match
                </th>
                <th
                  className={
                    "px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-no-wrap font-semibold text-left " +
                    (color === "light"
                      ? "bg-gray-100 text-gray-600 border-gray-200"
                      : "bg-blue-800 text-blue-300 border-blue-700")
                  }
                >
                  Wins
                </th>
                <th
                  className={
                    "px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-no-wrap font-semibold text-left " +
                    (color === "light"
                      ? "bg-gray-100 text-gray-600 border-gray-200"
                      : "bg-blue-800 text-blue-300 border-blue-700")
                  }
                >
                  Draw
                </th>
                <th
                  className={
                    "px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-no-wrap font-semibold text-left " +
                    (color === "light"
                      ? "bg-gray-100 text-gray-600 border-gray-200"
                      : "bg-blue-800 text-blue-300 border-blue-700")
                  }
                >
                  Loses
                </th>
                <th
                  className={
                    "px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-no-wrap font-semibold text-left " +
                    (color === "light"
                      ? "bg-gray-100 text-gray-600 border-gray-200"
                      : "bg-blue-800 text-blue-300 border-blue-700")
                  }
                >
                  Total Points (TP)
                </th>
                <th
                  className={
                    "px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-no-wrap font-semibold text-left " +
                    (color === "light"
                      ? "bg-gray-100 text-gray-600 border-gray-200"
                      : "bg-blue-800 text-blue-300 border-blue-700")
                  }
                >
                  In-Game Score (IGS)
                </th>
              </tr>
            </thead>
              {teamJsx()}
                   
              
              {/* <tr>
                <th className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4 text-left flex items-center">
                  <img
                    src={require("assets/img/angular.jpg")}
                    className="h-12 w-12 bg-white rounded-full border"
                    alt="..."
                  ></img>{" "}
                  <span
                    className={
                      "ml-3 font-bold " +
                      +(color === "light" ? "text-gray-700" : "text-white")
                    }
                  >
                    Angular Now UI Kit PRO
                  </span>
                </th>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
                  $1,800 USD
                </td>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
                  <i className="fas fa-circle text-green-500 mr-2"></i>{" "}
                  completed
                </td>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
                  <div className="flex">
                    <img
                      src={require("assets/img/team-1-800x800.jpg")}
                      alt="..."
                      className="w-10 h-10 rounded-full border-2 border-gray-100 shadow"
                    ></img>
                    <img
                      src={require("assets/img/team-2-800x800.jpg")}
                      alt="..."
                      className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                    ></img>
                    <img
                      src={require("assets/img/team-3-800x800.jpg")}
                      alt="..."
                      className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                    ></img>
                    <img
                      src={require("assets/img/team-4-470x470.png")}
                      alt="..."
                      className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                    ></img>
                  </div>
                </td>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
                  <div className="flex items-center">
                    <span className="mr-2">100%</span>
                    <div className="relative w-full">
                      <div className="overflow-hidden h-2 text-xs flex rounded bg-green-200">
                        <div
                          style={{ width: "100%" }}
                          className="shadow-none flex flex-col text-center whitespace-nowrap text-white justify-center bg-green-500"
                        ></div>
                      </div>
                    </div>
                  </div>
                </td>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4 text-right">
                  <TableDropdown />
                </td>
              </tr>
              <tr>
                <th className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4 text-left flex items-center">
                  <img
                    src={require("assets/img/sketch.jpg")}
                    className="h-12 w-12 bg-white rounded-full border"
                    alt="..."
                  ></img>{" "}
                  <span
                    className={
                      "ml-3 font-bold " +
                      +(color === "light" ? "text-gray-700" : "text-white")
                    }
                  >
                    Black Dashboard Sketch
                  </span>
                </th>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
                  $3,150 USD
                </td>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
                  <i className="fas fa-circle text-red-500 mr-2"></i> delayed
                </td>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
                  <div className="flex">
                    <img
                      src={require("assets/img/team-1-800x800.jpg")}
                      alt="..."
                      className="w-10 h-10 rounded-full border-2 border-gray-100 shadow"
                    ></img>
                    <img
                      src={require("assets/img/team-2-800x800.jpg")}
                      alt="..."
                      className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                    ></img>
                    <img
                      src={require("assets/img/team-3-800x800.jpg")}
                      alt="..."
                      className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                    ></img>
                    <img
                      src={require("assets/img/team-4-470x470.png")}
                      alt="..."
                      className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                    ></img>
                  </div>
                </td>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
                  <div className="flex items-center">
                    <span className="mr-2">73%</span>
                    <div className="relative w-full">
                      <div className="overflow-hidden h-2 text-xs flex rounded bg-red-200">
                        <div
                          style={{ width: "73%" }}
                          className="shadow-none flex flex-col text-center whitespace-nowrap text-white justify-center bg-red-500"
                        ></div>
                      </div>
                    </div>
                  </div>
                </td>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4 text-right">
                  <TableDropdown />
                </td>
              </tr>
              <tr>
                <th className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4 text-left flex items-center">
                  <img
                    src={require("assets/img/react.jpg")}
                    className="h-12 w-12 bg-white rounded-full border"
                    alt="..."
                  ></img>{" "}
                  <span
                    className={
                      "ml-3 font-bold " +
                      +(color === "light" ? "text-gray-700" : "text-white")
                    }
                  >
                    React Material Dashboard
                  </span>
                </th>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
                  $4,400 USD
                </td>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
                  <i className="fas fa-circle text-teal-500 mr-2"></i> on
                  schedule
                </td>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
                  <div className="flex">
                    <img
                      src={require("assets/img/team-1-800x800.jpg")}
                      alt="..."
                      className="w-10 h-10 rounded-full border-2 border-gray-100 shadow"
                    ></img>
                    <img
                      src={require("assets/img/team-2-800x800.jpg")}
                      alt="..."
                      className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                    ></img>
                    <img
                      src={require("assets/img/team-3-800x800.jpg")}
                      alt="..."
                      className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                    ></img>
                    <img
                      src={require("assets/img/team-4-470x470.png")}
                      alt="..."
                      className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                    ></img>
                  </div>
                </td>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
                  <div className="flex items-center">
                    <span className="mr-2">90%</span>
                    <div className="relative w-full">
                      <div className="overflow-hidden h-2 text-xs flex rounded bg-teal-200">
                        <div
                          style={{ width: "90%" }}
                          className="shadow-none flex flex-col text-center whitespace-nowrap text-white justify-center bg-teal-500"
                        ></div>
                      </div>
                    </div>
                  </div>
                </td>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4 text-right">
                  <TableDropdown />
                </td>
              </tr>
              <tr>
                <th className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4 text-left flex items-center">
                  <img
                    src={require("assets/img/vue.jpg")}
                    className="h-12 w-12 bg-white rounded-full border"
                    alt="..."
                  ></img>{" "}
                  <span
                    className={
                      "ml-3 font-bold " +
                      +(color === "light" ? "text-gray-700" : "text-white")
                    }
                  >
                    React Material Dashboard
                  </span>
                </th>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
                  $2,200 USD
                </td>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
                  <i className="fas fa-circle text-green-500 mr-2"></i>{" "}
                  completed
                </td>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
                  <div className="flex">
                    <img
                      src={require("assets/img/team-1-800x800.jpg")}
                      alt="..."
                      className="w-10 h-10 rounded-full border-2 border-gray-100 shadow"
                    ></img>
                    <img
                      src={require("assets/img/team-2-800x800.jpg")}
                      alt="..."
                      className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                    ></img>
                    <img
                      src={require("assets/img/team-3-800x800.jpg")}
                      alt="..."
                      className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                    ></img>
                    <img
                      src={require("assets/img/team-4-470x470.png")}
                      alt="..."
                      className="w-10 h-10 rounded-full border-2 border-gray-100 shadow -ml-4"
                    ></img>
                  </div>
                </td>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
                  <div className="flex items-center">
                    <span className="mr-2">100%</span>
                    <div className="relative w-full">
                      <div className="overflow-hidden h-2 text-xs flex rounded bg-green-200">
                        <div
                          style={{ width: "100%" }}
                          className="shadow-none flex flex-col text-center whitespace-nowrap text-white justify-center bg-green-500"
                        ></div>
                      </div>
                    </div>
                  </div>
                </td>
                <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4 text-right">
                  <TableDropdown />
                </td>
              </tr> */}
            {/* </tbody> */}
          </table>
        </div>
      </div>
    </>
  );
}

LeaderboardTable.defaultProps = {
  color: "light",
};

LeaderboardTable.propTypes = {
  color: PropTypes.oneOf(["light", "dark"]),
};

