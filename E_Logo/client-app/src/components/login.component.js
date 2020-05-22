import React, { Component } from "react";
import AuthService from "./Auth/AuthService";

const Auth = new AuthService();
export default class Login extends Component {
    constructor(props){

        
        super(props);
        this.state = {
            email : "",
            password: "",
            invalidLogin : false
        };
    }

    // componentDidUpdate(){
    //     console.log(this.state);
    //     if(Auth.loggedIn() === true){
    //       //  this.props.history.replace('/home');
    //     }
    // }
    
    handleChange = event => {
        this.setState({
            [event.target.id] : event.target.value
        });
        this.setState({
            invalidLogin: false
        });
    }

    handleSubmit = event =>{
        event.preventDefault();
        const api_call =  Auth.login(this.state.email, this.state.password);
        if(api_call){
            //this.props.history.replace('/home');
            console.log(this.state);
            this.setState({
                invalidLogin: false
            });
        }else{
            this.setState({
                invalidLogin: true
            });
        }
    }

    validateForm(){
        return this.state.email.length > 0 && this.state.password.length > 0;
    }

    render() {
        return (
            <form>
                <h3>Log In</h3>

                <div className="form-group">
                    <label>Email address</label>
                    <input type="text" value ={this.state.email} id="email" onChange={this.handleChange} className="form-control" placeholder="Enter email" />
                </div>

                <div className="form-group">
                    <label>Password</label>
                    <input type="password"  value={this.state.password} id="password" onChange={this.handleChange} className="form-control" placeholder="Enter password" />
                </div>

                <button type="submit" onClick={this.handleSubmit} className="btn btn-primary btn-block">Submit</button>

            </form>
        );
    }
}