import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import Image from 'react-loading';
import axios from 'axios';
import Swal from 'sweetalert2';
import ReactLoading from 'react-loading';
import { Redirect } from "react-router-dom";



interface IBook {
    BookId: number;
    Name: string;
    Description: string;
    CoverPageImg: FormData;
    TotalPages: number;
    Author: string;
    BooksTypesName: string;
    shouldRedirect: false;
}



export class Book extends React.Component<IBook, {}> {

    constructor() {

        super();
    }

    public ReadBook() {

        window.location.href = "/readbook/?bookid=" + this.props.BookId;

    }

    public render() {
        return <div>
            {

                <div className='col s12 m12'>
                    <h2 className='header'></h2>
                    <div className='card horizontal'>
                        <div className='card-image'>
                            <img src={"data:image/png;base64," + this.props.CoverPageImg} style={{ width: 250 }} />
                        </div>
                        <div className='card-stacked'>
                            <div className='card-content'>
                                <p className="bookName">Libro: {this.props.BookId} - {this.props.Name}  </p>
                                <p className="bookDescription">Descripción: ${this.props.Description}</p>
                                <p className="bookAuthor"> Autor: {this.props.Author}</p>
                            </div>


                            <div className='card-action row'>

                                <div className='col s2 m2'>
                                    <button href='#' className="waves-effect waves-light btn green glyphicon glyphicon-book" onClick={() => this.ReadBook()}>       Leer el Libro</button>
                                </div>

                            </div>



                        </div>
                    </div>
                </div>

                  
            }
        </div>;
    }

}