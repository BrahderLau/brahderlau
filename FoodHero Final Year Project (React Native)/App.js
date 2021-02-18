import React from "react";
import Providers from './navigation';
import { LogBox } from "react-native";
import _ from "lodash";

export default function App() {

    LogBox.ignoreLogs(["Setting a timer"]);
    const _console = _.clone(console);
    console.warn = (message) => {
    if (message.indexOf("Setting a timer") <= -1) {
        _console.warn(message);
        }
    };

    return (
    <Providers />
    );
}
