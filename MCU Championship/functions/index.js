const functions = require("firebase-functions");
const app = require('express')();
//const { db, admin, auth } = require('./util/admin')
const { userCreationValidators } = require('./util/validators')
const { authCheck } = require('./util/AuthCheck') // to check if user is authorized to write data

const { getAllUsers, manualRegister, manualLogin } = require('./controllers/user')
const { createNewTeam } = require('./controllers/team')

// User routes
app.post('/manualRegister', userCreationValidators, manualRegister);
app.post('/manualLogin', manualLogin);
app.get(`/userList`, getAllUsers);  //only super admin and admin
//TODO: 
//app.patch(`/updateUser`, updateUser);  //only super admin and admin
//app.delete(`/deleteUser`, deleteUser);  //only super admin
//app.get(`/user`, getUser);
//app.get(`/me`, getMe);
//app.get(`/updateMe`, updateMe);

// Team routes
//app.post(`/createNewTeam`,authCheck, createNewTeam); //temporarily removed token verification for tesing
app.post(`/createNewTeam`, createNewTeam);
//TODO: 
//app.get(`/teamList`, getAllTeams);
//app.patch(`/updateTeam`, updateTeam);   //only super admin and admin
//app.delete(`/deleteTeam`, deleteTeam);   //only super admin and admin
//app.get(`/team`, getTeam);
//app.get(`/myTeam`, getMyTeam);
//app.patch(`/updateMyTeam, updateMyTeam);
//app.patch(`/acceptPlayer`, acceptPlayer);   //only team captain
//app.patch(`/transferCaptain`, transferCaptain);   //only team captain
//app.delete(`/removePlayer`, removePlayer);   //only team captain

// Tournament routes
//app.get(`/tournamentList`, getAllTournament);
//app.get(`/getTournament`, getTournament);
//app.post(`/joinTournament`, joinTournament);
//app.post(`/createTournament`, createTournament);  //only super admin
//app.patch(`/updateTournament, updateTournament);  //only super admin
//app,delete(`/deleteTournament, deleteTournament);   //only super admin

// Game routes
//app.get(`/gameList`, getAllGames);  
//app.get(`/game`, getGame);  
//app.post(`/createGame`, createGame);  //only super admin and admin
//app.patch(`/updateGame`, updateGame);  //only super admin and admin
//app.delete(`/deleteGame`, deleteGame);  //only super admin and admin

// Leaderboard routes
//app.get(`/teamLeaderboard`, getTeamLeaderboard); 
//app.get(`/topScorerLeaderboard`, getTopScorerLeaderboard);

exports.api = functions.region('asia-southeast2').https.onRequest(app);