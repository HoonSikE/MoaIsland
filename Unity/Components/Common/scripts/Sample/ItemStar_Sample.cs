using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 별 아이템
// 주의사항 : 별마다 다 넣고 위에 껍데기에도 넣어야합니다.
public class ItemStar_Sample : MonoBehaviour {
    // 회전 속도(초기값: 200)
    public float rotateSpeed;
    // 오디오 소스
    AudioSource audio;

    // 오디오 초기화
    void Awake(){
        audio = GetComponent<AudioSource>();
    }

    // 회전
    void Update() {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }

    // 아이템 획득 소리
    public void GetSound(){
        audio.Play();
    }
}