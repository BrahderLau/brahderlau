const rules = {
    visitor: {
      static: [
        "loginOrRegister: auth",
        "home: visit",
        "live-match: visit",
        "match-schedule: list",
        "leaderboard: list", 
        "team-list: list",
        "top-scorer: list", 
        "player-list: list"
      ]
    },
    player: {
      static: [
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
  