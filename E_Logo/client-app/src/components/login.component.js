import React, { Component } from "react";
import AuthService from "./services/AuthService";


const Auth = new AuthService();
export default class Login extends Component {
    constructor(props) {


        super(props);
        this.state = {
            email: "",
            password: "",
            invalidLogin: false,
            error: "",
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
            [event.target.id]: event.target.value
        });
        this.setState({
            invalidLogin: false
        });
    }

    handleSubmit = async event => {
        event.preventDefault();
        const api_call = await Auth.login(this.state.email, this.state.password);
        if (api_call) {
            if (api_call.data) {
                this.props.history.replace('/home');
                //console.log(this.state);
                this.setState({
                    invalidLogin: false
                });
            } else {
                this.setState({
                    error: api_call.error,
                    invalidLogin: true
                });
            }
        }
    }

    validateForm() {
        return this.state.email.length > 0 && this.state.password.length > 0;
    }

    render() {
        return (
            <form>
                <h3>Log In</h3>

                <div className="form-group">
                    <label>Email address</label>
                    <input type="text" value={this.state.email} id="email" onChange={this.handleChange} className="form-control" placeholder="Enter email" />
                </div>

                <div className="form-group">
                    <label>Password</label>
                    <input type="password" value={this.state.password} id="password" onChange={this.handleChange} className="form-control" placeholder="Enter password" />
                </div>

                <button type="submit" background-colod="rgb(247, 79, 101)" disabled={!this.validateForm()} onClick={this.handleSubmit} className="btn btn-danger btn-primary btn-block">Submit</button>
                {this.state.error ? <div color="red">{this.state.error}</div> : null}
            </form>
        );
    }
}