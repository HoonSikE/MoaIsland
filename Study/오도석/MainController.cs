using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rigidbody;

    private float h;
    private float v;

    private bool[] chatCheck = new bool[2];

    private int[] chat = new int[2];

    private float moveX;
    private float moveZ;
    private float speedH = 5f;
    private float speedZ = 80f;

    public GameObject Epush;
    public GameObject Warn1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        Epush = GameObject.FindWithTag("EpushEvent");
        Warn1 = GameObject.Find("Warn1");
        if (Warn1 == null)
        {
            Debug.Log("x");
        }
        if(Epush == null)
        {
            Debug.Log("x");
        }
        Epush.SetActive(false);
        Warn1.SetActive(false);
        chat[0] = 0;

    }

    // Update is called once per frame
    void Update()
    {
        {
            GameObject canvas = GameObject.FindWithTag("Canvas");
            if (canvas == null)
            {
                return;
            }
            Transform tf = canvas.transform;
            GameObject panel = tf.Find("Panel").gameObject;
            if (panel == null)
            {
                return;
            }

            if (panel.activeSelf == true && Input.GetKeyDown(KeyCode.P))
            {
                chat[0] += 1;
            }
        }
        Debug.Log(chat[0]);
        if(chat[0]> 5)
        {
            Warn1.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Fox_Jump_Pivot_InPlace", -1, 0);
        }
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        animator.SetFloat("h", h);
        animator.SetFloat("v", v);

        /*moveX = h * speedH * Time.deltaTime;
        moveZ = v * speedZ * Time.deltaTime;
         
        if(moveZ <= 0)
        {
            moveX = 0;
        }

        rigidbody.velocity = new Vector3(moveX, 0, moveZ);*/



        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(Vector3.forward * speedH * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            this.transform.Translate(Vector3.back * speedH * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if(v >= 0)
            {
                this.transform.Rotate(0, -speedH * 10 *  Time.deltaTime, 0);
            }
            else
            {
                this.transform.Rotate(0, speedH * 10 *Time.deltaTime, 0);
            }
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if(v >= 0)
            {
                this.transform.Rotate(0, speedH * 10 * Time.deltaTime, 0);
            }
            else
            {
                this.transform.Rotate(0, -speedH * 10 * Time.deltaTime, 0);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "NPC")
        {
            Epush.SetActive(true);



            if (Input.GetKey(KeyCode.E))
            {
                GameObject canvas = GameObject.FindWithTag("Canvas");
                if (canvas == null)
                {
                    return;
                }
                Transform tf = canvas.transform;
                GameObject panel = tf.Find("Panel").gameObject;
                if (panel == null)
                {
                    return;
                }
                panel.SetActive(true);

                
            }


        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag =="NPC")
        {
            Epush.SetActive(true);

            GameObject canvas = GameObject.FindWithTag("Canvas");
            if (canvas == null)
            {
                return;
            }
            Transform tf = canvas.transform;
            GameObject panel = tf.Find("Panel").gameObject;
            if (panel == null)
            {
                return;
            }

            if (Input.GetKey(KeyCode.E))
            {
                
                panel.SetActive(true);
                
            }
            


        }

        if (collision.collider.tag=="Cube")
        {
            Debug.Log("충돌유지");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject canvas = GameObject.FindWithTag("Canvas");
        Transform tf = canvas.transform;
        GameObject panel = tf.Find("Panel").gameObject;;
        panel.SetActive(false);
        Epush.SetActive(false);


        if (collision.collider.tag == "Cube")
        {
            Debug.Log("충돌 종료");
        }
    }
}
