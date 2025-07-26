using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //�� �ӵ� ����
    float speed = 0;
    Vector2 startPos;
    //Vector�� x�� y�� �ǹ�
  
    void Start()
    {
        //Fps �������� 60���� �����Ѵ�.
        Application.targetFrameRate = 60;
    }


    void Update()
    {
        //���� ���콺 ��ư�� ��������
        if (Input.GetMouseButtonDown(0))
        {
            //this.speed = 0.2f; //ó�� �ӵ��� �����Ѵ�.
            //���콺 Ŭ���� ��ǥ
            //Input.mousePosition -> ���콺 Ŀ���� ���� ��ġ��
            //ȭ�鿡 �˷��ִ� ��ɾ��.
            startPos = Input.mousePosition;
        }

        //���� ���콺 ��ư�� ������
        else if(Input.GetMouseButtonUp(0))
        {
            //���콺 ��ư���� �հ����� ������ �� ��ǥ
            Vector2 endPos = Input.mousePosition;

            //���� ���� ��������(�б�)�Ÿ��� ����ϴ� ��ǥ���� ���ô�.
            //StartPos : ��ġ�� �巡�װ� ���۵� ������ ��ǥ
            //endPos : ��ġ�� �巡�װ� ������ ��ǥ
            float swipeLength = endPos.x - startPos.x;

            //endPos.x - startPos.x; : ���������� �и� ���� ���(�������̵�)
            //endPos.x - startPos.x; : ��������   �и� ���� ����(�����̵�)

            //�������� ���̸� ó�� �ӵ��� �����Ѵ�

            //�������� �Ÿ�(����)�� ����ؼ� �ӵ� ����
            //���/������ �м��� ������Ʈ�� ������ �̵�
            //ª�� / ������ �м��� ������Ʈ�� õõ�� �̵�
            //500.f�� ���� ������ �ʹ� ū ���� ���� �ʵ��� �ϱ� ����.
            this.speed = swipeLength / 500.0f;
        }

        //�̵�
        transform.Translate(speed , 0,0);

        //������ ����
        this.speed *= 0.98f;
    }
}
