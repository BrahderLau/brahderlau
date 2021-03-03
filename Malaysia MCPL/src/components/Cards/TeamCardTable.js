import React from "react";
import PropTypes from "prop-types";
//import styled from 'styled-components';
// import _ from 'lodash';
// components

import TableDropdown from "components/Dropdowns/TableDropdown.js";
import {teamData} from "data/Team.js"
export default function TeamCardTable({ color }) {

  // const checkRankChanges = (previous, current) => {
  //   const result = isEqual(previous, current);
  //   let sign;
  //   if(result === "") {
  //     sign = '◀️';
  //   }
  //   else{
  //     _.gt(previous, current) ? sign = '🔼' : sign = '🔽'
  //   }
  //   return sign;
  // }

  // const greenOrRed = (previous, current) => {
  //   return _.lt(previous, current) ? "ml-3 text-red-500" : "ml-3 text-green-500"
  // }

  // const isEqual = (previous, current) => {
  //   return _.isEqual(previous,current) ? "=" : previous
  // }

  // const calcRankDiff = (previous, current) => {
  //   let result = _.subtract(previous, current)
  //   if (result !== 0) {
  //     if (result > 0) {
  //       result = '+' + result;
  //     } 
  //     else {
  //       let newResult = _.padStart(result, 3, ' ');
  //       result = newResult;
  //     }
  //   }
  //   else {
  //     result = "";
  //   }
  //   return result
  // }

  const teamJsx = () => {
    return <tbody>
      {
        teamData.map(function(team, index) {
          return( <tr key={index}>

            <td className="border-t-0 px-5 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4 text-left flex items-center">
              <img
                src={team.teamDetails["teamLogo"]}
                className="h-12 w-12 bg-white rounded-full border"
                alt="team logo"
              ></img>{" "}
              <span
                className={
                  "ml-3 font-bold " +
                  +(color === "light" ? "text-gray-700" : "text-white")
                }
              >
                {team.teamName}
              </span>
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
              {team.teamDetails["teamFounder"]}
            </td>
            <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
              {team.teamDetails["teamValue"]}
            </td>
            <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4">
              {team.teamBattleDetails["teamDivision"]}
            </td>
            <td className="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-no-wrap p-4 text-right">
              <TableDropdown />
            </td>
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
                Team List
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
                  Team Founder
                </th>
                <th
                  className={
                    "px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-no-wrap font-semibold text-left " +
                    (color === "light"
                      ? "bg-gray-100 text-gray-600 border-gray-200"
                      : "bg-blue-800 text-blue-300 border-blue-700")
                  }
                >
                  Team Value
                </th>
                <th
                  className={
                    "px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-no-wrap font-semibold text-left " +
                    (color === "light"
                      ? "bg-gray-100 text-gray-600 border-gray-200"
                      : "bg-blue-800 text-blue-300 border-blue-700")
                  }
                >
                  Division
                </th>
                <th
                  className={
                    
                    color === "light"
                      ? "bg-gray-100 text-gray-600 border-gray-200"
                      : "bg-blue-800 text-blue-300 border-blue-700"
                  }
                >
                  
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

TeamCardTable.defaultProps = {
  color: "light",
};

TeamCardTable.propTypes = {
  color: PropTypes.oneOf(["light", "dark"]),
};

