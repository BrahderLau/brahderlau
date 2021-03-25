/* Change this file to get your personal Portfolio */

// Summary And Greeting Section

import emoji from "react-easy-emoji";

const illustration = {
  animated: true // set to false to use static SVG
};

const greeting = {
  username: "BrahderLau",
  title: "Hello, I'm Kah Hou",
  subTitle: emoji(
    "A Young and Passionate Software Developer 🚀 having an experience of designing and building Web and Mobile applications with JavaScript / Reactjs / Nodejs and some other cool libraries and frameworks."
  ),
  resumeLink:
    "https://drive.google.com/file/d/19JIyg4Y3qwtlbiJzXweqPHuXOJNCHtFj/view?usp=sharing",
  displayGreeting: true // Set false to hide this section, defaults to true
};

// Social Media Links

const socialMediaLinks = {
  github: "https://github.com/BrahderLau/brahderlau",
  linkedin: "https://www.linkedin.com/in/brahderlau",
  gmail: "brahderlau@gmail.com",
  //hotmail: "khlau_1012@hotmail.com",
  gitlab: "https://gitlab.com/BrahderLau",
  facebook: "https://www.facebook.com/iambrahderlau",
  medium: "https://medium.com/@brahderlau",
  stackoverflow: "https://stackoverflow.com/users/15266743/brahderlau",
  instagram: 'https://www.instagram.com/brahderlau/',
  twitter: 'https://twitter.com/BrahderLau',
  display: true // Set true to display this section, defaults to false
};

// About Section

const aboutSection = {
  title: "Who Am I",
  info: [
    emoji("😀 22 years old"),
    emoji("😉 Sweet, Shorty and Fluffy"),
    emoji("😊 Born and raised in Seri Manjung, Perak"),
    emoji("🤩 Loves singing 🎙️ and gaming 🎮"),
    emoji("😘 Favourite food: fish 🐟"),
    emoji("🤣 Fun fact: I love exploring new things around me"),
  ],
  display: true // Set false to hide this section, defaults to true
};

// Skills Section

const skillsSection = {
  title: "What I do",
  subTitle: "FRESH GRAD SOFTWARE DEVELOPER WHO WANTS TO EXPLORE EVERY TECH STACK",
  skills: [
    emoji(
      "⚡ Develop highly interactive Front end / User Interfaces for your web and mobile applications"
    ),
    emoji("⚡ Develop highly interactive prototype design using Adobe XD"),
    emoji(
      "⚡ Integration of third party services such as Firebase/ AWS / Azure"
    )
  ],

  /* Make Sure to include correct Font Awesome Classname to view your icon
https://fontawesome.com/icons?d=gallery */

  softwareSkills: [
    {
      skillName: "html-5",
      fontAwesomeClassname: "fab fa-html5"
    },
    {
      skillName: "css3",
      fontAwesomeClassname: "fab fa-css3-alt"
    },
    // {
    //   skillName: "sass",
    //   fontAwesomeClassname: "fab fa-sass"
    // },
    {
      skillName: "JavaScript",
      fontAwesomeClassname: "fab fa-js"
    },
    {
      skillName: "reactjs",
      fontAwesomeClassname: "fab fa-react"
    },
    {
      skillName: "nodejs",
      fontAwesomeClassname: "fab fa-node"
    },
    {
      skillName: "swift",
      fontAwesomeClassname: "fab fa-swift"
    },
    {
      skillName: "npm",
      fontAwesomeClassname: "fab fa-npm"
    },
    {
      skillName: "sql-database",
      fontAwesomeClassname: "fas fa-database"
    },
    {
      skillName: "firebase",
      fontAwesomeClassname: "fas fa-fire"
    }
  ],
  display: true // Set false to hide this section, defaults to true
};

// Education Section

const educationInfo = {
  display: true, // Set false to hide this section, defaults to true
  schools: [
    {
      schoolName: "Asia Pacific University of Technology & Innovation (APU)",
      logo: require("./assets/images/APU.png"),
      subHeader: "BSc Hons in Software Engineering",
      duration: "February 2018 - February 2021",
      //desc: "APU Merit Scholarship Holder with CGPA 3.767"
      descBullets: [
        "APU Merit Scholarship Holder",
        "First Class Degree Honour with CGPA 3.767"
      ]
    },
    {
      schoolName: "SMK Methodist (A.C.S) Sitiawan",
      logo: require("./assets/images/secondarySchool.jpg"),
      subHeader: "Science Class",
      duration: "January 2012 - December 2016",
      //desc:"SPM 8A, 2B, 1C"
      descBullets: ["SPM 8A, 2B, 1C"]
    }
  ]
};

