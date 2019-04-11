import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Redirect } from "react-router-dom";
import axios from 'axios';
import Swal from 'sweetalert2';
import ReactLoading from 'react-loading';


//let $ = require('jquery');

interface ILogin {
    username: string,
    password: string,
    error: string,
    key: number,
    loading: boolean,
    confirmpassword: string,
    shouldRedirect: boolean
}

export class Login extends React.Component<RouteComponentProps<{}>, ILogin> {
    constructor() {
        super();
        this.state = {
            username: '',
            password: '',
            confirmpassword: '',
            error: '',
            key: 1,
            loading: false,
            shouldRedirect: false
        };

        this.handlePassChange = this.handlePassChange.bind(this);
        this.handleUserChange = this.handleUserChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.dismissError = this.dismissError.bind(this);
    }


    


    handleSelect(key: number) {
        alert(`selected ${key}`);
        this.setState({ key });
    }

    componentDidMount() {
        //initialisation goes here.
       
       
    }

    handleLoading() {

        <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}><ReactLoading type="spin" color="blue" height={667} width={375} /></div>
    }

    dismissError() {
        this.setState({ error: '' });
    }

    handleSubmit(evt: React.FormEvent<HTMLFormElement>) {

        evt.preventDefault();

        this.setState({ loading: true });

        if (this.state.loading) {

            this.handleLoading();
        }
        if (!this.state.username) {
            this.setState({ loading: false });
            return this.setState({ error: 'usuario es obligatorio' });
        }

        if (!this.state.password) {
            this.setState({ loading: false });
            return this.setState({ error: 'La clave es obligatoria' });
        }

        let data = JSON.stringify({
            password: this.state.password,
            username: this.state.username

        });

        let headers = {
            'Content-Type': 'application/json',
            'Authorization': "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOjEsImlzcyI6Imh0dHA6Ly9hcHBzZGF0YTIuY2xvdWRhcHAubmV0L2p3dC1kZW1vL3B1YmxpYy9hcGkvbG9naW4iLCJpYXQiOjE1MDYzMzkwNDgsImV4cCI6MTY2MTg1OTA0OCwibmJmIjoxNTA2MzM5MDQ4LCJqdGkiOiJHUWt5RVlwck5GSDBHekd4In0.JqdyAEkEN_D3M2WbqcQwIwghk6iajFjxi9g854akjB8"
        }



        if (this.state.error === '') {

            axios.post(`api/logon/logon`,
                data,
                { headers: headers })
                .then((response) => {
                    console.log("reactNativeDemo", "response get details:" + response.data);
                    this.setState({ shouldRedirect: true });
                    this.setState({ loading: false });
                    sessionStorage.setItem("user", this.state.username);   
                    Swal(
                        'Login Correcto!',
                        'Haga clic en el botón',
                        'success'
                    )
                    window.location.reload()

                })
                .catch((error) => {
                    this.setState({ loading: false });
                    console.log("axios error:", error);
                    Swal(
                        'Login Incorrecto!',
                        error,
                        'error'
                    )
                });
        }

       

        return this.setState({ error: '' });
    }

    handleUserChange(evt: React.SyntheticEvent<HTMLInputElement>) {
        this.setState({
            username: evt.currentTarget.value,
        });
    };

    handlePassChange(evt: React.SyntheticEvent<HTMLInputElement>) {
        this.setState({
            password: evt.currentTarget.value,
        });
    }


    public render() {


        return <div>
            {
                this.state.shouldRedirect ?
                

                    <Redirect to="/" push />                  
                    
                    
                    :

                    this.state.loading ?

                        <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}><ReactLoading type="spin" color="blue" height={667} width={375} /></div>

                        :
                   
                    <div className="container white z-depth-2">                       
                        <ul className="tabs teal">
                            <li className="tab col s3"><a className="white-text active" href="#login">Login</a></li>
                        </ul>
                        <div classID="login" className="col s12">
                            <form className="col s12" onSubmit={this.handleSubmit}>
                                {
                                    this.state.error &&
                                    <h3 data-test="error" onClick={this.dismissError}>
                                        <button onClick={this.dismissError}>✖</button>
                                        {this.state.error}
                                    </h3>
                                }
                                <div className="form-container">
                                    <h3 className="teal-text">Login</h3>
                                    <div className="row">
                                        <div className="input-field col s12">
                                            <input classID="email" className="validate" type="text" data-test="username" value={this.state.username} onChange={this.handleUserChange} />
                                            <label >Email/Usuario</label>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="input-field col s12">
                                            <input classID="password" type="password" data-test="password" value={this.state.password} onChange={this.handlePassChange} className="validate" />
                                            <label>Clave</label>
                                        </div>
                                    </div>
                                    <br />
                                    <div className="text-center">
                                        <button className="btn waves-effect waves-light teal" type="submit" value="Log In" data-test="submit" name="action">Acceder</button>
                                        {this.state.loading && this.handleLoading()}
                                        <br />
                                        <br />
                                        <a href="">Olvide la Clave?</a>
                                    </div>
                                </div>
                            </form>
                        </div>


                    </div>

            }

        </div>;
    }

}


