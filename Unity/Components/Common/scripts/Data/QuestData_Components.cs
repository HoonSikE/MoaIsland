using System.Collections;
using System.Collections.Generic;

// 퀘스트 데이터
public class QuestData_Components {
    public string questName;
    public int[] npcId;

    public QuestData_Components(string name, int[] npc){
        questName = name;
        npcId = npc;
    }
}
