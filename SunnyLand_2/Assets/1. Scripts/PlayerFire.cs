using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //�Ѿ� �߻��ϴ� ��
    public float bulletPower;

    //�Ѿ��� �߻��ϴ� ���� ����
    int dir;

    //�Ѿ� ������Ʈ �迭 ���
    //�Ѿ� 5���� �迭�� �ִ´�.
    GameObject[] bulletPool = new GameObject[5];

    //�÷��̾�� ��ũ��Ʈ�� ������ ����
    PlayerMove playerMove;


    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        //źâ�� �� �Ѿ� ������ŭ �ݺ�
        for(int i = 0; i < bulletPool.Length; i++)
        {
            //�Ѿ� �����ؼ� ����
            //�������� �����ؼ� ���� �ʹ�(Instantiate)
            //Bullet -> Resources������ �ִ� �����ո�� �Ȱ��ƾ� �Ѵ�.
            GameObject bullet = Instantiate(Resources.Load("Bullet")) as GameObject;

            //�Ѿ� ������Ʈ�� Ǯ�� �ֱ�
            //for (i = 0)
            //bulletPool[i] = bullet
            bulletPool[i] = bullet;

            //�Ѿ� ��Ȱ��ȭ
            bulletPool[i].SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //�Ѿ� ���� ��ŭ �ݺ�
            for(int i = 0;i < bulletPool.Length; i++)
            {
                //1��° �Ѿ� ����
                GameObject bullet = bulletPool[i];

                //���� ���� �ʴ� �Ѿ˸� ��Ȱ��ȭ
                //activeSelf : �ڽſ��� ������ Ȱ��ȭ ���¸� ��Ÿ���� �Ӽ�(bool)
                if (!bullet.activeSelf)
                {
                    bullet.SetActive(true);

                    //�Ѿ� ���� ��ġ ����
                    bullet.transform.position = transform.position + new Vector3(0.5f, -0.5f, 0);

                    //�Ѿ˿� �� ���ϱ�
                    bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * bulletPower, ForceMode2D.Impulse);

                    //1�� �Ŀ� ������ �� �ֵ���
                    //�ڷ�ƾ �Լ��� �����Ű�� ���ؼ��� StartCoroutine�� ���
                    //StartCoroutine(�ڷ�ƾ�Լ���) : �Ű������� ���� �ÿ�
                    //StartCoroutine(�ڷ�ƾ�Լ���(�Ű�����)) : �Ű������� ���� ��
                    StartCoroutine(ResetBullet(bullet));

                    break;
                }
            }
        }
    }

    //�ڷ�ƾ �Լ� : ����
    //�� �Լ��� ������ �߰��� ��� ����ٰ�, ���� �����Ӻ��� �̾ ������ �� �ְ� ���ִ� �帧�����.
    IEnumerator ResetBullet(GameObject bullet)
    {
        //1�� �ڿ� ����(���)
        yield return new WaitForSeconds(1);

        //�߻�� �Ѿ� ��Ȱ��ȭ
        bullet.SetActive(false);
    }
}
