import React, { Component } from "react";
import { bindActionCreators } from "redux";
import * as STActions from "../redux/STActionCreator";
import { connect } from "react-redux";

class Login extends Component {
    constructor(props) {


        super(props);
        this.state = {
            email: "",
            password: "",
            invalidLogin: false,
            error: "",
        };
    }


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
        await this.props.getUserConnected(this.state.email, this.state.password);
        if (this.props.STReducer.error === undefined) {
            this.setState({
                invalidLogin: false
            });
            setTimeout(() => { this.props.history.replace('/home') }, 1000);
        } else {
            this.setState({
                error: this.props.STReducer.error,
                invalidLogin: true
            });
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

const mapDispatchToProps = (dispatch) => ({
    getUserConnected: bindActionCreators(STActions.getUserConnected, dispatch),
});

const mapStateToProps = state => ({
    STReducer: state.userConnected,
});

const LoginContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(Login)

export default LoginContainer;
