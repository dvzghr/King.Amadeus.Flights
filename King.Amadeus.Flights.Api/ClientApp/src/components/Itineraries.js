import React, {Component} from 'react';
import moment from "moment";

moment.locale('hr');

export default class Itineraries extends Component {

    constructor(props) {
        super(props)

    }

    render() {
        const {itineraries, totalPrice} = this.props.list;
        const { numberOfPassengers, currency } = this.props;

        return (
            <div className="card">
                <div className="card-header text-white bg-primary">
                    Total: {totalPrice} {currency} Number of passengers: {numberOfPassengers}
                </div>
                <ul className="list-group list-group-flush">
                    {itineraries.map((itinerary, idx) =>
                        (
                            <li key={idx} className="list-group-item">
                                <h5><strong>OPTION #{++idx}:</strong> OUTBOUND TRANSFERS: {itinerary.outboundTransfers}    INBOUND TRANSFERS: {itinerary.inboundTransfers}</h5>
                                <hr/>
                                <h6>Outbound flights</h6>
                                <FlightList list={itinerary.outboundFlights}/>
                                <h6>Inbound flights</h6>
                                <FlightList list={itinerary.inboundFlights}/>
                            </li>
                        )
                    )}
                </ul>
            </div>
        )
    }
}


const FlightList = (props) =>
    (
        <table className='table table-sm'>
            <thead className='thead-light'>
            <tr>
                <th>#</th>
                <th>Origin</th>
                <th>Destination</th>
                <th>Departure Date</th>
                <th>Arrival Date</th>
            </tr>
            </thead>
            <tbody>
            {props.list.map((flight, idx) =>
                (
                    <tr key={idx}>
                        <td>{++idx}</td>
                        <td>{flight.origin}</td>
                        <td>{flight.destination}</td>
                        <td>{moment(flight.departureDate).format('DD.MM.YYYY, HH:mm')}h</td>
                        <td>{moment(flight.arrivalDate).format('DD.MM.YYYY, HH:mm')}h</td>
                    </tr>
                )
            )}
            </tbody>
        </table>
    )

















