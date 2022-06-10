import React, { Component } from 'react';
import WeekPlan from './WeekPlan';
import { Engineer } from './Engineer';

export class WheelOfFate extends Component {
    constructor(props) {
        super(props);
        this.state = {
            engineers: [
                { no: 1, name: '' },
                { no: 2, name: '' },
                { no: 3, name: '' },
                { no: 4, name: '' },
                { no: 5, name: '' },
                { no: 6, name: '' },
                { no: 7, name: '' },
                { no: 8, name: '' },
                { no: 9, name: '' },
                { no: 10, name: '' }
            ],
            rota: Array(10).fill(''),
            rotaGenerated: false
        };
        this.engineerNameChange = this.engineerNameChange.bind(this);
        this.randomizeRota = this.randomizeRota.bind(this);
        this.fetchEngineers = this.fetchEngineers.bind(this);
    }

    engineerNameChange(no, name) {
        const allEngineers = this.state.engineers.slice();
        const updatedEngineers = allEngineers.map((engineer) => {
            if (engineer.no === no) {
                engineer.name = name;
            }
            return engineer;
        });
        this.setState({
            engineers: updatedEngineers
        });
    }

    randomizeRota() {
        console.log("fetching rota");
        const engineers = this.state.engineers;
        this.fetchRotaDataAsync(engineers);
    }

    async fetchRotaDataAsync(rotaList) {
        const data = {
            engineers: rotaList.map(engineer => {
                return {
                    name: engineer.name
                };
            })
        };

        const response = await fetch('rota', {
            method: 'POST',
            body: JSON.stringify(data),
            headers: {
                'Content-Type': 'application/json'
            }
        });
        const newRota = await response.json();
        this.setState({
            rota: newRota,
            rotaGenerated: true
        });
    }

    fetchEngineers() {
        console.log("fetch engineers");
        this.fetchEngineersDataAsync();
    }

    async fetchEngineersDataAsync() {
        const response = await fetch('rota');
        const engineerNames = await response.json();
        const engineers = engineerNames.map((name, i) => {
            return { no: i + 1, name };
        });

        for (let i = engineers.length; i < 10; i++)
            engineers.push({ no: i, name: '' });

        this.setState({
            engineers
        });
    }

    renderWeek() {
        const week = this.state.rota;
        const mondayAm = week[0],
            mondayPm = week[1],
            tuesdayAm = week[2],
            tuesdayPm = week[3],
            wednesdayAm = week[4],
            wednesdayPm = week[5],
            thursdayAm = week[6],
            thursdayPm = week[7],
            fridayAm = week[8],
            fridayPm = week[9];

        if (!this.state.rotaGenerated) {
            return (null);
        }

        return (
            <div className="pt-4">
                <h2>Week 1</h2>
                <WeekPlan mondayAm={mondayAm} mondayPm={mondayPm} tuesdayAm={tuesdayAm} tuesdayPm={tuesdayPm} wednesdayAm={wednesdayAm} wednesdayPm={wednesdayPm} thursdayAm={thursdayAm} thursdayPm={thursdayPm} fridayAm={fridayAm} fridayPm={fridayPm} />
                <h2>Week 2</h2>
                <WeekPlan mondayAm={mondayAm} mondayPm={mondayPm} tuesdayAm={tuesdayAm} tuesdayPm={tuesdayPm} wednesdayAm={wednesdayAm} wednesdayPm={wednesdayPm} thursdayAm={thursdayAm} thursdayPm={thursdayPm} fridayAm={fridayAm} fridayPm={fridayPm} />
            </div>
        );
    }

    render() {
        const engineers = this.state.engineers;
        const engineerRows = engineers.map(engineer => {
            return (
                <Engineer key={engineer.no} no={engineer.no} onChange={this.engineerNameChange} name={engineer.name} />
            );
        });

        return (
            <div>
                <h1>The Support Wheel Of Fate</h1>
                <p>Please enter names of the enginners to go onto the rota, or you could click the 'Load Engineers' button to fetch the engineers from the database</p>
                <p>When ready, hit the 'Randomize' button to display the new rota</p>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Engineer Names</th>
                        </tr>
                    </thead>
                    <tbody>
                        {engineerRows}
                    </tbody>
                </table>
                <button className="btn btn-primary" onClick={this.randomizeRota}>Randomize</button>
                <button className="btn btn-secondary ms-4" onClick={this.fetchEngineers}>Load Engineers</button>
                {this.renderWeek()}
            </div>
        );
    };
}