import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Redirect } from "react-router-dom";
import axios from 'axios';
import Swal from 'sweetalert2';
import ReactLoading from 'react-loading';



//let $ = require('jquery');

interface IRegister {
    nombre: string,
    apellidos: string,
    password: string,
    confirmpassword: string,
    email: string,
    emailconfirmacion: string,
    error: string,
    key: number,
    loading: boolean,
    shouldRedirect: boolean
}

export class Register extends React.Component<RouteComponentProps<{}>, IRegister> {
    constructor() {
        super();
        this.state = {
            nombre: '',
            apellidos: '',
            password: '',
            confirmpassword: '',
            email: '',
            emailconfirmacion: '',
            error: '',
            key: 1,
            loading: false,
            shouldRedirect: false
        };

        this.handlePassChange = this.handlePassChange.bind(this);
        this.handleNombreChange = this.handleNombreChange.bind(this);
        this.handleApellidosChange = this.handleApellidosChange.bind(this);
        this.handleEmailChange = this.handleEmailChange.bind(this);
        this.handleConfirmPasswordChange = this.handleConfirmPasswordChange.bind(this);      
        this.handleEmailconfirmacionChange = this.handleEmailconfirmacionChange.bind(this);      

         
    
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

        //Validaciones antes del registro
        if (!this.state.email) {
            this.setState({ loading: false });
            return this.setState({ error: 'usuario es obligatorio' });
        }

        if (!this.state.password) {
            this.setState({ loading: false });
            return this.setState({ error: 'La clave es obligatoria' });
        }

        let data = JSON.stringify({
            nombre: this.state.nombre,
            apellidos: this.state.apellidos,
            password: this.state.password,
            confirmpassword: this.state.confirmpassword,
            email: this.state.email,
            emailconfirmacion: this.state.emailconfirmacion

        });

        let headers = {
            'Content-Type': 'application/json',
            'Authorization': "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOjEsImlzcyI6Imh0dHA6Ly9hcHBzZGF0YTIuY2xvdWRhcHAubmV0L2p3dC1kZW1vL3B1YmxpYy9hcGkvbG9naW4iLCJpYXQiOjE1MDYzMzkwNDgsImV4cCI6MTY2MTg1OTA0OCwibmJmIjoxNTA2MzM5MDQ4LCJqdGkiOiJHUWt5RVlwck5GSDBHekd4In0.JqdyAEkEN_D3M2WbqcQwIwghk6iajFjxi9g854akjB8"
        }



        if (this.state.error === '') {

            axios.post(`api/logon/register`,
                data,
                { headers: headers })
                .then((response) => {
                    console.log("Respuesta: " + response.data);

                    if (response.data === "Ok") {
                        this.setState({ loading: false });
                        Swal(
                            'Registro Correcto!',
                              response.data,
                            'success'
                        )
                        this.setState({ shouldRedirect: true });

                        sessionStorage.setItem("user", this.state.email);    
                        window.location.reload();

                    } else {
                        this.setState({ loading: false });

                        Swal(
                            'Registro Incorrecto!',
                            response.data,
                            'error'
                        )
                    }
                   
              
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

    handleNombreChange(evt: React.SyntheticEvent<HTMLInputElement>) {
        this.setState({
            nombre: evt.currentTarget.value,
        });
    };

    handlePassChange(evt: React.SyntheticEvent<HTMLInputElement>) {
        this.setState({
            password: evt.currentTarget.value,
        });
    }

    handleApellidosChange(evt: React.SyntheticEvent<HTMLInputElement>) {
        this.setState({
            apellidos: evt.currentTarget.value,
        });
    }

    handleEmailChange(evt: React.SyntheticEvent<HTMLInputElement>) {
        this.setState({
            email: evt.currentTarget.value,
        });
    }

    handleEmailconfirmacionChange(evt: React.SyntheticEvent<HTMLInputElement>) {
        this.setState({
            emailconfirmacion: evt.currentTarget.value,
        });
    }


    handleConfirmPasswordChange(evt: React.SyntheticEvent<HTMLInputElement>) {
        this.setState({
            confirmpassword: evt.currentTarget.value,
        });
    }
    


    public render() {


        return <div>
            {
                this.state.shouldRedirect ?

                    <Redirect to="/" push /> :

                    this.state.loading ?

                        <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}><ReactLoading type="spin" color="blue" height={667} width={375} /></div>

                        :

                    <div className="container white z-depth-2">
                        <ul className="tabs teal">
                            <li className="tab col s3"><a className="white-text active" href="#register">Registrarse</a></li>
                        </ul>

                        <div classID="register" className="col s12">
                            <form className="col s12" onSubmit={this.handleSubmit}>
                                <div className="form-container">
                                    
                                    <div className="row">
                                        <div className="input-field col s6">
                                            <input id="last_name" type="text" className="validate" value={this.state.nombre} onChange={this.handleNombreChange} />
                                            <label>Nombre</label>
                                        </div>
                                        <div className="input-field col s6">
                                            <input classID="last_name" type="text" className="validate" value={this.state.apellidos} onChange={this.handleApellidosChange} />
                                            <label>Apellidos</label>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="input-field col s12">
                                            <input id="email" type="email" className="validate" value={this.state.email} onChange={this.handleEmailChange} />
                                            <label>Email</label>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="input-field col s12">
                                            <input id="email-confirm" type="email" className="validate" value={this.state.emailconfirmacion} onChange={this.handleEmailconfirmacionChange} />
                                            <label>Email Confirmación</label>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="input-field col s12">
                                            <input id="password" type="password" className="validate" value={this.state.password} onChange={this.handlePassChange} />
                                            <label>Contraseña</label>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="input-field col s12">
                                            <input classID="password-confirm" type="password" className="validate" value={this.state.confirmpassword} onChange={this.handleConfirmPasswordChange} />
                                            <label>Contraseña Confirmación</label>
                                        </div>
                                    </div>
                                    <br/>
                                    <div className="text-center">
                                        <button className="btn waves-effect waves-light teal" type="submit" name="action">Enviar</button>
                                    </div>
                                    <br />
                                </div>
                            </form>
                        </div>


                    </div>

            }

        </div>;
    }

}


