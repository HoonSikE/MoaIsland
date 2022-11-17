import './App.css'
import React from "react";
import ProgressBar from "@ramonak/react-progress-bar";
import { Unity, useUnityContext } from "react-unity-webgl";
import DancingFox from './DancingFox.gif'
import RainbowTitle from './RainbowTitle.gif'
function App() {

  const { unityProvider, isLoaded, loadingProgression } = useUnityContext({
    loaderUrl: "Build/WebGL.loader.js",
    dataUrl: "Build/WebGL.data",
    frameworkUrl: "Build/WebGL.framework.js",
    codeUrl: "Build/WebGL.wasm",
  });
  const loadingPercentage = Math.round(loadingProgression * 100);
  const CustomProgressBar = () => {
    return <ProgressBar completed={loadingPercentage} customLabel={loadingPercentage}
    className="wrapper"
    height="30px"
    bgColor='#BDD7EE'
    baseBgColor='#fff'
    borderRadius='0px'
    labelClassName='ProgressLabel'

    />;
  };
  return (
    <div id="unity-container">
      {isLoaded === false && (
        <div className="loading-overlay">
          {/* <p>Loading... ({loadingPercentage}%)</p> */}
          {/* <Wave fill='#5e9ef1'
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
          /> */}
          <div className="FirstGif">
            <img src={RainbowTitle} alt="RainbowTitle"/>
          </div>
          <div className="SecondGif">
            <img src={DancingFox} alt="DancingFox"/>
          </div>
          <div className="ProgressText">
            <span>모아 아일랜드로 이동 중이야! 잠시만 기다려줘~</span>
          </div>
          <div className="ProgressBar">
            <CustomProgressBar/>
          </div>
        </div>
      )}
      {/* <Unity 
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
      /> */}
    </div>
  );
}

export default App