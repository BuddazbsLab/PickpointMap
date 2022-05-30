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
                    <div className="block zoomIn">
                        <div className={"hexagon App-logo "} >
                            <div className={"circle-1 zoomIn"}>
                            </div>
                            <div className={"circle-2 zoomIn"}>
                            </div>
                            <div className={"circle-3 zoomIn"}>
                            </div>
                            <div className={"circle-4 zoomIn"}>
                            </div>
                            <div className={"circle-5 zoomIn"}>
                            </div>
                            <div className={"circle-6 zoomIn"}>6
                            </div>
                        </div>
                </div>
                    <div className="parent">
                        <div className={"demoFont zoomIn"}>PickPoint</div>
                    </div>
                </div>
                <Layout>
                </Layout>
            </header>
        </div>
    );
  }
}

