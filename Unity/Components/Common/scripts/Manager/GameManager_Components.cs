using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 기본 게임매니저
public class GameManager_Components : MonoBehaviour {
    // 스테이지 번호 (초기값: 현재 씬 번호)
    
    public int stage;
    // 움직일 수 있는 상태 (초기값 : true)
    // isAction == true 움직일 수 있음
    // isAction == false 못 움직임
    public bool isAction = false;
    // 다음씬으로 이동한다.

    void Awake(){
        Invoke("actionTrue", 1.0f);
    }
    void actionTrue(){
        isAction = true;
    }
    void loadScene(){
        // 괄호() 안에는 "스테이지 이름" 혹은 "스테이지 번호"를 넣는다.t
        SceneManager.LoadScene(stage+1);
    }
}
