using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

// Fade 클래스
// 사용 법 Canvas에 Fade(전체화면 검정 이미지)를 선언하고 fade.stopIn/Out 값을 false로 하면 실행된다.
// 주의점 : Image의 Raycast Target을 flase로 해줘야한다. (캔버스에 가려서 클릭 안되는 것 방지)
public class Fade_Components : MonoBehaviour
{
    public Image fadeImage;
    float time = 0f;
    float F_time = 1f;

    void Awake(){
        FadeIn();
    }
    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }
    IEnumerator FadeFlow()
    {
        fadeImage.gameObject.SetActive(true);
        time = 0f;
        Color alpha = fadeImage.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            fadeImage.color = alpha;
            yield return null;
        }

        time = 0f;

        yield return new WaitForSeconds(1f);

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            fadeImage.color = alpha;
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);
        yield return null;
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInFlow());
    }
    IEnumerator FadeInFlow()
    {
        fadeImage.gameObject.SetActive(true);
        time = 0f;

        yield return new WaitForSeconds(1f);

        Color alpha = fadeImage.color;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            fadeImage.color = alpha;
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);
        yield return null;
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutFlow());
    }
    IEnumerator FadeOutFlow()
    {
        fadeImage.gameObject.SetActive(true);
        time = 0f;
        
        Color alpha = fadeImage.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            fadeImage.color = alpha;
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);
    }
}
