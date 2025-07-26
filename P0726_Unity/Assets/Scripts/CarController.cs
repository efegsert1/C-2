using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //차 속도 변수
    float speed = 0;
    Vector2 startPos;
    //Vector는 x와 y를 의미
  
    void Start()
    {
        //Fps 프레임을 60으로 고정한다.
        Application.targetFrameRate = 60;
    }


    void Update()
    {
        //왼쪽 마우스 버튼을 눌렀을때
        if (Input.GetMouseButtonDown(0))
        {
            //this.speed = 0.2f; //처음 속도를 설정한다.
            //마우스 클릭한 좌표
            //Input.mousePosition -> 마우스 커서의 현재 위치를
            //화면에 알려주는 명령어다.
            startPos = Input.mousePosition;
        }

        //왼쪽 마우스 버튼을 땠을때
        else if(Input.GetMouseButtonUp(0))
        {
            //마우스 버튼에서 손가락을 떼었을 때 좌표
            Vector2 endPos = Input.mousePosition;

            //가로 방향 스와이프(밀기)거리를 계산하는 대표적인 예시다.
            //StartPos : 터치나 드래그가 시작된 지점의 좌표
            //endPos : 터치나 드래그가 끝나는 좌표
            float swipeLength = endPos.x - startPos.x;

            //endPos.x - startPos.x; : 오른쪽으로 밀면 값이 양수(오른쪽이동)
            //endPos.x - startPos.x; : 왼쪽으로   밀면 값이 음수(왼쪽이동)

            //스와이프 길이를 처음 속도로 변경한다

            //스와이프 거리(세기)에 비례해서 속도 조정
            //길게/빠르게 밀수록 오브젝트가 빠르게 이동
            //짧게 / 느리게 밀수록 오브젝트가 천천히 이동
            //500.f로 나눈 이유는 너무 큰 값이 되지 않도록 하기 위함.
            this.speed = swipeLength / 500.0f;
        }

        //이동
        transform.Translate(speed , 0,0);

        //서서히 감속
        this.speed *= 0.98f;
    }
}
