//import * as React from 'react';
//import { RouteComponentProps } from 'react-router';
//import { Redirect } from "react-router-dom";
//import axios from 'axios';
//import Swal from 'sweetalert2';
//import ReactLoading from 'react-loading';
//import { Book } from './Book';
//import { FormEvent, FormEventHandler } from 'react';

//interface IBook {
//    BookId: number;
//    Name: string;
//    Description: string;
//    CoverPageImg: FormData;
//    TotalPages: number;
//    Author: string;
//    BooksTypesName: string;
//    error: string,
//    key: number,
//    loading: boolean,
//    shouldRedirect: boolean,
//    editMode: boolean
//}

//export class AddEditProduct extends React.Component<RouteComponentProps<{}>, IBook> {
//    public file: File;
//    constructor() {
//        super();

//        this.state = {
//            Name: '',
//            ProductCode: '',
//            Description: '',
//            Quantity: 0,
//            Img: null,
//            error: '',
//            key: 1,
//            loading: false,
//            shouldRedirect: false, editMode: false
//        };

//        this._handleImageChange = this._handleImageChange.bind(this);
//        this.handleNameChange = this.handleNameChange.bind(this);
//        this.handlePriceChange = this.handlePriceChange.bind(this);
//        this.handleDescriptionChange = this.handleDescriptionChange.bind(this);
//        this.handleQuantityChange = this.handleQuantityChange.bind(this);

//        this.handleSubmit = this.handleSubmit.bind(this);
//        this.dismissError = this.dismissError.bind(this);
//        this.getParam = this.getParam.bind(this);

//    }

//    handleSelect(key: number) {
//        alert(`selected ${key}`);
//        this.setState({ key });
//    }

//    componentDidMount() {
//        //initialisation goes here.
//        this.setState({ loading: true });
//        let productid = this.getParam('productid');

//        if (productid !== "") {

//            axios.get(`api/Product/getproductbyid`, {
//                params: {
//                    param: productid
//                }
//            })
//                .then(res => {
//                    //this.setState({ products: res.data, loading: false });
//                    this.setState({
//                        Name: res.data.Name,
//                        Description: res.data.Description,
//                        Quantity: res.data.Quantity,
//                        Img: res.data.Img,
//                        error: '',
//                        key: 1,
//                        loading: false,
//                        shouldRedirect: false,
//                        editMode: true
//                    });
//                })

//        } else {

//            this.setState({ loading: false });
//        }


//    }

//    handleLoading() {

//        <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}><ReactLoading type="spin" color="blue" height={667} width={375} /></div>
//    }

//    dismissError() {
//        this.setState({ error: '' });
//    }

//    handleSubmit(evt: React.FormEvent<HTMLFormElement>) {
//        let that = this;
//        evt.preventDefault();

//        this.setState({ loading: true });

//        if (this.state.loading) {

//            this.handleLoading();
//        }

//        //Validaciones antes de agregar un producto
//        if (!this.state.Name) {
//            this.setState({ loading: false });
//            return this.setState({ error: 'Nombre del Producto es obligatorio' });
//        }

//        if (!this.state.Description) {
//            this.setState({ loading: false });
//            return this.setState({ error: 'La Description es obligatoria' });
//        }

//        let data = new FormData();
//        data.append('Img', this.file, this.file.name);
//        data.append('Name', this.state.Name);
//        data.append('Description', this.state.Description);
//        data.append('Price', String(this.state.Price));
//        data.append('Quantity', String(this.state.Quantity));


//        let headers = {
//            'Content-Type': 'application/json',
//            'Authorization': "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOjEsImlzcyI6Imh0dHA6Ly9hcHBzZGF0YTIuY2xvdWRhcHAubmV0L2p3dC1kZW1vL3B1YmxpYy9hcGkvbG9naW4iLCJpYXQiOjE1MDYzMzkwNDgsImV4cCI6MTY2MTg1OTA0OCwibmJmIjoxNTA2MzM5MDQ4LCJqdGkiOiJHUWt5RVlwck5GSDBHekd4In0.JqdyAEkEN_D3M2WbqcQwIwghk6iajFjxi9g854akjB8"
//        }

//        if (this.state.error === '') {

//            if (this.state.editMode) {

//                axios.post(`api/Product/editproduct`,
//                    data,
//                    { headers: headers })
//                    .then((response) => {

//                        if (response.data === "Ok") {

//                            this.setState({ loading: false });
//                            Swal(
//                                'Producto modificado correctamente!',
//                                response.data,
//                                'success'
//                            )
//                            this.setState({ shouldRedirect: true });

//                        } else {
//                            this.setState({ loading: false });

//                            Swal(
//                                'Error al intentar modificar un producto!',
//                                response.data,
//                                'error'
//                            )
//                        }


