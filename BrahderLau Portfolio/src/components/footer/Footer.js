import React, {useContext} from "react";
import "./Footer.css";
import {Fade} from "react-reveal";
import emoji from "react-easy-emoji";
import StyleContext from "../../contexts/StyleContext";

export default function Footer() {
  const {isDark} = useContext(StyleContext);
  return (
    <Fade bottom duration={1000} distance="5px">
      <div className="footer-div">
        <p className={isDark ? "dark-mode footer-text" : "footer-text"}>
          {emoji("Created by Lau Kah Hou | Credits to Saad Pasta and David Rakosi @CleverProgrammer")}
        </p>
        <p className={isDark ? "dark-mode footer-text" : "footer-text"}>
          {/* Source link{" "}
          <a href="https://github.com/brahderlau/BrahderLau">
            BrahderLau Portfolio
          </a> */}
          <a>© Copyright 2021 - BrahderLau</a>
        </p>
      </div>
    </Fade>
  );
}
