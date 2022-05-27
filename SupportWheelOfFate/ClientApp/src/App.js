import React, { Component } from 'react';
import { WheelOfFate } from './components/WheelOfFate';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <div className="container">
                <WheelOfFate />
            </div>
        );
    }
}
