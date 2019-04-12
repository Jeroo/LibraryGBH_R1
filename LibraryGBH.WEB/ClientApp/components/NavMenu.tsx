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
                <img src={require('../images/library-icon.png')} style={{ width: 110, height: 59 }} alt="Logo de la tienda" /></a>


                {this.state.userAutenticated ? 
                    
                    <ul id='nav-mobile' className='right hide-on-med-and-down'>
                        <li>
                            <NavLink to={'/'} exact activeClassName='active jquery'>
                                <span className='glyphicon glyphicon-home'></span> Libros
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
                                <span className='glyphicon glyphicon-home'></span> Libros
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
                                <span className='glyphicon glyphicon-home'></span> Libros
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
          
        </nav>;
    }
}
