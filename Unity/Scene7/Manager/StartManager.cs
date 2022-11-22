using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public GameObject StartCanvas;
    public GameObject InformationCanvas;
    public GameObject ProblemCanvas;
    public GameObject CertificateCanvas;
    public Button quizButton;

    public void Awake()
    {
        StartCanvas.SetActive(true);
        InformationCanvas.SetActive(false);
        ProblemCanvas.SetActive(false);
        CertificateCanvas.SetActive(false);
    }

    public void Start()
    {
        quizButton.onClick.AddListener(ChangeScene);
    }

    public void ChangeScene()
    {
        StartCanvas.SetActive(false);
        InformationCanvas.SetActive(true);
    }
}
