using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Playerchild");
    }

  
    void Update()
    {
        //�� ��ֹ��� -0.1�� y������ ��������
        transform.Translate(0, -0.1f, 0);

        //���࿡ y�� ��ġ�� -5.0�̸� ���ӿ�����Ʈ ����
        if (transform.position.y < -5.0f)
        {
            //���ӿ�����Ʈ�� �����ϴ� ��ɾ�
            //Destroy(gameObject)
            Destroy(gameObject);
        }
        
        //�浹 ����
        Vector2 p1 = transform.position;        //��ֹ���   �߽� ��ǥ

        Vector2 p2 = player.transform.position; //�÷��̾��� �߽� ��ǥ

        //Player ��ġ���� ��ֹ� ��ġ�� ���ϴ� ���� ����
        //��, Player���� ��ֹ������� �Ÿ��� ���� �ǹ�
        //(1,3)
        Vector2 dir = p1 - p2;

        //magnitude : ������ ����(ũ��, �� �Ÿ�)�� ����ϴ� �Ӽ��̴�.
        //�� ������Ʈ(��ֹ��� �÷��̾�) ������ ���� �Ÿ��� �ǹ��Ѵ�.
        float d = dir.magnitude;

        float r1 = 0.5f;
        float r2 = 1.0f;

        //�浹�� �ߴٸ�
        if (d < r1 + r2)
        {
            //�浹�� ��� ��ֹ��� �����.
            Destroy (gameObject);
        }
    }
}
