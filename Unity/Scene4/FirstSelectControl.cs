using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FirstSelectControl : MonoBehaviour
{
    public FirstSelectManager FirstSelectManager;
    public TextMeshProUGUI Text;
    public GameObject circleImage;

    private void Update()
    {
        if (FirstSelectManager.SelectedText == Text)
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
        if(FirstSelectManager.SelectedText == Text)
        {
            FirstSelectManager.SelectedText = null;
        }
        else
        {
            FirstSelectManager.SelectedText = Text;
        }
    }
}
