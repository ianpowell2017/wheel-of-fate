function WeekDay(props) {
    return (
        <tr>
            <td>{props.day}</td>
            <td>{props.morning}</td>
            <td>{props.afternoon}</td>
        </tr>
    )
}

export default WeekDay;