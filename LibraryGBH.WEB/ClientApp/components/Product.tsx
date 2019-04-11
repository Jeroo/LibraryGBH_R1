import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import Image from 'react-loading';
import axios from 'axios';
import Swal from 'sweetalert2';
import ReactLoading from 'react-loading';
import { Redirect } from "react-router-dom";



interface IProduct {
    price: number;
    productId: string;
    name: string;
    description?: string;
    img: FormData;
    quantity: number;
    shouldRedirect: boolean;
   // shouldRedirectIsEdit: boolean;
    /*
                this.props.shouldRedirectIsEdit ?

                        <Redirect to={{
                        pathname: '/user/profile',
                        state: { referrer: this.props.productId }

                        }} />
                    :*/

    
}



export class Product extends React.Component<IProduct, {}> {

    constructor() {

        super();
        this.addToCart = this.addToCart.bind(this);
        this.deleteProduct = this.deleteProduct.bind(this);
        this.editProduct = this.editProduct.bind(this);


        
    }

    public editProduct() {

        window.location.href = "/AddEditProduct/?productid=" + this.props.productId;

    }



    public deleteProduct() {
        

        let headers = {
            'Content-Type': 'application/json',
            'Authorization': "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOjEsImlzcyI6Imh0dHA6Ly9hcHBzZGF0YTIuY2xvdWRhcHAubmV0L2p3dC1kZW1vL3B1YmxpYy9hcGkvbG9naW4iLCJpYXQiOjE1MDYzMzkwNDgsImV4cCI6MTY2MTg1OTA0OCwibmJmIjoxNTA2MzM5MDQ4LCJqdGkiOiJHUWt5RVlwck5GSDBHekd4In0.JqdyAEkEN_D3M2WbqcQwIwghk6iajFjxi9g854akjB8"
        }

        console.log("productId: "+this.props.productId)

        if (this.props.productId !== "") {

            //let data = JSON.stringify({
            //    productId: this.props.productId
                
            //});

            axios.get(`api/Product/deleteproduct`,
                {
                    params: {
                        productId: this.props.productId
                    }
                })               
                .then((response) => {

                    if (response.data === "Ok") {

                        this.setState({ loading: false });
                        Swal(
                            'Producto Eliminado!',
                            response.data,
                            'success'
                        )
                       // this.setState({ shouldRedirect: true });
                        window.location.reload();

                    } else {
                        this.setState({ loading: false });

                        Swal(
                            'Hubo un error no se pudo eliminar el producto!',
                            response.data,
                            'error'
                        )
                    }


                })
                .catch((error) => {
                    this.setState({ loading: false });
                    console.log("axios error:", error);
                    Swal(
                        'Hubo un error no se pudo eliminar el producto!',
                        error,
                        'error'
                    )
                });

        }
    }

    public addToCart() {

       

        const product = {

            Price: this.props.price,
            ProductId: this.props.productId,
            Name: this.props.name,
            Description: this.props.description,
            Img: this.props.img,
            Quantity: this.props.quantity

        };

        let countProductInCart = 0;

        var tempProduct = sessionStorage.getItem('products');

        if (tempProduct != null) {

            var getProduct = sessionStorage.getItem('products');

            var viewProducts = JSON.parse(tempProduct);

            var result = [];

            if (viewProducts.length === undefined) {

                result.push(viewProducts);

            } else {

                for (var i = 0, len = viewProducts.length; i < len; i++) {

                    result.push(viewProducts[i]);
                }
            }           
           
            let centinel = false;


            result.forEach(function (item) {

                if (item.ProductId === product.ProductId) {

                    centinel = true;
                }

            });

            if (centinel === false) {

                result.push(product);

            } else {

                Swal(
                    'Producto ya se encuentra en el carrito!',
                    product.ProductId,
                    'info'
                )

                return false;

            }
           

            countProductInCart = result.length;

            sessionStorage.setItem("products", JSON.stringify(result)); 


        } else {

            countProductInCart = 1;
            sessionStorage.setItem("products", JSON.stringify(product)); 
        }        

        sessionStorage.setItem("CountProducts", String(countProductInCart));  

        window.location.href = "/ShoppingCart";

        
    }

    public render() {
        return <div> 
            {

                this.props.shouldRedirect ?


                    <Redirect to="/ShoppingCart" push />


                    :
                    
             <div className='col s12 m12'>
                <h2 className='header'></h2>
                <div className='card horizontal'>
                    <div className='card-image'>
                            <img src={"data:image/png;base64," + this.props.img} style={{ width: 250 }} />
                    </div>
                    <div className='card-stacked'>
                        <div className='card-content'>
                            <p className="productName">{this.props.productId} - {this.props.name}  </p>
                            <p className="productName">Precio: ${this.props.price}</p>
                            <p className="productName"> Cantidad disponible: {this.props.quantity}</p>                        
                         </div>

                            
                            <div className='card-action row'>

                                {String(sessionStorage.getItem('user')).toLowerCase() !== "" && sessionStorage.getItem('user') !== null ?
                                    <div className='col s4 m4'>
                                        <button href='#' className="waves-effect waves-light btn glyphicon glyphicon-shopping-cart" onClick={() => this.addToCart()}>Agregar al Carrito</button>
                                    </div>
                                    :
                                    <div><strong><b>Para poder comprar debe tener una cuenta</b></strong> </div>
                                }
                               
                                {String(sessionStorage.getItem('user')).toLowerCase() === "admin" ?
                                    <div className='col s3 m3'>
                                            <button href='#' className="waves-effect waves-light btn orange glyphicon glyphicon-edit" onClick={() => this.editProduct()} >Modificar</button>
                                    </div>
                                :
                                <div></div>
                               }
                                {String(sessionStorage.getItem('user')).toLowerCase() === "admin" ?
                                    <div className='col s2 m2'>
                                        <button href='#' className="waves-effect waves-light btn red glyphicon glyphicon-trash" onClick={() => this.deleteProduct()}>Borrar</button>
                                    </div>
                                    :
                                    <div></div>
                                }

                              
                            </div>



                    </div>
                </div>
            </div>
           }
        </div>;
    }

}
