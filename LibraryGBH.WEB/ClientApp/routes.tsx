import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Login } from './components/Login';
import { Register } from './components/Register';
import { Page404 } from './components/Page404';
import { Book } from './components/Book';


export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/Login' component={Login} />
    <Route path='/Register' component={Register} />
    
</Layout>;
