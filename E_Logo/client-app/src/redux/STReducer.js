import { GET_USER_CONNECTED, ERROR } from "../redux/STTypes";

const initialState = {
    id: sessionStorage.getItem('currentUserID'),
    password: null,
    email: "",
    lastName: "",
    firstName: "",
    token: "",
    error: "default",
}

export default (state = initialState, action) => {
    switch (action.type) {
        case GET_USER_CONNECTED:
            return action.payload;
        case ERROR:
            return {
                ...state, error: action.payload
            };
        default:
            return state;
    }
}