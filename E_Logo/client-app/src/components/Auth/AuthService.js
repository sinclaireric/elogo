import decode from 'jwt-decode'

export default class AuthService{
    constructor(){
        this.domain = 'https://localhost:5001/api/SpeechTherapists/authenticate'
    }


    async login(email, password)
    {
        const postBody =  { 'email' : email, 'password' : password};
        
        const postObject = {
          method: 'POST',
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(postBody)
        }


        const api_call =  await fetch(this.domain, postObject);
        const data = await api_call.json();
       if(data.token != null){
            console.log("token is seet");
            this.setToken(data.token);
            return data;
         }
         else 
             return null;
    }
    setToken(token)
    {
        sessionStorage.setItem('token', token);
    }

    getToken()
    {
        return sessionStorage.getItem('token');
    }
    logout()
    {
        sessionStorage.removeItem('token');
    }
    loggedIn()
    {
        const token = this.getToken();
        return !!token && !this.isTokenExpired(token);
    }
    checkResponseStatus(response)
    {
       
        // raises an error in case response status is not a success
        if (response.status >= 200 && response.status < 300) { // Success status lies between 200 to 300
            console.log(response);
            return true
        } else {
           
            console.log(response);
            return false;
        }
    }
    isTokenExpired(token){
        try
        {
            const decoded = decode(token);
            if(decoded.exp < Date.now() / 1000)
            {
                return true;
            }
            else
            {  
                return false;
            }
        }
        catch(error)
        {
            return false;
        }
    }
    getProfile(){
        return decode(this.getToken());
    }


    
}