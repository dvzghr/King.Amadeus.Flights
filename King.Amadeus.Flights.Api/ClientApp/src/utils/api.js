import axios from "axios";

const uri = '/api/flightsearch';

const fetchFlights = query => axios.get(uri, {params: {...query}})
    .then(response => response.data)
    .catch(error => {
        if (error.response.status != 404) {
            alert(error.response.data.message);
        }
        return [];
    });

export default {fetchFlights};