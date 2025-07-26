using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GaneDirector : MonoBehaviour
{
    GameObject Car;         //car   게임오브젝트
    GameObject Flag;        //flag  게임오브젝트
    GameObject Distance;    //거리      오브젝트
  
    void Start()
    {
        //Find : Hierarchy창에서 "Car"라는 게임오브젝트를 찾겠다
        Car = GameObject.Find("Car");
        Flag = GameObject.Find("Flag");
        Distance = GameObject.Find("Distance");
    }

    
    void Update()
    {
        //깃발과 차의 가로위치(x좌표) 차이를 구하는데 사용하는 코드
        float length = Flag.transform.position.x - Car.transform.position.y;

        //UI텍스트에 거리 정보를 표시하는 코드다.
        //length.ToString("F2") : length의 값을 소수 둘째자리까지 문자열로 변환 
        Distance.GetComponent<Text>().text = "Distance : " + length.ToString("F2") + "m";
    }
}
