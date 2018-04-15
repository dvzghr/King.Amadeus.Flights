import React, {Component} from 'react';
import Itineraries from "./components/Itineraries";
import api from "./utils/api";
import './bootswatch.css'
import moment from "moment";

moment.locale('hr');

export default class Home extends Component {
    displayName = Home.name

    constructor(props) {
        super(props);

        this.state = {
            results: [],
            loaded: false,
            query: {
                origin: 'BOS',
                destination: 'LON',
                departureDate: moment().format('YYYY-MM-DD'),
                returnDate: moment().add(1, 'd').format('YYYY-MM-DD'),
                numberOfPassengers: 1,
                currency: 'USD'
            },
            responseTime: 0
        };

        this.loadFlights = this.loadFlights.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(e) {
        const newVal = e.target.value;
        const changedProp = e.target.name;
        const {query} = this.state;
        this.setState({
            query: {
                ...query,
                [changedProp]: newVal
            }
        });
    }

    loadFlights(e) {
        e.preventDefault();
        const startTime = moment();

        const {query} = this.state;

        api.fetchFlights(query)
            .then(results => {
                this.setState(
                    {
                        results,
                        loaded: true,
                        responseTime: moment.duration(moment().diff(startTime)).asMilliseconds()
                    });
            });
    }

    render() {
        const {origin, destination, departureDate, returnDate, numberOfPassengers, currency} = this.state.query;
        const {results, loaded, responseTime} = this.state;
        const {handleChange, loadFlights} = this;

        return (
            <div className='container-fluid'>
                <h1>KING ICT TEST: AMADEUS FLIGHT SEARCH</h1>
                <div className="input-group mb-3">
                    <div className="input-group-prepend">
                        <label className="input-group-text">ORIGIN AIRPORT CODE</label>
                    </div>
                    <input type="text"
                           className="form-control"
                           name='origin'
                           onChange={handleChange}
                           value={origin}/>
                    <div className="invalid-feedback">
                        REQUIRED
                    </div>
                </div>
                <div className="input-group mb-3">
                    <div className="input-group-prepend">
                        <span className="input-group-text">DESTINATION AIRPORT CODE</span>
                    </div>
                    <input type="text"
                           className="form-control"
                           name='destination'
                           onChange={handleChange}
                           value={destination}/>
                    <div className="invalid-feedback">
                        REQUIRED
                    </div>
                </div>
                <div className="input-group mb-3">
                    <div className="input-group-prepend">
                        <span className="input-group-text">DEPARTURE DATE</span>
                    </div>
                    <input type="date"
                           className="form-control"
                           name='departureDate'
                           onChange={handleChange}
                           value={departureDate}/>
                    <div className="invalid-feedback">
                        REQUIRED
                    </div>
                </div>
                <div className="input-group mb-3">
                    <div className="input-group-prepend">
                        <span className="input-group-text">RETURN DATE</span>
                    </div>
                    <input type="date"
                           className="form-control"
                           name='returnDate'
                           onChange={handleChange}
                           value={returnDate}/>
                    <div className="invalid-feedback">
                        REQUIRED
                    </div>
                </div>
                <div className="input-group mb-3">
                    <div className="input-group-prepend">
                        <span className="input-group-text">NUMBER OF PASSENGERS</span>
                    </div>
                    <input type="number"
                           className="form-control"
                           name='numberOfPassengers'
                           onChange={handleChange}
                           value={numberOfPassengers}/>
                    <div className="invalid-feedback">
                        REQUIRED
                    </div>
                </div>
                <div className="input-group mb-3">
                    <div className="input-group-prepend">
                        <span className="input-group-text">CURRENCY</span>
                    </div>
                    <input type="text"
                           className="form-control"
                           name='currency'
                           onChange={handleChange}
                           value={currency}/>
                    <div className="invalid-feedback">
                        REQUIRED
                    </div>
                </div>
                <button className='btn btn-primary' onClick={loadFlights}>
                    SEARCH
                </button>
                {
                    loaded && results.length ?
                        <div>Search took: {responseTime} ms...{responseTime < 100 ? "whohoah that was fast :)" : ""}</div>
                        :
                        null
                }

                <hr/>
                {
                    !results.length ?
                        loaded ?
                            <div>No flights could be found!</div>
                            :
                            <div>Start search.</div>
                        :
                        results.map((result, idx) => <Itineraries key={idx} list={result} numberOfPassengers={numberOfPassengers} currency={currency}/>)
                }
            </div>
        );
    }
}