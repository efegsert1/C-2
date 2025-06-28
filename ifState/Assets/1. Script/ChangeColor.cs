using Unity.VisualScripting;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    //색상을 바꿀 수 있는 곳을 변수로 선언
    private SpriteRenderer sr;

    //변수 선언
    private int state = 0;

    //플레이 버튼을 눌렀을 때 딱 한번만 실행이 되는 곳
    void Start()
    {
        //색상을 바꿀 수 있는 곳을 sr변수에 저장
        sr = GetComponent<SpriteRenderer>();

        //시작할 때는 빨강
        sr.color = Color.cyan;
    }

    void OnMouseDown()
    {
        //클릭하면 위로 1칸씩 이동하기
        for(int i = 0; i < 1;  i++)
        {
            transform.position += new Vector3(0.1f, 0, 0);
        }
        /*
        //클릭 할 떄마다 1씩 증가
        state++; //state = state + 1

        if (state == 1)
        {
            sr.color = Color.green;
        }

        //만약(if문 말고 다른 if문) state 값이 2라면, 오브젝트 색깔을 파란색으로 바꾸시오
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

    //매초마다 실행이 되는 곳
    void Update()
    {
        
    }
}
