import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Redirect } from "react-router-dom";
import axios from 'axios';
import Swal from 'sweetalert2';
import ReactLoading from 'react-loading';


interface IReplenishProduct {
    productCode: string,
    quantity: number,
    error: string,
    key: number,
    loading: boolean,
    confirmpassword: string,
    shouldRedirect: boolean
}

export class ReplenishProduct extends React.Component<RouteComponentProps<{}>, IReplenishProduct> {
    constructor() {
        super();
        this.state = {
            productCode: '',
            quantity: 0,
            confirmpassword: '',
            error: '',
            key: 1,
            loading: false,
            shouldRedirect: false
        };

        this.handleProductCodeChange = this.handleProductCodeChange.bind(this);
        this.handlequantityChange = this.handlequantityChange.bind(this);
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
        if (this.state.productCode === "") {
            this.setState({ loading: false });
            return this.setState({ error: 'El codigo del Producto es obligatorio' });
        }

        if (this.state.quantity < 0) {
            this.setState({ loading: false });
            return this.setState({ error: 'La cantidad es obligatoria' });
        }

        let data = JSON.stringify({
            ProductCode: this.state.productCode,
            Quantity: this.state.quantity

        });

        let headers = {
            'Content-Type': 'application/json',
            'Authorization': "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOjEsImlzcyI6Imh0dHA6Ly9hcHBzZGF0YTIuY2xvdWRhcHAubmV0L2p3dC1kZW1vL3B1YmxpYy9hcGkvbG9naW4iLCJpYXQiOjE1MDYzMzkwNDgsImV4cCI6MTY2MTg1OTA0OCwibmJmIjoxNTA2MzM5MDQ4LCJqdGkiOiJHUWt5RVlwck5GSDBHekd4In0.JqdyAEkEN_D3M2WbqcQwIwghk6iajFjxi9g854akjB8"
        }



        if (this.state.error === '') {

            axios.post(`api/Product/replenishproduct`,
                data,
                { headers: headers })
                .then((response) => {

                    this.setState({ shouldRedirect: true });

                    this.setState({ loading: false });
                    Swal(
                        'Producto Repuesto Correctamente',
                        'Haga clic en el botón',
                        'success'
                    )
                    window.location.reload()

                })
                .catch((error) => {
                    this.setState({ loading: false });
                    console.log("axios error:", error);
                    Swal(
                        'Hubo un error',
                        error,
                        'error'
                    )
                });
        }

       

        return this.setState({ error: '' });
    }

    handleProductCodeChange(evt: React.SyntheticEvent<HTMLInputElement>) {
        this.setState({
            productCode: evt.currentTarget.value,
        });
    };

    handlequantityChange(evt: React.SyntheticEvent<HTMLInputElement>) {
        this.setState({
            quantity: Number(evt.currentTarget.value),
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
                            <li className="tab col s3"><a className="white-text active" href="">Reponer Productos</a></li>
                        </ul>
                        <div classID="" className="col s12">
                            <form className="col s12" onSubmit={this.handleSubmit}>
                                {
                                    this.state.error &&
                                    <h3 data-test="error" onClick={this.dismissError}>
                                        <button onClick={this.dismissError}>✖</button>
                                        {this.state.error}
                                    </h3>
                                }
                                    <div className="form-container">
                                        <br />
                                        <br />
                                        <br />
                                    <div className="row">
                                            <div className="input-field col s12">
                                                <input classID="productCode" autoFocus className="validate" type="text" data-test="productCode" value={this.state.productCode} onChange={this.handleProductCodeChange} />
                                            <label >Codigo del Producto</label>
                                        </div>
                                    </div>
                                    <div className="row">
                                            <div className="input-field col s12">
                                                <input classID="quantity" autoFocus type="number" data-test="quantity" value={this.state.quantity} onChange={this.handlequantityChange} className="validate" />
                                            <label>Cantidad</label>
                                        </div>
                                    </div>
                                    <br />
                                    <div className="text-center">
                                        <button className="btn waves-effect waves-light teal" type="submit" value="Log In" data-test="submit" name="action">Guardar</button>
                                        {this.state.loading && this.handleLoading()}
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </form>
                        </div>


                    </div>

            }

        </div>;
    }

}


