using UnityEngine;
using UnityEngine.InputSystem;

//Rigidbody2D가 반드시 있어야 하므로 자동으로 추가
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerCtrl : MonoBehaviour
{
    private Rigidbody2D rig;
    private float inputValue; //-1(왼쪽) 0 1(오른쪽 ) 일력 값 저장

    public float Speed;
    //Start()보다 먼저 호출
    //스크립트가 활성화 될 떄 한 번만 실행됨

    //주요 용도 : 게임 시작 전에 컴포넌트 가져오기 위함
    //초기화가 다른스크립트보다 먼저 필요할 떄
    //데이터로드, 싱글톤 생성등 시작 준비 작업
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    //유니티 물리 프레임 타이밍 마다 호출됨
    //기본적으로 1초에 50번(0.025초 간격)실행 - Time.fixedDeltaTime에 따라 다름.
    //update() 와 달리 프레임 속도에 영향을 받지 않는다.

    //주요 용도
    //물리 연산을 할 때
    //속도, 충돌, 힘, 회전같은 물리 관련 코드
    private void FixedUpdate()
    {
        rig.linearVelocityX = inputValue * Speed;
    }

    void OnMove(InputValue value)
    {
        //입력된 Vector2에서 X값만 추출
        inputValue = value.Get<Vector2>().x;
    }
}
