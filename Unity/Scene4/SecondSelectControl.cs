using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class SecondSelectControl : MonoBehaviour
{
    public SecondSelectManager SecondSelectManager;
    public TextMeshProUGUI Text;
    public GameObject circleImage;

    private void Update()
    {
        if (SecondSelectManager.SelectedText == Text)
        {
            Text.fontSize = 80;
            circleImage.SetActive(true);
            Text.color = Color.black;
        }
        else
        {
            Text.fontSize = 70;
            circleImage.SetActive(false);
            Text.color = Color.black;
        }
    }

    public void onButtonClick()
    {
        if(SecondSelectManager.SelectedText == Text)
        {
            SecondSelectManager.SelectedText = null;
        }
        else
        {
            SecondSelectManager.SelectedText = Text;
        }
    }
/*    public Player_Talk_Scene4 Player_Talk_Scene4;
    public TextMeshProUGUI Text;
    public bool Change = false;

    void Update()
    {   
        if(Player_Talk_Scene4.SecondSelectStart)
        {
            if (Player_Talk_Scene4.isGood)
            {
                if(Text.text == "생선 가게")
                {

                    Text.fontSize = 90;
                    Text.color = Color.red;
                }
                else
                {
                    Text.fontSize = 70;
                    Text.color = Color.black;
                }
            }

            else
            {
                if (Text.text == "생선 가게")
                {
                    Text.fontSize = 70;
                    Text.color = Color.black;
                }
                else
                {
                    Text.fontSize = 90;
                    Text.color = Color.red;
                }
            }
        }
    }
*/
}

