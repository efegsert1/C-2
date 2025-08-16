using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMove : MonoBehaviour
{
    //리지드 바디 변수 선언
    Rigidbody2D rig;

    //스피드 변수 선언
    public int speed;

    //스트라이트 렌더러 변수 선언
    SpriteRenderer sr;

    //애니메이터 변수 선언
    Animator anim;

    //점프하는 힘(일반변수, 컴포넌트가 아님)
    public int jumpPower;

    //일반 변수 : 점프 카운트
    int jumpcount;

    //사다리 변수 선언
    public bool isLadder;

    //올라가는 힘 변수
    public float maxSpeed;

    void Start()
    {
        //rig라는 변수에 리지드바디 컴포넌트 할당하기
        rig = GetComponent<Rigidbody2D>();

        //sr라는 변수에 스프라이트렌더러 컴포넌트 할당하기
        sr = GetComponent<SpriteRenderer>();

        //anim라는 변수에 애니메이터 컴포넌트 할당하기
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        //좌우 키보드 누른 값 저장
        //GetAxisRaw : 키보드, 조이스틱, 마우스의 입력값을 -1과 0 1로 즉각 반환하는 함수입니다.
        //GetAxis -1 0.5 0 0.5 1 부드럽게 변화를 줌
        float xinput = Input.GetAxisRaw("Horizontal");


        //AddForce 가할 힘의 크기와 방향을 나타낸다.
        //Mode(선택) : 힘을 가하는 방식
        //ForceMode 값 4가지
        //Force : 기본 값, 질량과 Time.deltaTime의 영향을 받아 서서히 가속
        //Acceleration : 질량에 상관없이 서서히 가속
        //Inpulse : 질량에 영향을 받으며 한번에 순간적으로 힘을 가함(점프, 총알 공격)
        //Velocity : 질량 무시, 순간적으로 속도를 변화(즉시 속도 변경)
        rig.AddForce(Vector2.right * xinput, ForceMode2D.Impulse);

        //오른쪽 제한 속도보다 빠르면
        if (rig.velocity.x > speed)
        {
            //제한 속도 고정
            rig.velocity = new Vector2(speed, rig.velocity.y);
        }

        //왼쪽(-1) 제한속도보다 빠르다면
        if (rig.velocity.x < -speed)
        {
            //제한 속도 고정
            rig.velocity = new Vector2(-speed, rig.velocity.y);
        }

        //좌우 방향키를 떼면
        if (Input.GetButtonUp("Horizontal"))
        {
            //속도 0으로 멈추기 x = 0, y = rig.velocity.y
            //캐릭터의 속도 =
            rig.velocity = new Vector2(0, rig.velocity.y);

            anim.SetBool("isWalk", false);
        }

        //좌우 반전(움직이고 있다면
        if (xinput != 0)
        {
            //Horizontal이 왼쪽이라면 실행하기
            sr.flipX = Input.GetAxisRaw("Horizontal") == -1;

            //걷는 애니메이션을 실행
            //SetBool : 파라미터를 Bool로 만들었기 떄문에
            //SetBool("애니메이터에서 만들어놨던 변수명", true/ false); *실행을 시킬거면 true, 아니면 false
            anim.SetBool("isWalk", true);
        }
        //함수 호출 : Jump에 있는 내용이 모두 실행 된다.
        Jump();
    }

    private void FixedUpdate()
    {
        //사다리를 타고있는 경우
        if(isLadder)
        {
            //위, 아래의 키보드값 저장
            float ver = Input.GetAxisRaw("Vertical");

            //사다리니까 중력을 받으면 안되기 때문에 중력을 0으로 설정
            rig.gravityScale = 0;

            //올라가는 힘
            rig.velocity = new Vector2(rig.velocity.x, ver * maxSpeed);

            //위 아래로 움직이고 있다면
            if (ver != 0)
            {
                //올라가는 애니메이션 활성화
                anim.SetBool("isClimb", true);
            }
        }

        //사다리를 타고 있지 않다면
        else
        {
            //다시 중력값 설정 3
            rig.gravityScale = 3f;
        }
    }




    //점프하는 함수 만들기
    void Jump()
    {
        //스페이스바를 누르고, jumpCount가 2 이하라면 (0,1)
        if (Input.GetButtonDown("Jump") && jumpcount < 2)
        {
            //점프 카운트 증가
            jumpcount++;    //jumpCount = jumpCount + 1

            //위로 점프하기
            //Vector2.up = (0, 1)
            rig.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            
            //점프하는 애니메이션 실행
            anim.SetBool("isJump", true);
        }
    }

    //충돌 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Floor랑 충돌을 했다면
        //()
        if(collision.gameObject.tag == "Floor")
        {
            //점프카운트 초기화
           jumpcount = 0;

            //점프 애니메이션 멈춤
            anim.SetBool("isJump", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //사다리 충돌 영역에 들어왔다면
        if (collision.CompareTag("Ladder"))
        {
            //isLadder를 true로 설정
            isLadder = true;
        }
    }

    //충돌 영역에서 벗어남.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            anim.SetBool("isClimb", false);
        }
    }   


}
