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
        //���࿡ �浹�� ���ӿ�����Ʈ �±װ� "Enemey"���
        //Debug.Log("���);
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("���");

            //�Ѿ��� ���㿡 �¾Ҵ��� ��������
            //Dead�Լ� ȣ��
            //SendMessage() -> ���ӿ�����Ʈ�� ����� ������Ʈ�鿡 Ư�� �Լ�(�޼���) ȣ���� �� �ֵ��� ����
            //�ٸ� Ŭ������ �ִ� �Լ��� ȣ���� �� ����
            collision.SendMessage("Dead");

            //���ӿ�����Ʈ ��Ȱ��ȭ
            gameObject.SetActive(false);
        }
    }


}