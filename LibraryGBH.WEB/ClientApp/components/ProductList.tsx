import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Product } from './Product';
//import Loader from 'react-loader-spinner';
import axios from 'axios';
import { FormEvent } from 'react';
import Swal from 'sweetalert2';
import ReactLoading from 'react-loading';



interface FetchDataProductState {
    products: IProductList[];
    loading: boolean;
    param: string;
}

export class ProductList extends React.Component<RouteComponentProps<{}>, FetchDataProductState> {

    constructor() {

        super();
        this.state = { products: [], loading: true, param: "" };
        this.handleUpdate = this.handleUpdate.bind(this);

    }

    
    componentDidMount() {

        
        this.initListProduct("");
    }

    public initListProduct(param: string) {

        console.log("Parametro Consultado: " + param)
        if (param === "") {

            axios.get(`api/Product/listaproductos`)
                .then(res => {
                    this.setState({ products: res.data, loading: false });
                })

        } else {

            axios.get(`api/Product/listaproductos`, {
                params: {
                    param: param
                }
              })
                .then(res => {
                    this.setState({ products: res.data, loading: false });
                })
        }
       

    }
    
    handleUpdate(e: React.SyntheticEvent<HTMLInputElement>) {

        const value = e.currentTarget.value;
        this.setState({ param: value });
        this.setState({ loading: true });
        this.initListProduct(this.state.param);       
    }



  
    public render() {
        let contents = this.state.loading

            ? <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}><ReactLoading type="spin" color="blue" height={667} width={375} /></div>


            : ProductList.renderListProducts(this.state.products);

            return <div>              

                    <div className="searchbox">
                        <div className="row">
                            <div className="col s11">
                                <input className="search-input" type="text" placeholder="Buscar..." value={this.state.param} onChange={this.handleUpdate} />
                        </div>
                            <div className="col s1">
                                <button className="btn-floating btn-large waves-effect waves-light blue"><span className='glyphicon glyphicon-search'></span></button>
                        </div >
                        </div>
                    </div>
           
                {contents}

            </div>;
    }

    private static renderListProducts(products: IProductList[]) {


        return <div>
            {

                products.map(product =>


                    <Product key={product.ProductCode} name={product.Name}
                        description={product.Description} quantity={product.Quantity} price={product.Price}
                        img={product.Img} productId={product.ProductCode} shouldRedirect={false}
                    />
                ).reverse()

        }
        </div> 
            
    }

    
   
}

interface IProductList {
    Price: number;
    ProductCode: string;
    Name: string;
    Description: string;
    Img: FormData;
    Quantity: number;
}
