using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //만약에 충돌한 게임오브젝트 태그가 "Enemey"라면
        //Debug.Log("출력);
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("출력");

            //총알이 박쥐에 맞았는지 판정내기
            //Dead함수 호출
            //SendMessage() -> 게임오브젝트에 연결된 컴포넌트들에 특정 함수(메서드) 호출할 수 있도록 해줌
            //다른 클래스에 있는 함수를 호출할 수 있음
            collision.SendMessage("Dead");

            //게임오브젝트 비활성화
            gameObject.SetActive(false);
        }
    }


}