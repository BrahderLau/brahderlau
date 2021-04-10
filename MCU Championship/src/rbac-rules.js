const rules = {
    visitor: {
      static: [
        "auth: login",
        "auth: register",
        "home: visit",
        "live-match: visit",
        "match-schedule: list",
        "leaderboard: list", 
        "team-list: list",
        "top-scorer: list", 
        "player-list: list"
      ]
    },
    user: {
      static: [
        "auth: logout",
        "home: visit",
        "live-match: visit",
        "match-schedule: list",
        "leaderboard: list", 
        "team-list: list",
        "top-scorer: list", 
        "player-list: list",
        "profile: getSelf",
        "profile: edit"
      ]
    },
    player: {
      static: [
        "auth: logout",
        "home: visit",
        "live-match: visit",
        "match-schedule: list",
        "leaderboard: list", 
        "team-list: list",
        "top-scorer: list", 
        "player-list: list",
        "profile: getSelf",
        "profile: edit",
        "myteam: edit"
      ]
    },
    admin: {
      static: [
        "auth: logout",
        "home: visit",
        "live-match: visit",
        "match-schedule: list",
        "leaderboard: list", 
        "team-list: list",
        "top-scorer: list", 
        "player-list: list",
        "profile: getSelf",
        "profile: edit",
        //"myteam: edit",
        "match: create",
        "match: edit",
        "match: list"
      ]
    },
    superAdmin: {
      static: [
        "auth: logout",
        "home: visit",
        "live-match: visit",
        "match-schedule: list",
        "leaderboard: list", 
        "team-list: list",
        "top-scorer: list", 
        "player-list: list",
        "profile: getSelf",
        "profile: edit",
        //"myteam: edit",
        "match: create",
        "match: edit",
        "match: list",
        "match: delete",
        "user: create",
        "user: edit",
        "user: delete",
        "user: list",
        "team: create",
        "team: edit",
        "team: delete",
        "team: list"
      ]
    }
  };
  
  export default rules;
  