import { GET_USER_CONNECTED, ERROR } from "../redux/STTypes";

const initialState = {
    id: -1,
    password: null,
    email: "",
    lastName: "",
    firstName: "",
    token: "",
    error: "",
}

export default (state = initialState, action) => {
    console.log(action.payload);
    switch (action.type) {
        case GET_USER_CONNECTED:
            return action.payload.data;

        case ERROR:
            return {
                ...state, error: action.payload.message
            };
        default:
            return state;
    }
}