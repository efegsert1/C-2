using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    //리지드 바디 변수 선언
    Rigidbody2D rig;

    //스피드 변수 선언
    public int speed;
    
 
    void Start()
    {
        //rig라는 변수에 리지드바디 컴포넌트 할당하기
        rig = GetComponent<Rigidbody2D>();
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
        /*if(rig.velocity.x > speed)
        {
            //제한 속도 고정
            rig.velocity.x = new Vector2(speed, rig.velocity.y);
        }

        //왼쪽 제한속도보다 빠르다면
        if (rig.velocity.x < speed)
        {
            //제한 속도 고정
            rig.velocity.x = new Vector2(speed, rig.velocity.y);
        }*/
    }
}
