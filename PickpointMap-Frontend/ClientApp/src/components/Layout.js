import React, { Component } from 'react';
import ParticleField from "react-particles-webgl";

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
            <div style={{height: "100vh", width: "100%", position:"relative"}}>
                < ParticleField const config={{
                    showCube: false,
                    dimension: '2D',
                    velocity: 1,
                    boundaryType: 'bounce',
                    antialias: false,
                    direction: {
                        xMin: -1,
                        xMax: 1,
                        yMin: -1,
                        yMax: 1,
                        zMin: -1,
                        zMax: 1
                    },
                    lines: {
                        colorMode: 'rainbow',
                        color: '#351CCB',
                        transparency: 0.9,
                        limitConnections: true,
                        maxConnections: 20,
                        minDistance: 110,
                        visible: true
                    },
                    particles: {
                        colorMode: 'rainbow',
                        color: '#3FB568',
                        transparency: 0.9,
                        shape: 'circle',
                        boundingBox: 'canvas',
                        count: 300,
                        minSize: 10,
                        maxSize: 27,
                        visible: true
                    },
                    cameraControls: {
                        enabled: false,
                        enableDamping: true,
                        dampingFactor: 0.2,
                        enableZoom: true,
                        autoRotate: false,
                        autoRotateSpeed: 0.3,
                        resetCameraFlag: true
                    },
                    limitConnections: false
                }} />
            </div>
    );
  }
}
