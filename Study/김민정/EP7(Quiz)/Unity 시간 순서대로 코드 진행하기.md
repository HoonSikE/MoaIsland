# Unity 시간 순서대로 코드 진행하기



React의 경우, 시간 순서대로 코드를 진행하고 싶을 때(axios 등), async ~ await를 사용한다.

Unity의 경우에는 StartCoroutine, IEumerator를 사용한다.



코드를 순서대로 실행하고 싶은 함수 앞에 `IEumerator`를 적어주고, 해당 함수를 불러올 때 `StartCoroutine(함수 이름())`으로 불러온다.



IEumerator 함수 내에서는 코드 사이에 delay를 걸어줄 수 있는데, `yield return new WaitForSeconds(시간)`으로 적어주면 된다.



* 예시

```c#
public void CaptureScreen()
{

    #if UNITY_IPHONE || UNITY_ANDROID
        CaptureScreenForMobile("certification.png");
    #else
        saveBtn.SetActive(false);
    exitButton.SetActive(false);
    StartCoroutine(CaptureScreenForPC());

    #endif
}

IEnumerator CaptureScreenForPC()
{
    yield return new WaitForSeconds(0.5f);
    ScreenCapture.CaptureScreenshot("/certification.png");
    Debug.Log("화면 캡처 성공");
    yield return new WaitForSeconds(0.5f);
    popUp.SetActive(true);
    saveBtn.SetActive(true);
    exitButton.SetActive(true);
    yield return new WaitForSeconds(1f);
    popUp.SetActive(false);
}
```

