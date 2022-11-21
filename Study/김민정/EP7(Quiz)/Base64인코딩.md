```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class CertificateScript : MonoBehaviour
{
    public TextMeshProUGUI information;
    public TextMeshProUGUI nowDate;
    public GameObject saveBtn;
    public GameObject popUp;
    public GameObject exitButton;


    private void Awake()
    {
        popUp.SetActive(false);
        exitButton.SetActive(false);
    }
    void Start()
    {
        nowDate.text = DateTime.Now.ToString("yyyy년 MM월 dd일");

        // 최종 시점에서 주석 풀기 (null 처리 때문에 주석 해둠)
        //information.text = GameObject.Find("InformationConfirm").GetComponent<TextMeshProUGUI>().text + "  <size=110>" + GameObject.Find("NameConfirm").GetComponent<TextMeshProUGUI>().text+"</size>";
        information.text = "이곡초등학교 6학년 3반   <size=110>김민정</size>";
    }


    public void CaptureScreen()
    {
        saveBtn.SetActive(false);
        exitButton.SetActive(false);
        StartCoroutine(CaptureScreenForPC());
    }

    IEnumerator CaptureScreenForPC()
    {
        //yield return new WaitForSeconds(0.5f);
        ScreenCapture.CaptureScreenshot("/certification.png");
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

    // Use this for initialization
    public void Screenshot()
    {
        //StartCoroutine(UploadPNG());
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        yield return new WaitForEndOfFrame();

        Texture2D texture = new Texture2D(Screen.width, Screen.height);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();
        byte[] bytes = texture.EncodeToPNG();
        Destroy(texture);
        string encodedText = System.Convert.ToBase64String(bytes);

        var image_url = "data:image/png;base64," + encodedText;

        Debug.Log(image_url);
    }

    IEnumerator UploadPNG()
    {
        // We should only read the screen after all rendering is complete
        yield return new WaitForEndOfFrame();

        // Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        var tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToPNG();
        Destroy(tex);

        //string ToBase64String byte[]
        string encodedText = Convert.ToBase64String(bytes);
        var image_url = "data:image/png;base64," + encodedText;

        Debug.Log(image_url);

#if !UNITY_EDITOR
        openWindow(image_url);
#endif
    }

    [DllImport("__Internal")]
    private static extern void openWindow(string url);
    //private void CaptureScreenForMobile(string fileName)
    //{
    //Texture2D texture = ScreenCapture.CaptureScreenshotAsTexture();

    // do something with texture
    //string albumName = "BRUNCH";
    //NativeGallery.SaveImageToGallery(texture, albumName, fileName, (success, path) =>
    //{
    //    Debug.Log(success);
    //    Debug.Log(path);
    //});

    // cleanup
    //Object.Destroy(texture);
    //}
}
```

