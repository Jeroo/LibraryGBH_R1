import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';


export class Fotter extends React.Component<{}, {}> {


    public render() {


        return <footer className='page-footer blue footer-fixed gradient-45deg-purple-deep-blue'>
            <div className='container'>
                <div className='row'>
                    <div className='col l6 s12'>
                        <h5 className='white-text'>LibraryGBH</h5>
                        <p className='grey-text text-lighten-4'>Proyecto realizado en Core 2 con Visual Studio 2017</p>


                    </div>
                    <div className='col l3 s12 hide'>
                        <h5 className='white-text'>Settings</h5>
                        <ul>
                            <li><NavLink to={'/'} activeClassName='active'>
                                Link 1
                            </NavLink></li>
                            <li><a className='white-text' href='#!'>Link 2</a></li>
                            <li><a className='white-text' href='#!'>Link 3</a></li>
                            <li><a className='white-text' href='#!'>Link 4</a></li>
                        </ul>
                    </div>
                    <div className='col l3 s12 hide'>
                        <h5 className='white-text'>Connect</h5>
                        <ul>
                            <li><a className='white-text' href='#!'>Link 1</a></li>
                            <li><a className='white-text' href='#!'>Link 2</a></li>
                            <li><a className='white-text' href='#!'>Link 3</a></li>
                            <li><a className='white-text' href='#!'>Link 4</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div className='footer-copyright'>
                <div className='container'>
                    Made by <a className='orange-text text-lighten-3' href='http://materializecss.com'>Materialize</a>
                </div>
            </div>
        </footer>;
    }
}