// Your top 3 proficient stacks/tech experience

const techStack = {
  viewSkillBars: true, //Set it to true to show Proficiency Section
  experience: [
    {
      Stack: "Prototype Design", //Insert stack or technology you have experience in
      progressPercentage: "85%" //Insert relative proficiency in percentage
    },
    {
      Stack: "Frontend",
      progressPercentage: "75%"
    },
    {
      Stack: "Backend",
      progressPercentage: "80%"
    }
  ],
  displayCodersrank: true // Set true to display codersrank badges section need to changes your username in src/containers/skillProgress/skillProgress.js:17:62, defaults to false
};

// Work experience section

const workExperiences = {
  display: true, //Set it to true to show workExperiences Section
  experience: [
    {
      role: "Software Engineer 1 - IT",
      company: "Dell",
      companylogo: require("./assets/images/Dell.png"),
      date: "22 March 2021 onwards",
      desc: "Graduate Development Programme (GDP)",
      descBullets: [
        "Software Design, Development, Testing and Deployment..."
      ]
    },
    {
      role: "Part-time Software Developer Freelancer",
      company: "Home",
      companylogo: require("./assets/images/brahderlau_alt.jpg"),
      date: "March 1, 2021 – Present",
      desc:
        "I'm currently developing Progressive Web Applications (PWA) including front-end and back-end for clients",
      descBullets: [
        "Built using React.js and Firebase with libraries such as Material UI, Tailswind and Postman as API testing and documentation"
      ]
    },
    {
      role: "Software Engineer Intern (Full-stack)",
      company: "Fusionex",
      companylogo: require("./assets/images/Fusionex.jpeg"),
      date: "18 November 2019 - 27 March 2020",
      desc: "I've developed and enhanced the back-end APIs, front-end designs as well as writing batch scripts.",
      descBullets: [
        "Experienced with MEAN stack (MongoDB, ExpressJS, AngularJS, NodeJS) and PostgreSQL",
        "Enhance the existing features of the system to meet the customer requirements in terms of efficiency and usability",
        "Cooperate with other project members to meet and complete the project requirements",
        "Manage and resolves client’s service request and change request"
      ]
    },
    {
      role: "Part-time Facebook Gaming Streamer",
      company: "Rakyat Catur",
      companylogo: require("./assets/images/brahderlauGaming.jpg"),
      date: "August 15, 2019 – Present",
      desc:
        "I've streamed both Mobile Legends: Bang Bang 5v5 Mode and Magic Chess on Facebook.",
      descBullets: [
        "Provides step-by-step tutorials, strategies as well as current metas in magic chess",
        "Upload highlights of the outstanding videos that are just BOOOOOOM!",
        "Stream on Facebook using different streaming tools such as Streamlabs OBS and Omlet Arcade.",
        "Facebook page link: facebook.com/brahderlau.mlbb" 
      ]
    }
  ]
};

/* Your Open Source Section to View Your Github Pinned Projects
To know how to get github key look at readme.md */

const openSource = {
  githubConvertedToken: process.env.REACT_APP_GITHUB_TOKEN,
  githubUserName: "brahderlau", // Change to your github username to view your profile in Contact Section.
  showGithubProfile: "true", // Set true or false to show Contact profile using Github, defaults to true
  display: false // Set false to hide this section, defaults to true
};

// Some big projects you have worked on

const bigProjects = {
  title: "Projects",
  subtitle: "SOME STARTUPS AND COMPANIES THAT I HELPED TO CREATE THEIR TECH",
  projects: [
    {
      image: require("./assets/images/magic_chess_union.png"),
      projectName: "Malaysia Magic Chess Professional League (MCPL) Web Application",
      projectDesc: "A leaderboard, player and team registration system developed for mobile legends magic chess tournaments using React.js as Front-end and Firebase as Back-end",
      footerLink: [
        {
          name: "Visit Website Link",
          url: "https://malaysia-mcpl.web.app/"
        },
        {
          name: "Visit Facebook Page",
          url: "https://www.facebook.com/mcumlbb"
        },
        {
          name: "Visit Project Link",
          url: "https://github.com/BrahderLau/brahderlau/tree/master/Malaysia%20MCPL"
        },
        //  you can add extra buttons here.
      ]
    }
    // {
    //   image: require("./assets/images/nextuLogo.webp"),
    //   projectName: "Nextu",
    //   projectDesc: "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
    //   footerLink: [
    //     {
    //       name: "Visit Website",
    //       url: ""
    //     }
    //   ]
    // }
  ],
  display: true // Set false to hide this section, defaults to true
};

