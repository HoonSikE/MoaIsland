using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_Move_Components : MonoBehaviour {
    // 수평
    float h;
    // 수직
    float v;
    // 달리기 수행 여부
    bool runDown;
    // 점프 수행 여부
    bool jumpDown;

    // 캐릭터 이동 벡터
    Vector3 moveVec;

    // 속도 (초기값: 5)
    public float speed;
    // 점프 파워 (초기값: 30)
    public float jumpPower;
    // 소리 배열(걷기, 점프)
    AudioSource[] audios;
    // 걷기 소리
    AudioSource walkAudio;
    // 점프 소리
    AudioSource jumpAudio;
    // 점프 중인지 확인 (초기값: false)
    bool isJump = false;
    // 이동 Animator (걷기, 천천히 걷기, 점프)
    Animator moveAnim;

    // rigid 선언 (캐릭터 제자리 회전 방지)
    Rigidbody rigid;

    public GameManager_Components manager;
    // Trigger에서 식별되는 오브젝트
    GameObject scanObject;

    void Awake()
    {
        audios = GetComponents<AudioSource>();
        walkAudio = audios[0];
        jumpAudio = audios[1];

        moveAnim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();   
    }

    void Start()
    {
       
    }

    void Update()
    {
        GetInput();
        Move();
        Jump();
    }


    void GetInput()
    {
        // 움직일 수 있는 상태(manager.isAction==true)라면 상하좌우 걷기, 달리기, 점프 가능
        h = manager.isAction ? Input.GetAxisRaw("Horizontal") : 0;
        v = manager.isAction ? Input.GetAxisRaw("Vertical") : 0;
        runDown = manager.isAction ? Input.GetButton("Run") : false;
        jumpDown = manager.isAction ? Input.GetButtonDown("Jump") : false;
    }

    void Move()
    {
        moveVec = new Vector3(h, 0, v).normalized;

        // 걷기 모션
        moveAnim.SetBool("isWalk", moveVec != Vector3.zero);
        // 달리기 모션 
        moveAnim.SetBool("isRun", runDown);

        // 달리기 버튼을 눌렀을 때
        RunOrWalk(runDown ? 2.0f : 1.0f);
    }



    void RunOrWalk(float sp) // speed :걷기는 1.0f, 달리기는 2.0f 속도가 다름
    {

        moveVec = new Vector3(h, 0, v).normalized;
        if(moveVec != Vector3.zero)
        {
            if(!walkAudio.isPlaying)
            {
                walkAudio.pitch = (sp == 1.0f) ? 1f : 1.4f;
                walkAudio.Play();
            }
        }

        // 위 방향키를 누를 경우
        if (v > 0)
            // 앞으로 이동
            this.transform.Translate(Vector3.forward * speed * sp * Time.deltaTime);
        // 아래 방향키를 누를 경우
        if (v < 0)
            // 뒤로 이동
            this.transform.Translate(Vector3.back * speed * sp * Time.deltaTime);
        // 왼쪽 방향키를 누를 경우
        if (h < 0)
        {
            // 왼쪽 방향키 + 위 방향키 => 반시계 방향으로 앞으로 회전
            if(v >= 0)
                this.transform.Rotate(0, -speed * Time.deltaTime * 25, 0);
            // 왼쪽 방향키 + 아래 방향키 => 시계 방향으로 뒤로 회전
            else
                this.transform.Rotate(0, speed * Time.deltaTime * 25, 0);
        }
        // 오른쪽 방향키를 누를 경우
        if (h > 0)
        {
            // 오른쪽 방향키 + 위 방향키 => 시계 방향으로 앞으로 회전
            if (v >= 0)
                this.transform.Rotate(0, speed * Time.deltaTime * 25, 0);
            // 오른쪽 방향키 + 아래 방향키 => 반시계 방향으로 뒤로 회전
            else
                this.transform.Rotate(0, -speed * Time.deltaTime * 25, 0);
        }
    }


    void Jump()
    {
        // Jump 버튼(Space)를 눌렀을 때 && 점프 상태가 아니고 && 움직일 수 있는 상태일 때
        if (jumpDown && !isJump && manager.isAction)
        {

            // 점프
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);

            // 점프 소리가 음소거되어 있다면 다시 활성화
            if (jumpAudio.mute == true)
                jumpAudio.mute = false;

            // 점프 시 겯기 소리 비활성화
            walkAudio.mute = true;
            // 점프 소리
            jumpAudio.Play();
            

            // 점프 활성화
            isJump = true;
            // 점프 모션
            moveAnim.SetBool("isJump", isJump);
        }
    }

    void FixedUpdate(){
        // 빙글빙글 도는 현상 방지 함수
        FreezeRotation();
    }

    // 빙글빙글 도는 현상 방지 함수
    void FreezeRotation() {
        // angularVelocity : 물리 회전 속도
        // 회전 속도를 0로 유지
        rigid.angularVelocity = Vector3.zero;
    }
    
    void OnCollisionEnter(Collision collision){
        // 땅에 닿으면 jump 다시 할 수 있음
        // 기존 땅을 "Ground"로 고정해야함.
        if(collision.gameObject.tag == "Map"){
            moveAnim.SetBool("isJump", false);
        }

        if(collision.gameObject.tag == "Ground"){
            
            // 땅에 닿으면 걷기 소리 활성화
            walkAudio.mute = false;

            isJump = false;
            moveAnim.SetBool("isJump", isJump);
        }
    }
}
