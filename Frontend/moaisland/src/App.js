import './App.css';
import React from "react";
import Unity, { UnityContext } from "react-unity-webgl";

const unityContext = new UnityContext({
  loaderUrl: "Build/WebGL.loader.js",
  dataUrl: "Build/WebGL.data",
  frameworkUrl: "Build/WebGL.framework.js",
  codeUrl: "Build/WebGL.wasm",
})

function App() {
  return (
    <div id="unity-container">
      { <Unity 
        style={{
          width: '80vw',
          height: '45vw',
        }}
        unityContext={unityContext} /> }
    </div>

  );
}

export default App;