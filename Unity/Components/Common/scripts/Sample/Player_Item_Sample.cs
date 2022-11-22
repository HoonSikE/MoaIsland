using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Item_Sample : MonoBehaviour {
    public ItemStar_Sample ItemStar;
    // 현재 아이템 개수 (초기값: 0)
    public int itemCount;

    // 아이템 매니저
    public ItemManager_Sample ItemManager;
    // Trigger에서 식별되는 오브젝트
    GameObject scanObject;

    void OnTriggerEnter(Collider other){
        // Trigger된 상태가 Item이라면
        if(other.tag == "ItemStar"){
            // 현재 아이템 개수 증가
            itemCount++;
            // 눈에 안보이게 없애고
            other.gameObject.SetActive(false);
            // 아이템 획득 소리 출력
            ItemStar.GetSound();
            // (Canvas에)현재 아이템 개수반영
            ItemManager.GetItem(itemCount);
        }
    }
}
