using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    //��ٸ� ���� ����
    public bool isLadder;

    //�ö󰡴� �� ����
    public float maxSpeed;

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

    private void FixedUpdate()
    {
        //��ٸ��� Ÿ���ִ� ���
        if(isLadder)
        {
            //��, �Ʒ��� Ű���尪 ����
            float ver = Input.GetAxisRaw("Vertical");

            //��ٸ��ϱ� �߷��� ������ �ȵǱ� ������ �߷��� 0���� ����
            rig.gravityScale = 0;

            //�ö󰡴� ��
            rig.velocity = new Vector2(rig.velocity.x, ver * maxSpeed);

            //�� �Ʒ��� �����̰� �ִٸ�
            if (ver != 0)
            {
                //�ö󰡴� �ִϸ��̼� Ȱ��ȭ
                anim.SetBool("isClimb", true);
            }
        }

        //��ٸ��� Ÿ�� ���� �ʴٸ�
        else
        {
            //�ٽ� �߷°� ���� 3
            rig.gravityScale = 3f;
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //��ٸ� �浹 ������ ���Դٸ�
        if (collision.CompareTag("Ladder"))
        {
            //isLadder�� true�� ����
            isLadder = true;
        }
    }

    //�浹 �������� ���.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            anim.SetBool("isClimb", false);
        }
    }   


}
