using Unity.VisualScripting;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    //������ �ٲ� �� �ִ� ���� ������ ����
    private SpriteRenderer sr;

    //���� ����
    private int state = 0;

    //�÷��� ��ư�� ������ �� �� �ѹ��� ������ �Ǵ� ��
    void Start()
    {
        //������ �ٲ� �� �ִ� ���� sr������ ����
        sr = GetComponent<SpriteRenderer>();

        //������ ���� ����
        sr.color = Color.cyan;
    }

    void OnMouseDown()
    {
        //Ŭ���ϸ� ���� 1ĭ�� �̵��ϱ�
        for(int i = 0; i < 1;  i++)
        {
            transform.position += new Vector3(0.1f, 0, 0);
        }
        /*
        //Ŭ�� �� ������ 1�� ����
        state++; //state = state + 1

        if (state == 1)
        {
            sr.color = Color.green;
        }

        //����(if�� ���� �ٸ� if��) state ���� 2���, ������Ʈ ������ �Ķ������� �ٲٽÿ�
        else if (state == 2)
        {
            sr.color = Color.blue;
        }

        else if (state == 3)
        {
            sr.color = Color.black;
        }

        else if (state == 4)
        {
            sr.color = Color.yellow;
        }

        else
        {
            sr.color= Color.red;
            state = 0;
        }*/
    }

    //���ʸ��� ������ �Ǵ� ��
    void Update()
    {
        
    }
}
