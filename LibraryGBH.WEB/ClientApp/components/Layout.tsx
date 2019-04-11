import * as React from 'react';
import { NavMenu } from './NavMenu';
import { Fotter } from './Fotter';

export interface LayoutProps {
    children?: React.ReactNode;
}

export class Layout extends React.Component<LayoutProps, {}> {
    public render() {
        return <div>

            <NavMenu />

            <div className='container'>
                <div className='section'>
                     <div className='row'>
                        <div className='col s12 m12 sm12'>
                            {this.props.children}
                        </div>
                    </div>

                </div>
                <br /><br />
                <br /><br />
                <br /><br />
                <br /><br />
                <br /><br />
                <br /><br />
                <br /><br />
                <br /><br />
                <br /><br />
                <br /><br />
            </div>

            <Fotter />
         </div>;
    }
}
