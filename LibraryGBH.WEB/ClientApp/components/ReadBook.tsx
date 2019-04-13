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
   
//    constructor() {
//        super();


//    }

//    handleSelect(key: number) {
//        alert(`selected ${key}`);
//        this.setState({ key });
//    }

//    componentDidMount() {
//        //initialisation goes here.
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


//        return this.setState({ error: '' });
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

//                            <div classID="register" className="col s12">


//                            </div>


//                        </div>

//            }

//        </div>;
//    }

//}

