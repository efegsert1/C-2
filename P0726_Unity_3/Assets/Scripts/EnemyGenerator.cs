using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;  //장애물 프리팹

    float span  = 1.0f;             //장애물이 생성되는 간격

    float delta = 0;                //시간 누적값(타이머 역할)


    void Start()
    {
        
    }


    void Update()
    {
        this.delta += Time.deltaTime;   //매 프레임마다 경과 시간을 누적

        if (this.delta > span) //누적 시간이 생성 간격보다 넘으면
        {
            this.delta = 0; //누적 시간을 초기화(타이머를 리셋)

            //Instantiate 다음 시간에 설명
            GameObject go = Instantiate(enemyPrefab);

            int px = Random.Range(-6, 7); //-6~6사이의 정수 위치값을 랜덤으로 받는다.

            go.transform.position = new Vector3(px, 7, 0);

        }
        
    }
}
