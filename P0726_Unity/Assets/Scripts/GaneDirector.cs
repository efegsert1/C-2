using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GaneDirector : MonoBehaviour
{
    GameObject Car;         //car   ���ӿ�����Ʈ
    GameObject Flag;        //flag  ���ӿ�����Ʈ
    GameObject Distance;    //�Ÿ�      ������Ʈ
  
    void Start()
    {
        //Find : Hierarchyâ���� "Car"��� ���ӿ�����Ʈ�� ã�ڴ�
        Car = GameObject.Find("Car");
        Flag = GameObject.Find("Flag");
        Distance = GameObject.Find("Distance");
    }

    
    void Update()
    {
        //��߰� ���� ������ġ(x��ǥ) ���̸� ���ϴµ� ����ϴ� �ڵ�
        float length = Flag.transform.position.x - Car.transform.position.y;

        //UI�ؽ�Ʈ�� �Ÿ� ������ ǥ���ϴ� �ڵ��.
        //length.ToString("F2") : length�� ���� �Ҽ� ��°�ڸ����� ���ڿ��� ��ȯ 
        Distance.GetComponent<Text>().text = "Distance : " + length.ToString("F2") + "m";
    }
}
