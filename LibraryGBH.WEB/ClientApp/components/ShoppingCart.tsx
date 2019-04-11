import * as React from 'react';
import { RouteComponentProps } from 'react-router';
//import { Product } from './Product';
import 'isomorphic-fetch';
import { DropdownButton, MenuItem, Panel, Table, Button, Alert} from 'react-bootstrap';
import { Footer } from 'react-bootstrap/lib/Panel';
import ReactLoading from 'react-loading';
import axios from 'axios';
import Swal from 'sweetalert2';
import { Redirect } from "react-router-dom";
//import html2canvas from 'jspdf';


interface ICartState {
    products: IProduct[],
    total: number,
    loading: boolean,
    shouldRedirect: boolean,
    productDDl: IProductKeyValue[],
    selectedValue: string;
}

interface IProduct {
    Price: number;
    ProductCode: string;
    Name: string;
    Description?: string;
    Img: FormData;
    Quantity: number;
    ProductId: number,
    user: any

}

interface IProductKeyValue {
    key: number;
    value: string;

}


export class ShoppingCart extends React.Component<RouteComponentProps<{}>, ICartState> {


    constructor() {

        super();
        this.state = { products: [], loading: true, total: 0, shouldRedirect: false, productDDl: [], selectedValue: "" };
        this.removeToCart = this.removeToCart.bind(this);
        this.toBuyProduct = this.toBuyProduct.bind(this);    
        this.handleChangeQuantity = this.handleChangeQuantity.bind(this);
        this.handleSelect = this.handleSelect.bind(this);


        



    }


    public toBuyProduct(products: IProduct[]) {

        if (products.length > 0) {

            let headers = {
                'Content-Type': 'application/json',
                'Authorization': "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOjEsImlzcyI6Imh0dHA6Ly9hcHBzZGF0YTIuY2xvdWRhcHAubmV0L2p3dC1kZW1vL3B1YmxpYy9hcGkvbG9naW4iLCJpYXQiOjE1MDYzMzkwNDgsImV4cCI6MTY2MTg1OTA0OCwibmJmIjoxNTA2MzM5MDQ4LCJqdGkiOiJHUWt5RVlwck5GSDBHekd4In0.JqdyAEkEN_D3M2WbqcQwIwghk6iajFjxi9g854akjB8"
            }

            let data = JSON.stringify({ products });


            console.log(products)

            console.log(data)


            axios.post(`api/Product/savetobuyproduct`,
                products,
                { headers: headers })
                .then((response) => {

                    if (response.data === "Ok") {

                        this.setState({ loading: false });
                        Swal(
                            'Compra realizada con exito!',
                            response.data,
                            'success'
                        )
                        this.setState({ shouldRedirect: true });
                        sessionStorage.removeItem("products");
                        sessionStorage.removeItem("CountProducts"); 
                        window.location.reload();

                    } else {
                        this.setState({ loading: false });

                        Swal(
                            'Hubo un error no se pudo realizar la compra, verifique la cantidad a comprar que no sea mayor que la cantidad disponible!',
                            response.data,
                            'error'
                        )
                    }


                })
                .catch((error) => {
                    this.setState({ loading: false });
                    console.log("axios error:", error);
                    Swal(
                        'Hubo un error no se pudo realizar la compra, verifique la cantidad a comprar que no sea mayor que la cantidad disponible!',
                        error,
                        'error'
                    )
                });

        }


    }

    public removeToCart(product: IProduct) {


        console.log("" + product.ProductId)

        this.setState({
            products: this.state.products.filter(function (thisproduct) {
                return thisproduct.ProductId !== product.ProductId
            })
        });

        sessionStorage.setItem("products", JSON.stringify(this.state.products)); 
        sessionStorage.setItem("CountProducts", String(this.state.products.length)); 
    }


    componentDidMount() {

        axios.get(`api/Product/getproductsdll`)
            .then(res => {
                this.setState({ productDDl: res.data });
            })

        var getProduct = sessionStorage.getItem('products');

        var viewProducts = JSON.parse(getProduct || '[]');

        var result = [];

        if (viewProducts.length === undefined) {

            result.push(viewProducts);

        } else {

            for (var i = 0, len = viewProducts.length; i < len; i++) {

                result.push(viewProducts[i]);
            }
        }      

        this.setState({ products: result, loading: false });

      // this.initListProduct("");
    }

    handleSelect(evt: any) {
        // what am I suppose to write in there to get the value?
        console.log(evt.currentTarget.value);
        var safeSearchTypeValue: string = evt.currentTarget.value;
       

        this.setState({
            selectedValue: safeSearchTypeValue
        });
    }



    handleChangeQuantity(e: React.ChangeEvent<HTMLInputElement>, product: IProduct) {

        // No longer need to cast to any - hooray for react!
       //this.setState({ Quantity : Number(e.target.value) });

        //if (Number(e.target.value) > product.Quantity) {

        //    Swal(
        //        'Cantidad Indicada es mayor que la Cantidad Disponible!',
        //        "Codigo del Producto: " + product.ProductId,
        //        'warning'
        //    )

        //    return null;

        //} else {

           
        //}

        this.setState({

            products: this.state.products.filter(function (thisproduct) {

                if (thisproduct.ProductId === product.ProductId) {

                    thisproduct.Quantity = Number(e.target.value);

                }

                return thisproduct;
            })
        });

       


    }

  



    public render() {
       
    return  <div>
            {

            this.state.shouldRedirect ? 
            
            <Redirect to="/" push />    
            
            :
        this.state.loading

            ? <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}><ReactLoading type="spin" color="blue" height={667} width={375} /></div>


                    : 

             sessionStorage.getItem("CountProducts") !== null ? 
             <Panel headers="Carrito de la Compra">

                <Alert bsStyle="info">
                    <strong>Listado de Productos elegidos para su compra</strong>
                </Alert>

                <Table fill>
                <thead>
                    <tr>
                        <th>Imagen</th>
                        <th>C&oacute;digo</th>
                        <th>Nombre</th>
                        <th>Descripci&oacute;n</th>
                        <th>Precio</th>
                        <th>Cantidad a comprar</th>
                        <th>Acciones</th>

                    </tr>
                </thead>

                <tbody>
                    {this.state.products.map(product =>
                        <tr key={product.ProductId}>
                            <td> <img src={"data:image/png;base64," + product.Img} style={{ width: 250 }} /></td>
                            <td>{product.ProductId}</td>
                            <td>{product.Name}</td>
                            <td>{product.Description}</td>
                            <td>{product.Price}</td>
                                <td><input value={product.Quantity} onChange={(e) => this.handleChangeQuantity(e, product)} /></td>
                            <td>
                                <div className="row">                                     
                                    <div className="col s6">
                                        <Button className="waves-effect waves-light btn-small red" onClick={() => this.removeToCart(product)}>Remover</Button>
                                    </div>
                                </div>
                             
                        </td>

                        </tr>

                        ).reverse()
                         
                    }                        
                    </tbody>
                    <tfoot>
                    <tr>
                         <td>
                                <strong> Total: ${this.state.products.reduce((sum, product) => sum + (product.Price * product.Quantity), 0)}</strong> 
                            </td>
                            <td>
                                <Button bsStyle="success" onClick={() => this.toBuyProduct(this.state.products)}>Comprar</Button>
                            </td>
                     </tr>
                </tfoot>
                </Table>

                        </Panel>
                        : <div> <Alert bsStyle="info">
                            <strong>No ha agregado productos al carrito</strong>
                        </Alert>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </div>
            }

        </div>;
    }



}
