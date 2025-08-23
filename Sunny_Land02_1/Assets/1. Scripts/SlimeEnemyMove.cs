using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemyMove : MonoBehaviour
{
    //������ٵ� ���� ���� rig
    Rigidbody2D rig;

    SpriteRenderer sr;
    Animator anim;

    //���� �̵��� ����(�������̰�, �������� dir)
    int dir;

    //���� ���� ����
    bool isChange;

    //�������� ���� ��ġ ����
    Vector3 rayPos;

    void Start()
    {
        //rig������ ������ٵ�2D �Ҵ��ϱ�
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        RandomDir();
    }

    void Update()
    {
        //������ �������� �̵�(velocity ���� ������)
        rig.velocity = new Vector2(dir, rig.velocity.y);

        //������ �׸���
        //Unity�� ����׿� ������(��) �׸��� �Լ�_����ȭ�鿡���� ������ ����
        //Debug.DrawRay(���� ������, ��� �������� �󸶳� �׸���
        Debug.DrawRay(transform.position + rayPos, Vector2.down * 1);

        //�������� ���� ��ü ���� = ����ĳ��Ʈ
        //RaycastHit2D : �������� ���� ������Ʈ�� ���� ������ ��� ����
        //Physics2D.Raycast(���� ��ġ, �������� ���ư��� ����, ������ ����(��ŭ ����))
        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayPos, Vector2.down, 1);

        //���̿� ���� ��ü�� ���ٸ�
        if(!hit)
        {
            //���� �ٲٱ�
            ChangeDir();
        }

        //���̿� ��ü�� �¾Ҵٸ�
        else
        {
            //���࿡ ���� ��ü�� �ٴ��� �ƴ϶��
            if (hit.collider.gameObject.tag == "Floor")
            {
                //���� �ٲٱ�
                ChangeDir();
            }

            //���� ���� �ٴ��̶��
            else
            {
                isChange = false;
            }
        }

        rayPos = new Vector3(0.7f, 0, 0);

        switch(dir)
        {
            //�����ִٸ�
            case 0:
                anim.SetBool("isWalk", false);
                break;
            //�������� ���ٸ�
            case -1:
                anim.SetBool("isWalk", true);
                sr.flipX = false;
                rayPos = new Vector3(-0.7f, 0, 0);
                break;
            //���������� ���ٸ�
            case 1:
                anim.SetBool("isWalk", true);
                sr.flipX = true;
                rayPos = new Vector3(0.7f, 0, 0);
                break;
        }
    }

    void RandomDir()
    {
        //���Ⱚ -1,0,1
        //Random.Range(�ּڰ�, �ִ밪) : ���� �Լ� * �ִ밪�� ������ ���� �ʱ� ������ +1�� �ؼ� ���
        //1~10
        //Random.Range(1, 11);
        dir = Random.Range(-1, 2);


        //Invoke : �ڽ��� ������ �ð� ��ŭ �Լ� ���� �ð��� ������Ű�� ���
        //Invoke("�޼����", ������Ű�� ���� �ð�)
        Invoke("RandomDir", Random.Range(2f, 3f));
    }

    void ChangeDir()
    {
        if(!isChange)
        {
            //���� �ٲٱ�
            dir *= -1;

            //������ �ٲ����� ����
            isChange = true;

            //�κ�ũ ��� ���
            CancelInvoke();

            //���� �ֱ�� �ݺ�
            Invoke("RandomDir", Random.Range(2f, 3f));
        }
    }
}
