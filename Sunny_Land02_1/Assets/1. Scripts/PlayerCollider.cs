using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;   //UI�� ����Ѵٰ� �������ֱ�

public class PlayerCollider : MonoBehaviour
{
    //���ھ��ؽ�Ʈ ����
    //public : �ν����Ϳ��ٰ� �� ���� ������Ʈ�� �巡���ؼ� �־���� �Ѵ�.
    public Text txt;

    //���ھ� ���� ���� ����
    public int score;

    //��� ���� ����
    int life;

    //���� Ƚ�� ��� 
    public Text countText;
 
    void Start()
    {
        //���ھ� ���� �ʱ�ȭ
        score = 0;

        //����� �ʱ�ȭ
        //��������� 3 �Ҵ��ϱ�
        life = 3;
    }

 
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���� "Item"�̶�� �±׸� ���� ���ӿ�����Ʈ�� �ε����ٸ�
        //collision.CompareTag("Item")
        if (collision.gameObject.tag == "Item")
        {
            //�ε��� ���ӿ�����Ʈ tag ���
            Debug.Log("�浹 �Ϸ�" + collision.gameObject.tag);

            //���ӿ�����Ʈ �����ϱ�
            Destroy(collision.gameObject);

            //���ھ� ���� 1�� ����
            score += 1;


            //ToString() : ������ ������ ���忭�� ��ȯ
            //��� ���[����] : ���� �̸�.ToString
            //����� score�� int�����Դϴ�.
            //int->String���� �ٲٴ� �۾�
            txt.text = score.ToString();
        }
        
        //���࿡ Enemy�±׸� ���� ������Ʈ�� �浹�ߴٸ�
        if (collision.gameObject.tag == "Enemy")
        {
            //��� ����
            life--;

            //��� ui ���
            countText.text = life.ToString();
            LifeCheck();
        }
    }

    public void LifeCheck()
    {
        //����� 0�� �Ǹ�
        if(life <= 0)
        {
            //���� ���߱�
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //���࿡ underFloor�±׸� ���� ������Ʈ�� �浹�� �ߴٸ�
        if (collision.gameObject.tag == "underFloor")
        {
            //��� ����
            life--;
            life--;
            life--;

            //��� ui ���
            countText.text = life.ToString();
            LifeCheck();
        }
    }
}

