using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;  //��ֹ� ������

    float span  = 1.0f;             //��ֹ��� �����Ǵ� ����

    float delta = 0;                //�ð� ������(Ÿ�̸� ����)


    void Start()
    {
        
    }


    void Update()
    {
        this.delta += Time.deltaTime;   //�� �����Ӹ��� ��� �ð��� ����

        if (this.delta > span) //���� �ð��� ���� ���ݺ��� ������
        {
            this.delta = 0; //���� �ð��� �ʱ�ȭ(Ÿ�̸Ӹ� ����)

            //Instantiate ���� �ð��� ����
            GameObject go = Instantiate(enemyPrefab);

            int px = Random.Range(-6, 7); //-6~6������ ���� ��ġ���� �������� �޴´�.

            go.transform.position = new Vector3(px, 7, 0);

        }
        
    }
}
