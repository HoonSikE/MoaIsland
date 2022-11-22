using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Item_Scene2 : MonoBehaviour {
    public ItemStar_Scene2 ItemStar;
    // 현재 아이템 개수 (초기값: 0)
    public int itemCount;

    // 아이템 매니저
    public ItemManager_Scene2 ItemManager;
    // Trigger에서 식별되는 오브젝트
    GameObject scanObject;
    
    // 네비게이션
    public Navigation_Components Navigation;

    public GameObject npcChat;

    // 현재 아이템 개수를 Text에 적용한다.
    // Item을 먹을때 마다 적용해주려고 따로 있음.
    public bool[] getStar = {false, false, false, false, false, false, false, false, false, false};

    void OnTriggerEnter(Collider other){
        // Trigger된 상태가 ItemStar이라면
        if(other.tag == "ItemStar"){
            // 현재 아이템 개수 증가
            itemCount++;
            // 눈에 안보이게 없애고
            other.gameObject.SetActive(false);
            // 아이템 획득 소리 출력
            ItemStar.GetSound();
            // (Canvas에)현재 아이템 개수반영
            ItemManager.GetItem(itemCount);

            // 별 위치 안내
            if(itemCount < ItemManager.TotalNumTextCount - 1){
                // 해달 별이면 true 상태로 바꿈
                for(int i = 0; i < 9; i++){
                    if(other.name == ("Star" + i)){
                        getStar[i] = true;
                        break;
                    }
                }
                // 반영을 한 상태에서 획득하지 않은 별 추적
                for(int i = 0; i < 9; i++){
                    if(!getStar[i]){
                        Navigation.nextIndex = i + 4;
                        break;
                    }
                }
            }
            else if(itemCount == ItemManager.TotalNumTextCount -1){
                Navigation.nextObject[2].SetActive(true);
                Navigation.nextIndex = 2;
            }
            else if(itemCount == ItemManager.TotalNumTextCount){
                Navigation.nextIndex = 0;
                npcChat.SetActive(true);
            }
        }
        // Trigger된 상태가 ItemStarEffect이라면
        if(other.tag == "ItemStarEffect"){
            // 효과 반영!
            other.gameObject.SetActive(true);
        }
    }
}
