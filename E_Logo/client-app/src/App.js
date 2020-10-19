import React from 'react';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import Login from "./components/login.component";
import PatientsList from './components/patientslist.component';
import TasksList from '././components/task1list.component'
import AuthService from "./services/AuthService";
import { useSelector } from "react-redux";

//const [isLoggedIn, setIsLoggedIn] = React.useState(false);

const isLoggedIn = AuthService.loggedIn();

function App() {
  const userConnected = useSelector((state) => state.userConnected);
  return (<Router>
    <div className="App">
      <nav className="navbar navbar-expand-lg navbar-light fixed-top">
        <div className="container">
          <div className="collapse navbar-collapse" id="navbarTogglerDemo02">
            <ul className="navbar-nav ml-auto">
              { !isLoggedIn ? (
               <li className="nav-item">
                <Link className="nav-link" to={"/"}>Login</Link>
              </li> 
              ) : isLoggedIn || userConnected.id !== null || userConnected.id !== -1?(
                <> 
              <li className="nav-item">
                <Link className="nav-link" to={"/patients"}>Patients List</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to={"/tasks"}>Tasks List</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" onClick={AuthService.logout} to={"/"}>Logout</Link>
              </li>
                </>
              ):null}

             
            </ul>
          </div>
        </div>
      </nav>

      <div className="auth-wrapper">
        <div className="auth-inner">
          <Switch>
            <Route exact path='/' component={Login} />
            <Route path="/patients" component={PatientsList} />
            <Route path="/tasks" component ={TasksList}/>
            <Route path="/" component={Login} />
          </Switch>
        </div>
      </div>
    </div></Router>
  );
}

export default App;





