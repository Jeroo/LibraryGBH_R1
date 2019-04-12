import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Book } from './Book';
//import Loader from 'react-loader-spinner';
import axios from 'axios';
import { FormEvent } from 'react';
import Swal from 'sweetalert2';
import ReactLoading from 'react-loading';
import { Alert } from 'react-bootstrap';



interface FetchDataBookState {
    books: IBookList[];
    loading: boolean;
    param: string;
}

export class Home extends React.Component<RouteComponentProps<{}>, FetchDataBookState> {

    constructor() {

        super();
        this.state = { books: [], loading: true, param: "" };
        this.handleUpdate = this.handleUpdate.bind(this);

    }

    
    componentDidMount() {

        this.initListBook();
    }

    public initListBook() {

        axios.get(`api/Book/listbooks`)
            .then(res => {
                this.setState({ books: res.data, loading: false });
            })
       

    }
    
    handleUpdate(e: React.SyntheticEvent<HTMLInputElement>) {

        const value = e.currentTarget.value;
        this.setState({ param: value });
        this.setState({ loading: true });
        this.initListBook();       
    }

  
    public render() {
        let contents = this.state.loading

            ? <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}>
                <ReactLoading type="spin" color="blue" height={667} width={375} /></div>


            : Home.renderListBooks(this.state.books);

            return <div>              

                    <Alert bsStyle="info">
                        <strong>Library GBH</strong> 
                    </Alert>                   
           
                {contents}              

            </div>;
    }

    private static renderListBooks(books: IBookList[]) {


        return <div>
        {
                books.map(book =>

                    <Book key={book.BookId} Name={book.Name}
                        Description={book.Description}
                        Author={book.Author}
                        CoverPageImg={book.CoverPageImg} BookId={book.BookId}
                        TotalPages={book.TotalPages}
                        BooksTypesName={book.BooksTypesName}
                        shouldRedirect={false} />
                ).reverse()

        }
        </div> 
            
    }    
   
}

interface IBookList {
    BookId: number;
    Name: string;
    Description: string;
    CoverPageImg: FormData;
    TotalPages: number;
    Author: string;
    BooksTypesName: string;
}