//                    })
//                    .catch((error) => {
//                        this.setState({ loading: false });
//                        console.log("axios error:", error);
//                        Swal(
//                            'Error al intentar agregar un producto!',
//                            error,
//                            'error'
//                        )
//                    });

//            } else {

//                axios.post(`api/Product/saveproduct`,
//                    data,
//                    { headers: headers })
//                    .then((response) => {
//                        console.log("Respuesta: " + response.data);

//                        if (response.data === "Ok") {
//                            this.setState({ loading: false });
//                            Swal(
//                                'Producto Agregado correctamente!',
//                                response.data,
//                                'success'
//                            )
//                            this.setState({ shouldRedirect: true });

//                        } else {
//                            this.setState({ loading: false });

//                            Swal(
//                                'Error al intentar agregar un producto!',
//                                response.data,
//                                'error'
//                            )
//                        }


//                    })
//                    .catch((error) => {
//                        this.setState({ loading: false });
//                        console.log("axios error:", error);
//                        Swal(
//                            'Error al intentar agregar un producto!',
//                            error,
//                            'error'
//                        )
//                    });
//            }
//        }



//        return this.setState({ error: '' });
//    }

//    handleNameChange(evt: React.SyntheticEvent<HTMLInputElement>) {
//        this.setState({
//            Name: evt.currentTarget.value,
//        });
//    };

//    handlePriceChange(evt: React.SyntheticEvent<HTMLInputElement>) {
//        this.setState({
//            Price: parseFloat(evt.currentTarget.value),
//        });
//    };

//    handleDescriptionChange(evt: React.SyntheticEvent<HTMLTextAreaElement>) {
//        this.setState({
//            Description: evt.currentTarget.value,
//        });
//    };

//    handleQuantityChange(evt: React.SyntheticEvent<HTMLInputElement>) {
//        this.setState({
//            Quantity: Number(evt.currentTarget.value),
//        });
//    };

//    _handleImageChange(event: any) {


//        this.file = event.target.files[0];


//        this.setState({
//            Img: event.currentTarget.value
//        });

//        event.preventDefault();
//    }

//    public getParam(name: string) {

//        name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
//        var regexS = "[\\?&]" + name + "=([^&#]*)";
//        var regex = new RegExp(regexS);
//        var results = regex.exec(window.location.href);
//        if (results == null)
//            return "";
//        else
//            return results[1];
//    }



//    public render() {


//        return <div>
//            {
//                this.state.shouldRedirect ?

//                    <Redirect to="/" push /> :

//                    this.state.loading ?

//                        <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}><ReactLoading type="spin" color="blue" height={667} width={375} /></div>

//                        :

//                        <div className="container white z-depth-2">
//                            <ul className="tabs teal">
//                                {

//                                    this.state.editMode ?
//                                        <li className="tab col s3"><span className="white-text glyphicon glyphicon-plus-sign">Modificar Producto</span></li>
//                                        :
//                                        <li className="tab col s3"><span className="white-text glyphicon glyphicon-plus-sign">Agregar Producto</span></li>
//                                }

//                            </ul>

//                            <div classID="register" className="col s12">
//                                <form className="col s12" onSubmit={this.handleSubmit} encType="multipart/form-data" >
//                                    <div className="form-container">

//                                        <div className="row">
//                                            <div className="input-field col s6">
//                                                <input id="Name" type="text" autoFocus className="validate" value={this.state.Name} onChange={this.handleNameChange} />
//                                                <label>Nombre Producto</label>
//                                            </div>
//                                            <div className="input-field col s6">
//                                                <input id="Price" type="text" autoFocus className="validate" value={this.state.Price} onChange={this.handlePriceChange} />
//                                                <label>Precio</label>

//                                            </div>
//                                        </div>
//                                        <div className="row">
//                                            <div className="input-field col s12">
//                                                <textarea id="Description" autoFocus className="validate" value={this.state.Description} onChange={this.handleDescriptionChange}> </textarea>
//                                                <label>Descripción</label>
//                                            </div>
//                                        </div>
//                                        <div className="row">
//                                            <div className="input-field col s2">
//                                                <input id="Quantity" type="number" autoFocus className="validate" value={this.state.Quantity} onChange={this.handleQuantityChange} />
//                                                <label>Cantidad</label>
//                                            </div>
//                                            <div className="input-field col s2">
//                                                <label>Imagen Producto</label>

//                                            </div>
//                                            <div className="input-field col s8">
//                                                <input type="file" name="file" autoFocus accept=".jpg,.png,.PNG,.jpeg" className="upload-file" onChange={this._handleImageChange} />

//                                            </div>
//                                        </div>
//                                        <br />
//                                        <div className="text-center">
//                                            <button className="btn waves-effect waves-light teal" type="submit" name="action">Guardar</button>
//                                        </div>
//                                        <br />
//                                    </div>
//                                </form>


//                            </div>


//                        </div>

//            }

//        </div>;
//    }

//}

