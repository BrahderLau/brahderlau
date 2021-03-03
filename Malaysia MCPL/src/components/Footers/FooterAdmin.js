//import {Container, Footer, Title, Button, Icon} from 'native-base';
import React from "react";

export default function FooterAdmin() {
  return (
    <>
      <footer className="block py-4">
        <div className="container mx-auto px-4">
          <hr className="my-6 border-gray-400" />
          <div className="flex flex-wrap items-center md:justify-between justify-center ">
            <div className="w-full md:w-4/12 px-4 mx-auto text-center">
              <div className="text-sm text-gray-600 font-semibold py-1">
                <a className="text-gray-600 text-sm font-semibold py-1">
                  Organized by Magic Chess Union (MCU)
                </a><br/>
                <a className="text-gray-600 text-sm font-semibold py-1">
                  Developed By BrahderLau
                </a><br/>
                <a 
                  href="https://brahderlau.netlify.app/"
                  className="text-gray-600 hover:text-gray-800 text-sm font-semibold py-1"
                >
                  Copyright © {new Date().getFullYear()}{" "} BrahderLau.
                </a>
              </div>
            </div>
          </div>
        </div>
      </footer>
    </>
  );
}
