using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampScript : MonoBehaviour
{
    private float size = 0.9f;  // 원하는 사이즈
    private float speed = 1f;    // 작아질 때의 속도
    private float time;

    public AudioSource stampSound;

    //public GameObject canvas;
    public  GameObject stamp1;
    public  GameObject stamp2;
    public  GameObject stamp3;
    public  GameObject stamp4;
    public  GameObject stamp5;
    public GameObject map;

    public bool[] conditions = new bool[5];  // 도장 false -> true 바꾸는지 여부
    public bool[] presences = new bool[5];   // 이미 완료 도장 찍혀 있었는지 여부
    public GameObject[] stamps = new GameObject[5];

    void Awake()
    {
        /*canvas = GameObject.Find("Canvas");
        Transform tf = canvas.transform;
        stamp1 = tf.Find("Stamp1").gameObject;
        stamp2 = tf.Find("Stamp2").gameObject;
        stamp3 = tf.Find("Stamp3").gameObject;
        stamp4 = tf.Find("Stamp4").gameObject;
        stamp5 = tf.Find("Stamp5").gameObject;
        stamps[0] = stamp1;
        stamps[1] = stamp2;
        stamps[2] = stamp3;
        stamps[3] = stamp4;
        stamps[4] = stamp5;*/
        

    }

    public void startStamp()
    {
        for (int i = 0; i < 5; i++)
        {
            if (!conditions[i])
            {
                stamps[i].SetActive(false);
            }
            if (conditions[i] && presences[i])
            {
                stamp1.transform.localScale = new Vector3(0.9f, 0.9f, 0);
                stamps[i].SetActive(true);

            }
            if (conditions[i] && !presences[i])
            {
                stamps[i].SetActive(true);
                stamps[i].transform.localScale = new Vector3(
                    stamps[i].transform.localScale.x * 10,
                    stamps[i].transform.localScale.y * 10,
                    0
                );
                StartCoroutine(Down(stamps[i]));
                presences[i] = true;
            }
        }
        /*stamp1.SetActive(false);
        stamp2.SetActive(false);
        stamp3.SetActive(false);
        stamp4.SetActive(false);
        stamp5.SetActive(false);
        map.SetActive(false);*/
    }

    IEnumerator Down(GameObject stamp)
    {
        stampSound.loop = false;
        stampSound.Play();
        while (stamp.transform.localScale.x > size)
        {
            //stamp1.transform.localScale = stamp1.transform.localScale * (1f - time * speed);
            stamp.transform.localScale = new Vector3(
                stamp.transform.localScale.x - 1f * speed * time,
                stamp.transform.localScale.y - 1f * speed * time,
                0
            );
            time += Time.deltaTime;

            if (stamp.transform.localScale.x <= size)
            {
                time = 0;
                stamp.transform.localScale = new Vector3(size, size, 0);
                break;
            }
            yield return null;
        }
    }
}