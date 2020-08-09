import {combineReducers} from "redux";
import STReducer from "../redux/STReducer";

const rootReducer = combineReducers({
    userConnected : STReducer,
})

export default rootReducer;