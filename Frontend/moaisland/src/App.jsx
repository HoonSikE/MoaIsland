import './App.css'
import React from "react";
import Wave from 'react-wavify'
import { Unity, useUnityContext } from "react-unity-webgl";

function App() {

  const { unityProvider, isLoaded, loadingProgression } = useUnityContext({
    loaderUrl: "Build/WebGL.loader.js",
    dataUrl: "Build/WebGL.data",
    frameworkUrl: "Build/WebGL.framework.js",
    codeUrl: "Build/WebGL.wasm",
  });
  const loadingPercentage = Math.round(loadingProgression * 100);

  return (
    <div id="unity-container">
      {isLoaded === false && (
        <div className="loading-overlay">
          <p>Loading... ({loadingPercentage}%)</p>
          <Wave fill='#5e9ef1'
            style={{
              height: loadingPercentage + '%'
            }}
            paused={false}
            options={{
              height: 20,
              amplitude: 30,
              speed: 0.2,
              points: 3
            }}
          />
        </div>
      )}
      <Unity 
      style={
        isLoaded ?
        { 
          width: '80vw',
          height: '45vw',
        } :
        {
          width: '0',
          height: '0',
        }      
      }
      unityProvider={unityProvider} 
      />
    </div>
  );
}

export default App