import { Component } from 'react';

export class Engineer extends Component {
    constructor(props) {
        super(props);
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(e) {
        this.props.onChange(this.props.no, e.target.value);
    }

    render() {
        let no = this.props.no;
        return (
            <tr key={no}>
                <td><input key={no} type="text" onChange={this.handleChange} value={this.props.name} /></td>
            </tr>
        );
    };
}
