using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rigidbody;

    private float h;
    private float v;

    private float moveX;
    private float moveZ;
    private float speedH = 5f;
    private float speedZ = 80f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if(collision.collider.tag == "Cube")
        {
            Debug.Log("충돌감지");
            //animator.Play("Fox_Sit2_Idle",-1,0);
            //this.transform.Translate(Vector3.back * speedZ * Time.deltaTime);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag =="NPC")
        {
            GameObject canvas = GameObject.FindWithTag("Canvas");
            if (canvas == null)
            {
                return;
            }
            Transform tf = canvas.transform;
            GameObject panel = tf.Find("Panel").gameObject;
            if(panel == null)
            {
                return;
            }
            panel.SetActive(true);
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


        if (collision.collider.tag == "Cube")
        {
            Debug.Log("충돌 종료");
        }
    }
}
