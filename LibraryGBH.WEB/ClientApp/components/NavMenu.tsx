import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';
import { RouteComponentProps } from 'react-router';

interface IAuth {
    userAutenticated?: boolean
    user?: string
}

export class NavMenu extends React.Component<IAuth, any> {

    constructor() {

        super();

        this.state = {
            userAutenticated: sessionStorage.getItem('user') ? true : false
           ,user: String(sessionStorage.getItem('user'))
        };

        this.reaload = this.reaload.bind(this);
       

    }

    userAuth() {

        return sessionStorage.getItem('user');
    }


    componentDidUpdate() {

        this.state = {
            userAutenticated: sessionStorage.getItem('user') ? true : false
        };

        console.log("Update Aut DIt: " + this.state.userAutenticated);

    }

    componentDidMount() {

        this.state = {
            userAutenticated: sessionStorage.getItem('user') ? true : false
        };

        console.log("Aut DIt: " + this.state.userAutenticated);

    }

    reaload() {

        // Remove all saved data from sessionStorage       
        sessionStorage.clear();
        window.location.reload()
        
    }

    public render() {

        return <nav className='light-blue lighten-1 nav-extended' role='navigation'>
           
                <div className='nav-wrapper container'><a id='logo-container' href='#' className='brand-logo'>
                <img src={require('../images/logo3.png')} style={{ width: 100, height: 80 }} alt="Logo de la tienda" /></a>


                {this.state.userAutenticated ? 
                    
                    <ul id='nav-mobile' className='right hide-on-med-and-down'>
                        <li>
                            <NavLink to={'/'} exact activeClassName='active jquery'>
                                <span className='glyphicon glyphicon-home'></span> Tienda
                            </NavLink>
                        </li>
                        <li className='cart-container'>

                            <NavLink to={'/ShoppingCart'} activeClassName='active' className='cart'>
                                <span className='glyphicon glyphicon-shopping-cart'>
                                    
                                        {
                                            sessionStorage.getItem("CountProducts") !== null ? 
                                                
                                            <span className="itemCount">{sessionStorage.getItem("CountProducts")}</span>
                                                :
                                                  <span></span>
                                        }
                                   
                                </span> Carrito

                        </NavLink>

                        </li>
                        <li>
                            <NavLink to={''} activeClassName='active'>
                                <span className='glyphicon glyphicon-log-out' onClick={this.reaload}></span> Salir
                            </NavLink>
                        </li>
                        <li>

                            <span className=''>{this.state.user}</span> 
                           
                        </li>


                    </ul>
                    
                    
                    : 

                    <ul id='nav-mobile' className='right hide-on-med-and-down'>
                        <li>
                            <NavLink to={'/'} exact activeClassName='active jquery'>
                                <span className='glyphicon glyphicon-home'></span> Tienda
                            </NavLink>
                        </li>
                        <li className='cart-container'>

                            <NavLink to={'/ShoppingCart'} activeClassName='active' className='cart'>
                                <span className='glyphicon glyphicon-shopping-cart'>
                                {
                                    sessionStorage.getItem("CountProducts") !== null ?

                                            <span className="itemCount"> {sessionStorage.getItem("CountProducts")}</span>
                                        :
                                        <span></span>
                                }
                                   
                                </span> Carrito

                        </NavLink>

                        </li>

                        <li>
                            <NavLink to={'/login'} activeClassName='active'>
                                <span className='glyphicon glyphicon-log-in'></span> Log In
                           </NavLink>
                        </li>

                        <li>
                            <NavLink to={'/Register'} activeClassName='active'>
                                <span className='glyphicon glyphicon-user'></span> Registrarse
                           </NavLink>
                        </li>


                    </ul>

                     
                 }

                   

                    <ul id='nav-mobile' className='nav navbar-nav sidenav'>
                        <li>
                            <NavLink to={'/'} exact activeClassName='active jquery'>
                                <span className='glyphicon glyphicon-home'></span> Tienda
                            </NavLink>
                        </li>
                        <li className='cart-container'>

                            <NavLink to={'/fetchdata'} activeClassName='active' className='cart'>



                            <span className='glyphicon glyphicon-shopping-cart'> {
                                sessionStorage.getItem("CountProducts") !== null ?

                                    <span className="itemCount"> {sessionStorage.getItem("CountProducts")}</span>
                                    :
                                    <span></span>
                            }
                                   </span> Carrito

                        </NavLink>

                        </li>
                        <li>
                            <NavLink to={'/login'} activeClassName='active'>
                                <span className='glyphicon glyphicon-log-in'></span> Log In
                        </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/Register'} activeClassName='active'>
                                <span className='glyphicon glyphicon-user'></span> Registrarse
                        </NavLink>
                        </li>
                    </ul>
                    <a href='#' data-target='nav-mobile' className='sidenav-trigger'><span className='glyphicon glyphicon-th-list'>menu</span></a>
            </div>

            {this.state.userAutenticated && String(sessionStorage.getItem('user')).toLowerCase() === "admin" ?
                    <div className="nav-content">
                    <ul className="tabs tabs-transparent">

                        <li className="tab">

                            <NavLink to={'/ProductList'} activeClassName='active'>
                                <span className='glyphicon glyphicon-plus-sign'></span> Lista de Productos
                            </NavLink>

                        </li>

                        <li className="tab">

                            <NavLink to={'/ReplenishProduct'} activeClassName='active'>
                                <span className='glyphicon glyphicon-plus-sign'></span> Reponer
                            </NavLink>

                        </li>
                        <li className="tab">
                            <NavLink to={'/AddEditProduct'} activeClassName='active'>
                                <span className='glyphicon glyphicon-plus'></span> Agregar
                            </NavLink>

                        </li>
                        <li className="tab">
                            <NavLink to={'/ReplenishProductProviders'} activeClassName='active'>
                                <span className='glyphicon glyphicon-menu-right'></span> Reponer desde Proveedores
                            </NavLink>

                        </li>
                        <li className="tab">
                            <NavLink to={'/Reports'} activeClassName='active'>
                                <span className='glyphicon glyphicon-briefcase'></span> Reportes
                            </NavLink>

                        </li>
                        </ul>
                    </div>
                :
                <div></div>
              }
          
        </nav>;
    }
}