// Achievement Section
// Include certificates, talks etc

const achievementSection = {
  title: emoji("Achievements And Certifications 🏆 "),
  subtitle:
    "Achievements, Certifications, Award Letters and Some Cool Stuff that I have done !",

  achievementsCards: [
    {
      title: "AWS BUILD ON, ASEAN 2020: BUILDING YOUR FUTURE",
      subtitle:
        "Achieving Semi-Finalist in Build On, Malaysia 2020",
      image: require("./assets/images/AWS_BUILD_ON_ASEAN_2020.png"),
      footerLink: [
        {
          name: "Certificate",
          url:
            "https://drive.google.com/file/d/1zVBhvAHvp8qnOVYMKqKQZDsE07Gp3wQC/view?usp=sharing"
        }
      ]
    },
    {
      title: "ALIBABA GET GLOBAL CHALLENGE 2020: DIGITAL SOLUTIONS DURING AND BEYOND COVID-19",
      subtitle:
        "Achieved Top 40 in Alibaba GET Global Challenge 2020.",
      image: require("./assets/images/alibaba.PNG"),
      footerLink: [
        {
          name: "Certificate",
          url:
            "https://drive.google.com/file/d/1efm0b636aKgj7DaG5owtPK1C5ukYx03s/view?usp=sharing"
        }
      ]
    },

    {
      title: "Exam AZ-900: Microsoft Azure Fundamentals",
      subtitle: "Passed Exam AZ-900: Microsoft Azure Fundamentals",
      image: require("./assets/images/azure_fundamentals.png"),
      footerLink: [
        {
          name: "Badge", 
          url: "https://drive.google.com/file/d/1SBbWQxiVGPDDSLRRhkp7xJMLp3KbxuEX/view?usp=sharing"
        },
        {
          name: "Certificate",
          url: "https://drive.google.com/file/d/1rJC2u2jQI5at5k9vtaFghKmK3cL0d8l-/view?usp=sharing"
        },
      ]
    }
  ],
  display: true // Set false to hide this section, defaults to true
};

// Blogs Section

const blogSection = {
  title: "Blogs",
  subtitle:
    "With Love for Developing cool stuff, I love to write and teach others what I have learnt.",

  blogs: [
    {
      url:
        "https://blog.usejournal.com/create-a-google-assistant-action-and-win-a-google-t-shirt-and-cloud-credits-4a8d86d76eae",
      title: "Win a Google Assistant Tshirt and $200 in Google Cloud Credits",
      description:
        "Do you want to win $200 and Google Assistant Tshirt by creating a Google Assistant Action in less then 30 min?"
    },
    {
      url: "https://medium.com/@saadpasta/why-react-is-the-best-5a97563f423e",
      title: "Why REACT is The Best?",
      description:
        "React is a JavaScript library for building User Interface. It is maintained by Facebook and a community of individual developers and companies."
    }
  ],
  display: false // Set false to hide this section, defaults to true
};

// Talks Sections

const talkSection = {
  title: "TALKS",
  subtitle: emoji(
    ""
  ),

  talks: [
    {
      title: "",
      subtitle: "",
      slides_url: "",
      event_url: ""
    }
  ],
  display: false // Set false to hide this section, defaults to true
};

// Podcast Section

const podcastSection = {
  title: emoji("Podcast 🎙️"),
  subtitle: "I LOVE TO TALK ABOUT MYSELF AND TECHNOLOGY",

  // Please Provide with Your Podcast embeded Link
  podcast: [
    ""
  ],
  display: false // Set false to hide this section, defaults to true
};

const contactInfo = {
  title: emoji("Contact Me ☎️"),
  subtitle:
    "Discuss a project or just want to say hi? My Inbox is open for all.",
  number: "(+60) 12 506 9787",
  email_address: "khlau_1012@hotmail.com"
};

// Twitter Section

const twitterDetails = {
  userName: "BrahderLau", //Replace "twitter" with your twitter username without @
  display: true // Set true to display this section, defaults to false
};

export {
  illustration,
  greeting,
  socialMediaLinks,
  aboutSection,
  skillsSection,
  educationInfo,
  techStack,
  workExperiences,
  openSource,
  bigProjects,
  achievementSection,
  blogSection,
  talkSection,
  podcastSection,
  contactInfo,
  twitterDetails
};
