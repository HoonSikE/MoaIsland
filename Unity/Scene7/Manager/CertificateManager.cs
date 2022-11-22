using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class CertificateManager : MonoBehaviour
{
    public GameObject StartCanvas;
    public GameObject InformationCanvas;
    public GameObject ProblemCanvas;
    public GameObject CertificateCanvas;

    public TextMeshProUGUI information;
    public TextMeshProUGUI nowDate;
    public GameObject saveBtn;
    public GameObject popUp;
    public GameObject exitButton;

    public GameObject InformationConfirm;
    public GameObject NameConfirm;


    private void Awake()
    {
        StartCanvas.SetActive(false);
        InformationCanvas.SetActive(false);
        ProblemCanvas.SetActive(false);
        CertificateCanvas.SetActive(true);
    }

    void Update()
    {
        nowDate.text = DateTime.Now.ToString("yyyy년 MM월 dd일");

        // 최종 시점에서 주석 풀기 (null 처리 때문에 주석 해둠)
        information.text = InformationConfirm.GetComponent<TextMeshProUGUI>().text + "  <size=110>" + NameConfirm.GetComponent<TextMeshProUGUI>().text + "</size>";
    }

    public void CaptureScreen()
    {
        saveBtn.SetActive(false);
        exitButton.SetActive(false);
        StartCoroutine(SaveScreeJpg());
    }

    IEnumerator SaveScreeJpg()
    {
        //yield return new WaitForSeconds(0.5f);
        yield return new WaitForEndOfFrame();

        Texture2D texture = new Texture2D(Screen.width, Screen.height);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();
        byte[] bytes = texture.EncodeToJPG();
        //File.WriteAllBytes(filePath, bytes);
        // https://juyoung-1008.tistory.com/4
        string fileName = "Moaisland " + InformationConfirm.GetComponent<TextMeshProUGUI>().text + " " + NameConfirm.GetComponent<TextMeshProUGUI>().text + ".jpeg";
        WebGLFileSaver.SaveFile(bytes, fileName, "image/jpeg");
        DestroyImmediate(texture);

        Debug.Log("화면 캡처 성공");
        yield return new WaitForSeconds(0.5f);

        popUp.SetActive(true);
        yield return new WaitForSeconds(1f);

        saveBtn.SetActive(true);
        exitButton.SetActive(true);
        popUp.SetActive(false);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

}
