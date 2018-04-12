import axios from "axios";

const uri = '/api';

export default {
    async fetchUgovore() {
        const response = await axios.get(`${uri}/ugovor/`);
        return response.data;
    },
    async fetchUgovor(id) {
        const response = await axios.get(`${uri}/ugovor/${id}`);
        return response.data;
    },
    async pushUgovor(ugovor) {
        const response = await axios.post(`${uri}/ugovor/`, ugovor);
        return response.data;
    },
    async fetchSlobodnaMjesta() {
        const response = await axios.get(`${uri}/ugovor/mjesta`);
        return response.data;
    },
    async fetchKorisnici(name) {
        const response = await axios.get(`${uri}/korisnik/${name ? name : ''}`);
        return response.data;
    },
    async fetchKorisnik(id) {
        const response = await axios.get(`${uri}/korisnik/${id}`);
        return response.data;
    },
    async pushKorisnik(korisnik) {
        const response = await axios.post(`${uri}/korisnik/`, korisnik);
        return response.data;
    }
};