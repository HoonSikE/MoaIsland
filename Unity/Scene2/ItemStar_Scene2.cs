using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 별 아이템
// 주의사항 : 별마다 다 넣고 위에 껍데기에도 넣어야합니다.
public class ItemStar_Scene2 : MonoBehaviour {
    // 회전 속도(초기값: 200)
    public float rotateSpeed;
    public GameObject itemEffect;
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

    void OnTriggerEnter(Collider other){
        // Trigger된 상태가 ItemStar이라면
        if(other.name == "Player_Fox"){
            itemEffect.SetActive(true);
        }
    }
}