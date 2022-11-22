using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ k������ Ŀ���� z������ �۾���
public class LetterPopup : MonoBehaviour
{
    private float size = 2.3f;  // ���ϴ� ������
    private float speed = 2f;    // �۾��� ���� �ӵ�
    private float downsize = 0.0001f;
    private float time;

    public GameObject canvas;
    public static GameObject letter;

    void Awake()
    {
        canvas = GameObject.Find("Canvas");
        Transform tf = canvas.transform;
        letter = tf.Find("Letter").gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(Up(letter));
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(Down(letter));
        }
    }

    IEnumerator Up(GameObject letter)
    {
        while (letter.transform.localScale.x < size)
        {
            //stamp1.transform.localScale = stamp1.transform.localScale * (1f - time * speed);
            letter.transform.localScale = new Vector3(
                letter.transform.localScale.x + 1f * speed * time,
                letter.transform.localScale.y + 1f * speed * time,
                0
            );
            time += Time.deltaTime;

            if (letter.transform.localScale.x >= size)
            {
                time = 0;
                letter.transform.localScale = new Vector3(size, size, 0);
                break;
            }
            yield return null;
        }
    }

    IEnumerator Down(GameObject letter)
    {
        while (letter.transform.localScale.x > downsize)
        {
            //stamp1.transform.localScale = stamp1.transform.localScale * (1f - time * speed);
            letter.transform.localScale = new Vector3(
                letter.transform.localScale.x - 1f * speed * time,
                letter.transform.localScale.y - 1f * speed * time,
                0
            );
            time += Time.deltaTime;

            if (letter.transform.localScale.x <= downsize)
            {
                time = 0;
                letter.transform.localScale = new Vector3(downsize, downsize, 0);
                break;
            }
            yield return null;
        }
    }
}
