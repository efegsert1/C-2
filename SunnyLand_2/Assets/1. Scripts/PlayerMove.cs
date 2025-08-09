using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMove : MonoBehaviour
{
    //������ �ٵ� ���� ����
    Rigidbody2D rig;

    //���ǵ� ���� ����
    public int speed;

    //��Ʈ����Ʈ ������ ���� ����
    SpriteRenderer sr;

    //�ִϸ����� ���� ����
    Animator anim;

    //�����ϴ� ��(�Ϲݺ���, ������Ʈ�� �ƴ�)
    public int jumpPower;

    //�Ϲ� ���� : ���� ī��Ʈ
    int jumpcount;

    void Start()
    {
        //rig��� ������ ������ٵ� ������Ʈ �Ҵ��ϱ�
        rig = GetComponent<Rigidbody2D>();

        //sr��� ������ ��������Ʈ������ ������Ʈ �Ҵ��ϱ�
        sr = GetComponent<SpriteRenderer>();

        //anim��� ������ �ִϸ����� ������Ʈ �Ҵ��ϱ�
        anim = GetComponent<Animator>();
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
        if (rig.velocity.x > speed)
        {
            //���� �ӵ� ����
            rig.velocity = new Vector2(speed, rig.velocity.y);
        }

        //����(-1) ���Ѽӵ����� �����ٸ�
        if (rig.velocity.x < -speed)
        {
            //���� �ӵ� ����
            rig.velocity = new Vector2(-speed, rig.velocity.y);
        }

        //�¿� ����Ű�� ����
        if (Input.GetButtonUp("Horizontal"))
        {
            //�ӵ� 0���� ���߱� x = 0, y = rig.velocity.y
            //ĳ������ �ӵ� =
            rig.velocity = new Vector2(0, rig.velocity.y);

            anim.SetBool("isWalk", false);
        }

        //�¿� ����(�����̰� �ִٸ�
        if (xinput != 0)
        {
            //Horizontal�� �����̶�� �����ϱ�
            sr.flipX = Input.GetAxisRaw("Horizontal") == -1;

            //�ȴ� �ִϸ��̼��� ����
            //SetBool : �Ķ���͸� Bool�� ������� ������
            //SetBool("�ִϸ����Ϳ��� �������� ������", true/ false); *������ ��ų�Ÿ� true, �ƴϸ� false
            anim.SetBool("isWalk", true);
        }

        //�Լ� ȣ�� : Jump�� �ִ� ������ ��� ���� �ȴ�.
        Jump();

    }
    //�����ϴ� �Լ� �����
    void Jump()
    {
        //�����̽��ٸ� ������, jumpCount�� 2 ���϶�� (0,1)
        if (Input.GetButtonDown("Jump") && jumpcount < 2)
        {
            //���� ī��Ʈ ����
            jumpcount++;    //jumpCount = jumpCount + 1

            //���� �����ϱ�
            //Vector2.up = (0, 1)
            rig.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            
            //�����ϴ� �ִϸ��̼� ����
            anim.SetBool("isJump", true);
        }
    }

    //�浹 �Լ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Floor�� �浹�� �ߴٸ�
        //()
        if(collision.gameObject.tag == "Floor")
        {
            //����ī��Ʈ �ʱ�ȭ
           jumpcount = 0;

            //���� �ִϸ��̼� ����
            anim.SetBool("isJump", false);

        }
    }


}
