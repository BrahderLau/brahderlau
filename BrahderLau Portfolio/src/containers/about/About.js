import React, {useContext} from "react";
import "./About.css";
import {aboutSection} from "../../portfolio";
import {Fade} from "react-reveal";
import StyleContext from "../../contexts/StyleContext";
import emoji from "react-easy-emoji";

export default function About() {
  const {isDark} = useContext(StyleContext);
  if (!aboutSection.display) {
    return null;
  }
  return (
    <div className={isDark ? "dark-mode main" : "main"} id="about">
      <div className="about-main-div">
        <Fade left duration={1000}>
          <div className="about-text-div">
            <h1
              className={isDark ? "dark-mode about-heading" : "about-heading"}
            >
              {aboutSection.title}{" "}
              <span className="wave-emoji">{emoji("🐼")}</span>
            </h1>
            <div>
              
              {aboutSection.info.map((info, i) => {
                return ( 
                  <p>
                    {info}
                  </p>
                );
              })}
            </div>
          </div>
        </Fade>
        <Fade right duration={1000}>
          <div className="skills-image-div">
              <img
                alt="Profile Pic"
                src={require("../../assets/images/brahderlauPotraitNew.png")}
              ></img>
          </div>
        </Fade>
      </div>
    </div>
  );
}
