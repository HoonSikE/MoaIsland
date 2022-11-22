using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstOut : MonoBehaviour
{
    public Image blackout;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Fade();
        }
    }
    float time = 0f;
    float F_time = 1f;

    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }
    IEnumerator FadeFlow()
    {
        blackout.gameObject.SetActive(true);
        time = 0f;
        Color alpha = blackout.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            blackout.color = alpha;
            yield return null;
        }

        time = 0f;

        yield return new WaitForSeconds(7.3f);

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            blackout.color = alpha;
            yield return null;
        }
        blackout.gameObject.SetActive(false);
        yield return null;
    }
}
