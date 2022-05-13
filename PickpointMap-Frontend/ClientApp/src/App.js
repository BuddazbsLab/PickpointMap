import React, { Component } from 'react';
import { Layout } from './components/Layout';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <div className="App">
            <header className="App-header">
                <div className="parent">
                    <div className="block">
                        <div className={"hexagon App-logo "} >
                            <div className={"circle-1"}></div>
                            <div className={"circle-2"}></div>
                            <div className={"circle-3"}></div>
                            <div className={"circle-4"}></div>
                            <div className={"circle-5"}></div>
                            <div className={"circle-6"}></div>
                        </div>

                </div>
                    <div className="parent">
                        <div className={"demoFont"}>PickPoint</div>
                    </div>
                </div>
                <Layout>
                </Layout>
            </header>
        </div>
    );
  }
}

