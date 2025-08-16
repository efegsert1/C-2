using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UI�� ����Ѵٰ� �������ֱ�

public class PlayerCollider : MonoBehaviour
{
    //���ھ��ؽ�Ʈ ����
    //public : �ν����Ϳ��ٰ� �� ���� ������Ʈ�� �巡���ؼ� �־���� �Ѵ�.
    public Text txt;

    //���ھ� ���� ���� ����
    public int score;

    void Start()
    {
        //���ھ� ���� �ʱ�ȭ
        score = 0;
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
            Debug.Log("�浹 �Ϸ�" +  collision.gameObject.tag);

            //���ӿ�����Ʈ �����ϱ�
            Destroy(collision.gameObject);

            //���ھ� ���� 1�� ����
            score += 1;

            //ToString() : ������ ������ ���ڿ��� ��ȯ
            //��� ���[����] : ���� �̸�.ToString
            //����� score�� int�����Դϴ�.
            //int->Stirng���� �ٲٴ� �۾�
            txt.text = score.ToString();
        }
    }
}
