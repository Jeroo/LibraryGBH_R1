import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { ShoppingCart } from './components/ShoppingCart';
import { Login } from './components/Login';
import { Register } from './components/Register';
import { Page404 } from './components/Page404';
import { AddEditProduct } from './components/AddEditProduct';
import { ReplenishProduct } from './components/ReplenishProduct';
import { ReplenishProductProviders } from './components/ReplenishProductProviders';
import { Reports } from './components/Reports';
import { ProductList } from './components/ProductList';


export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/ShoppingCart' component={ ShoppingCart } />
    <Route path='/Login' component={Login} />
    <Route path='/Register' component={Register} />
    <Route path='/AddEditProduct' component={AddEditProduct} />
    <Route path='/ReplenishProduct' component={ReplenishProduct} />
    <Route path='/ReplenishProductProviders' component={ReplenishProductProviders} />
    <Route path='/Reports' component={Reports} />
    <Route path='/ProductList' component={ProductList} />

    
</Layout>;
