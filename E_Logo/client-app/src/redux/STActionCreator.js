import AuthService from "../services/AuthService";
import * as types from "../redux/STTypes";

export const getUserConnected = (email,password) => async dispatch => {
    let result = null;
    let error ="";

    try{
        result = await AuthService.login(email, password);
        console.log(result);
    }catch (err) {
        error = err;
    }

    if(result !== null){
        dispatch({
            type : types.GET_USER_CONNECTED,
            payload : result
        })
    }else{
        dispatch({
            type : types.ERROR,
            payload : error
        })
    }

    
}
    