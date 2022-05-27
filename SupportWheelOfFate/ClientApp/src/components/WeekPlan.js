import WeekDay from './WeekDay';

function WeekPlan(props) {
    return (
        <table className="table table-striped">
            <thead>
                <tr>
                    <th>Day</th>
                    <th>Morning</th>
                    <th>Afternoon</th>
                </tr>
            </thead>
            <tbody>
                <WeekDay day={"Monday"} morning={props.mondayAm} afternoon={props.mondayPm} />
                <WeekDay day={"Tuesday"} morning={props.tuesdayAm} afternoon={props.tuesdayPm} />
                <WeekDay day={"Wednesday"} morning={props.wednesdayAm} afternoon={props.wednesdayPm} />
                <WeekDay day={"Thursday"} morning={props.thursdayAm} afternoon={props.thursdayPm} />
                <WeekDay day={"Friday"} morning={props.fridayAm} afternoon={props.fridayPm} />
            </tbody>
        </table>
    )
}

export default WeekPlan;