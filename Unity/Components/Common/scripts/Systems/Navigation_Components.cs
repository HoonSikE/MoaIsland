using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 네비게이션 사용법
// 1. GameObject 배열에 Object를 넣는다.
// 2. nextIndex를 조절하면 방향이 바뀐다.
// 3. 상황에 따라 다른 Script에 Navigation_Components를 받고 Navi.SetActive(true/false);를 조절하면 된다.
public class Navigation_Components : MonoBehaviour {
    // 네비게이션
    public GameObject Navi;
    public GameObject[] nextObject;
    public int nextIndex;

    void FixedUpdate(){
        if(nextIndex >= 0 && nextIndex < nextObject.Length){
            Vector3 tmp_vector = nextObject[nextIndex].transform.position;
            Navi.transform.LookAt(tmp_vector);
        }
    }
}
