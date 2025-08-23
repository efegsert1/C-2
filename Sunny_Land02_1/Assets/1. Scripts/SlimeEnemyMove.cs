using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemyMove : MonoBehaviour
{
    //리지드바디 변수 선언 rig
    Rigidbody2D rig;

    SpriteRenderer sr;
    Animator anim;

    //적이 이동할 방향(정수형이고, 변수명은 dir)
    int dir;

    //적의 방향 조절
    bool isChange;

    //레이저의 시작 위치 조절
    Vector3 rayPos;

    void Start()
    {
        //rig변수에 리지드바디2D 할당하기
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        RandomDir();
    }

    void Update()
    {
        //랜덤한 방향으로 이동(velocity 값을 저절로)
        rig.velocity = new Vector2(dir, rig.velocity.y);

        //레이저 그리기
        //Unity의 디버그용 레이저(선) 그리는 함수_게임화면에서는 보이지 않음
        //Debug.DrawRay(현재 시작점, 어느 방향으로 얼마나 그릴지
        Debug.DrawRay(transform.position + rayPos, Vector2.down * 1);

        //레이저에 맞은 물체 저장 = 레이캐스트
        //RaycastHit2D : 레이저가 맞은 오브젝트에 대한 정보를 담는 변수
        //Physics2D.Raycast(시작 위치, 레이저가 날아가는 방향, 레이저 길이(얼마큼 쏠지))
        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayPos, Vector2.down, 1);

        //레이에 맞은 물체가 없다면
        if(!hit)
        {
            //방향 바꾸기
            ChangeDir();
        }

        //레이에 물체가 맞았다면
        else
        {
            //만약에 맞은 물체가 바닥이 아니라면
            if (hit.collider.gameObject.tag == "Floor")
            {
                //방향 바꾸기
                ChangeDir();
            }

            //아직 내가 바닥이라면
            else
            {
                isChange = false;
            }
        }

        rayPos = new Vector3(0.7f, 0, 0);

        switch(dir)
        {
            //멈춰있다면
            case 0:
                anim.SetBool("isWalk", false);
                break;
            //왼쪽으로 간다면
            case -1:
                anim.SetBool("isWalk", true);
                sr.flipX = false;
                rayPos = new Vector3(-0.7f, 0, 0);
                break;
            //오른쪽으로 간다면
            case 1:
                anim.SetBool("isWalk", true);
                sr.flipX = true;
                rayPos = new Vector3(0.7f, 0, 0);
                break;
        }
    }

    void RandomDir()
    {
        //방향값 -1,0,1
        //Random.Range(최솟값, 최대값) : 랜덤 함수 * 최대값은 포함이 되지 않기 때문에 +1을 해서 계산
        //1~10
        //Random.Range(1, 11);
        dir = Random.Range(-1, 2);


        //Invoke : 자신이 설정한 시간 만큼 함수 시작 시간을 지연시키는 기능
        //Invoke("메서드명", 지연시키고 싶은 시간)
        Invoke("RandomDir", Random.Range(2f, 3f));
    }

    void ChangeDir()
    {
        if(!isChange)
        {
            //방향 바꾸기
            dir *= -1;

            //방향을 바꿨음을 저장
            isChange = true;

            //인보크 기능 취소
            CancelInvoke();

            //랜덤 주기로 반복
            Invoke("RandomDir", Random.Range(2f, 3f));
        }
    }
}
