using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFromIgnore : MonoBehaviour
{
    //�ݶ��̴� ����
    public Collider2D platformCollider;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Physics2D.IfnoreCollision(�ݶ��̴�1 �ݶ��̴�2, ���翩��)


            //�������� ���� ���θ� �����ϰ� �־�� �÷��̾ �Ʒ��� ������ �� �����Ƿ� ���ÿ��θ� true�� �ٲ��ش�.
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), platformCollider, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //���� �÷��̾�� �ε����ٸ�
        //���ÿ��θ� false
        if (collision.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), platformCollider, false);
        }
    }
}
