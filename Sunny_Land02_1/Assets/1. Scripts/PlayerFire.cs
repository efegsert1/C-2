using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //총알 발사하는 힘 
    public float bulletPower;

    //총알을 발사하는 방향 변수
    int dir;

    //총알 오브젝트 배열 사용
    //총알 5개를 배열에 넣는다.
    GameObject[] bulletPool = new GameObject[5];

    //플레어이무스 스크립트를 변수로 선언
    PlayerMove playerMove;



    void Start()
    {
        playerMove = GetComponent<PlayerMove>();

        //탄창에 들어갈 총알 개수만큼 반복
        for (int i = 0; i < bulletPool.Length; i++)
        {
            //총알 복제해서 생성
            //프리팹을 복사해서 쓰고 싶다(Instantiate
            //Bullet -> Resources폴더에 있는 프리팹명과 똑같아야 한다.
            GameObject bullet = Instantiate(Resources.Load("Bullet")) as GameObject;

            //총알 오브젝트를 풀에 넣기
            //for (i = 0)
            //bulletPool[0] = bullet
            bulletPool[i] = bullet;

            //총알 비활성화
            bulletPool[i].SetActive(false);
        }
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            //총알 개수 만큼 반복
            for (int i = 0; i < bulletPool.Length; i++)
            { 
                //1번째 총알 저장
                GameObject bullet = bulletPool[i];


                //아직 쏘지 않는 총알만 비활성화
                //activeSelf : 자신에게 설정된 활성화 상태를 나타내는 속성(bool)
                if (!bullet.activeSelf)
                { 
                    bullet.SetActive(true);

                    //만약에 플레이어가 왼쪽을 보고 있다면
                    //다른클래스의 변수를 사용하고 싶다면
                    //클래스변수명.클래스 안에 있는 변수명
                    //왼쪽을 바라보고 있다면
                    if (playerMove.sr.flipX)
                    {
                        //총알 방향을 왼쪽으로
                        dir = -1;

                    }
                    //오른쪽을 바라보고 있다면
                    else
                    {
                        dir = 1;
                    }

                    //총알 생성 위치 변경
                    bullet.transform.position = transform.position + new Vector3(dir * 0.5f, -0.5f, 0);

                    //총알에 힘 가하기
                    bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * dir * bulletPower, ForceMode2D.Impulse);

                    //1초 후에 재사용할 수 있도록
                    //코루틴 함수를 실행시키기 위해서는 StartCoroutine을 사용
                    //StartCoroutine(코루틴함수명)  : 매개변수가 없을 시에
                    //StartCoroutine(코루틴함수명(매개변수)) :매개변수가 있을 시
                    StartCoroutine(ResetBullet(bullet));

                    break;

                }

            }

        }

    }

    //코루틴 함수 : 재사용
    //한 함수의 실행을 중간에 잠깐 멈췄다가, 다음 프레이부터 이어서 실행할 수
    //있게 해주는 흐름제어다.
    IEnumerator ResetBullet(GameObject bullet)
    {
        //1초 뒤에 실행(대기)
        yield return new WaitForSeconds(1);

        //발사된 총알 비활성화
        bullet.SetActive(false);
    
    }



}
