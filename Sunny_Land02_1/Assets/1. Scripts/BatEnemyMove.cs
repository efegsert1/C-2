using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class BatEnemyMove : MonoBehaviour
{
    //�̵� �ӵ� ���� ����
    public float speed;

    //���Ϸ� �̵��� �Ÿ� ���� ����
    public float distance;

    //�̵� ����
    int direction = 1;

    //�ʱ� ��ġ ����
    //Vector2�� ��ġ ����
    Vector2 originalPosition;

    //�� ������ ����
    bool isDead;

    //��������Ʈ ������ ���� ����
    SpriteRenderer sr;

    //���������� �ӵ�
    float colorSpeed = 5f;


    void Start()
    {
        //�ʱ� ��ġ�� ���� ��ġ(transform.position)�� ����
        originalPosition = transform.position;

        //sr������ ��������Ʈ������ �Ҵ��ϱ�
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        //���࿡ ���� ���� �ʾҴٸ�
        if (!isDead)
        {
            //�� ������
            EnemyMove();
        }

        //���� �׾��ٸ�
        else
        {
            //������ ������ ������
            //Vector4(R,G,B,A) A=0�̶�°� ���������� �ǹ��Ѵ�.
            //Lerp : �����Լ�(A���� B�� õõ��(������) ��������)
            //���� ���� �� �� ���̿��� ���ϴ� ������ŭ�� ���� ������ִ� �Լ���.
            sr.color = Vector4.Lerp(sr.color, new Vector4(1, 1, 1, 0), Time.deltaTime * colorSpeed);

            //���� ���������ٸ�
            if(sr.color.a <= 0.5f)
            {
                //���ӿ�����Ʈ ����
                Destroy(gameObject);
            }
        }
    }

    void EnemyMove()
    {
        //���㸦 �� �Ʒ��� �̵�
        //Vector2(x, y)
        Vector2 targetPosition = originalPosition + new Vector2(0, distance * direction);

        //Vector3.MoveTowards(������ġ, ��ǥ��ġ, �ӵ�)
        //Ư�� ������Ʈ�� ��ǥ�������� �̵��� �� �ְ� ���ִ� �Լ��̴�.
        //Time.deltaTime) : ������ �ӵ��� ������� ������ �ӵ��� �����̱� ���ؼ� ����Ѵ�.
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        //Vector2.Distance(a,b) - > a�� b������ ���� �Ÿ��� ��ȯ�Ѵ�,
        if (Vector2.Distance(transform.position, targetPosition) < 0.01f)
        {
            //�̵� ������ ����
            direction *= -1;
        }
    }

    //Dead�Լ� ����
    public void Dead()
    {
        //�׾����� ����
        isDead = true;
    }
}
