using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFromIgnore : MonoBehaviour
{
    //�ݶ��̴� ����
    public Collider2D platformCollider;

    //�ݶ��̴� ������ ������
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Physics2D.IgnoreCollision(�ݶ��̴�1, �ݶ��̴�2, ���ÿ���)
            //�������� ���� ���θ� �����ϰ� �־�� �÷��̾ �Ʒ��� ������ �� �����Ƿ�  ���ÿ��θ�  true�� �ٲ��ش�.  
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), platformCollider, true);
        }
    }

    //�ݶ��̴� ���� ���̶��
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
