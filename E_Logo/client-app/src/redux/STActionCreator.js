import AuthService from "../services/AuthService";
import * as types from "../redux/STTypes";

export const getUserConnected = (email,password) => async dispatch => {
    let result = null;
    let error ="";

    try{
        result = await AuthService.login(email, password);
    }catch (err) {
        error = err;
    }

    if(result.data !== null){
        dispatch({
            type : types.GET_USER_CONNECTED,
            payload : result.data
        })
    }else{
        dispatch({
            type : types.ERROR,
            payload : result.error
        })
    }

    
}
    