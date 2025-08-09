using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    //������ �ٵ� ���� ����
    Rigidbody2D rig;

    //���ǵ� ���� ����
    public int speed;
    
 
    void Start()
    {
        //rig��� ������ ������ٵ� ������Ʈ �Ҵ��ϱ�
        rig = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //�¿� Ű���� ���� �� ����
        //GetAxisRaw : Ű����, ���̽�ƽ, ���콺�� �Է°��� -1�� 0 1�� �ﰢ ��ȯ�ϴ� �Լ��Դϴ�.
        //GetAxis -1 0.5 0 0.5 1 �ε巴�� ��ȭ�� ��
        float xinput = Input.GetAxisRaw("Horizontal");


        //AddForce ���� ���� ũ��� ������ ��Ÿ����.
        //Mode(����) : ���� ���ϴ� ���
        //ForceMode �� 4����
        //Force : �⺻ ��, ������ Time.deltaTime�� ������ �޾� ������ ����
        //Acceleration : ������ ������� ������ ����
        //Inpulse : ������ ������ ������ �ѹ��� ���������� ���� ����(����, �Ѿ� ����)
        //Velocity : ���� ����, ���������� �ӵ��� ��ȭ(��� �ӵ� ����)
        rig.AddForce(Vector2.right * xinput, ForceMode2D.Impulse);

        //������ ���� �ӵ����� ������
        /*if(rig.velocity.x > speed)
        {
            //���� �ӵ� ����
            rig.velocity.x = new Vector2(speed, rig.velocity.y);
        }

        //���� ���Ѽӵ����� �����ٸ�
        if (rig.velocity.x < speed)
        {
            //���� �ӵ� ����
            rig.velocity.x = new Vector2(speed, rig.velocity.y);
        }*/
    }
}
