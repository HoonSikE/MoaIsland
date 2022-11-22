using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperBarControl : MonoBehaviour
{
    public GameObject Panel;
    public bool open = false;
    public void onButtonClick()
    {
        open = !open;
        Panel.SetActive(open);
    }
}
