using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class BatEnemyMove : MonoBehaviour
{
    //이동 속도 변수 선언
    public float speed;

    //상하로 이동할 거리 변수 선언
    public float distance;

    //이동 뱡향
    int direction = 1;

    //초기 위치 변수
    //Vector2는 위치 변수
    Vector2 originalPosition;

    //적 죽음값 저장
    bool isDead;

    //스프라이트 렌더러 변수 선언
    SpriteRenderer sr;

    //투명해지는 속도
    float colorSpeed = 5f;


    void Start()
    {
        //초기 위치를 현재 위치(transform.position)로 선언
        originalPosition = transform.position;

        //sr변수에 스프라이트렌더러 할당하기
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        //만약에 적이 죽지 않았다면
        if (!isDead)
        {
            //적 움직임
            EnemyMove();
        }

        //적이 죽었다면
        else
        {
            //서서히 투명해 지도록
            //Vector4(R,G,B,A) A=0이라는건 투명해짐을 의미한다.
            //Lerp : 보간함수(A에서 B로 천천히(서서히) 움직여라)
            //시작 값과 끝 값 사이에사 원하는 비율만큼의 값을 계산해주는 함수다.
            sr.color = Vector4.Lerp(sr.color, new Vector4(1, 1, 1, 0), Time.deltaTime * colorSpeed);

            //많이 투명해졌다면
            if(sr.color.a <= 0.5f)
            {
                //게임오브젝트 삭제
                Destroy(gameObject);
            }
        }
    }

    void EnemyMove()
    {
        //박쥐를 위 아래로 이동
        //Vector2(x, y)
        Vector2 targetPosition = originalPosition + new Vector2(0, distance * direction);

        //Vector3.MoveTowards(현재위치, 목표위치, 속도)
        //특정 오브젝트가 목표지점까지 이동할 수 있게 해주는 함수이다.
        //Time.deltaTime) : 프레임 속도에 상관없이 일정한 속도로 움직이기 위해서 사용한다.
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        //Vector2.Distance(a,b) - > a와 b사이의 직선 거리를 반환한다,
        if (Vector2.Distance(transform.position, targetPosition) < 0.01f)
        {
            //이동 방향을 반전
            direction *= -1;
        }
    }

    //Dead함수 선언
    public void Dead()
    {
        //죽었음을 저장
        isDead = true;
    }
}
