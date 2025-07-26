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
        //이 장애물이 -0.1씩 y축으로 떨어지게
        transform.Translate(0, -0.1f, 0);

        //만약에 y축 위치가 -5.0이면 게임오브젝트 삭제
        if (transform.position.y < -5.0f)
        {
            //게임오브젝트를 삭제하는 명령어
            //Destroy(gameObject)
            Destroy(gameObject);
        }
        
        //충돌 판정
        Vector2 p1 = transform.position;        //장애물의   중심 좌표

        Vector2 p2 = player.transform.position; //플레이어의 중심 좌표

        //Player 위치에서 장애물 위치로 향하는 방향 백터
        //즉, Player에서 장애물까지의 거리와 방향 의미
        //(1,3)
        Vector2 dir = p1 - p2;

        //magnitude : 백터의 길이(크기, 즉 거리)를 계산하는 속성이다.
        //두 오브젝트(장애물과 플레이어) 사이의 실제 거리를 의미한다.
        float d = dir.magnitude;

        float r1 = 0.5f;
        float r2 = 1.0f;

        //충돌을 했다면
        if (d < r1 + r2)
        {
            //충돌한 경우 장애물을 지운다.
            Destroy (gameObject);
        }
    }
}
