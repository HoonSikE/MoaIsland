using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectControl_Scene2 : MonoBehaviour
{
    public SelectManager_Scene2 SelectManager;
    public Text Text;
    public GameObject circleImage;

    private void Update()
    {
        if (SelectManager.SelectedText == Text)
        {
            Text.fontSize = 70;
            circleImage.SetActive(true);
            Text.color = Color.black;
        }
        else
        {
            Text.fontSize = 64;
            circleImage.SetActive(false);
            Text.color = Color.black;
        }
    }

    public void onButtonClick()
    {
        if(SelectManager.SelectedText == Text)
        {
            SelectManager.SelectedText = null;
        }
        else
        {
            SelectManager.SelectedText = Text;
        }
    }
}
