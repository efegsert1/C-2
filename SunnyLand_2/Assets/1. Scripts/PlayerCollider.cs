using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UI를 사용한다고 선언해주기

public class PlayerCollider : MonoBehaviour
{
    //스코어텍스트 변수
    //public : 인스펙터에다가 이 게임 오브젝트를 드래그해서 넣어줘야 한다.
    public Text txt;

    //스코어 숫자 변수 선언
    public int score;

    void Start()
    {
        //스코어 변수 초기화
        score = 0;
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //만약 "Item"이라는 태그를 가진 게임오브젝트와 부딪혔다면
        //collision.CompareTag("Item")
        if (collision.gameObject.tag == "Item")
        {
            //부딪힌 게임오브젝트 tag 출력
            Debug.Log("충돌 완료" +  collision.gameObject.tag);

            //게임오브젝트 삭제하기
            Destroy(collision.gameObject);

            //스코어 점수 1씩 증가
            score += 1;

            //ToString() : 데이터 형식을 문자열로 변환
            //사용 방법[문법] : 변수 이름.ToString
            //참고로 score는 int형식입니다.
            //int->Stirng으로 바꾸는 작업
            txt.text = score.ToString();
        }
    }
}
