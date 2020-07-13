import decode from 'jwt-decode'

export default class AuthService {
    constructor() {
        this.domain = 'http://localhost:5000/api/SpeechTherapists/authenticate'
    }


    async login(email, password) {
        const postBody = { 'email': email, 'password': password };

        const postObject = {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(postBody)
        }

        try {
            const api_call = await fetch(this.domain, postObject);
            console.log(api_call);
            const data = await api_call.json();
            console.log(data);
            if (data.token != null) {
                console.log("token is seet");
                this.setToken(data.token);
                return { data: data, error: null };
            }
            else
                return { data: null, error: data.message };
        } catch (err) {
            console.log(err.message)

        }


    }
    setToken(token) {
        sessionStorage.setItem('token', token);
    }

    getToken() {
        return sessionStorage.getItem('token');
    }
    
    logout() {
        console.log("logount confirm");
        sessionStorage.clear();
        sessionStorage.removeItem('token');
    }
    loggedIn() {
        const token = this.getToken();
        return !!token && !this.isTokenExpired(token);
    }
    checkResponseStatus(response) {

        // raises an error in case response status is not a success
        if (response.status >= 200 && response.status < 300) { // Success status lies between 200 to 300
            console.log(response);
            return true
        } else {

            console.log(response);
            return false;
        }
    }
    isTokenExpired(token) {
        try {
            const decoded = decode(token);
            if (decoded.exp < Date.now() / 1000) {
                return true;
            }
            else {
                return false;
            }
        }
        catch (error) {
            return false;
        }
    }
    getProfile() {
        return decode(this.getToken());
    }



}