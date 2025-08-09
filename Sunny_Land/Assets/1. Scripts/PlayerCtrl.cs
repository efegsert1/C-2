using UnityEngine;
using UnityEngine.InputSystem;

//Rigidbody2D�� �ݵ�� �־�� �ϹǷ� �ڵ����� �߰�
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerCtrl : MonoBehaviour
{
    private Rigidbody2D rig;
    private float inputValue; //-1(����) 0 1(������ ) �Ϸ� �� ����

    public float Speed;
    //Start()���� ���� ȣ��
    //��ũ��Ʈ�� Ȱ��ȭ �� �� �� ���� �����

    //�ֿ� �뵵 : ���� ���� ���� ������Ʈ �������� ����
    //�ʱ�ȭ�� �ٸ���ũ��Ʈ���� ���� �ʿ��� ��
    //�����ͷε�, �̱��� ������ ���� �غ� �۾�
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

    //����Ƽ ���� ������ Ÿ�̹� ���� ȣ���
    //�⺻������ 1�ʿ� 50��(0.025�� ����)���� - Time.fixedDeltaTime�� ���� �ٸ�.
    //update() �� �޸� ������ �ӵ��� ������ ���� �ʴ´�.

    //�ֿ� �뵵
    //���� ������ �� ��
    //�ӵ�, �浹, ��, ȸ������ ���� ���� �ڵ�
    private void FixedUpdate()
    {
        rig.linearVelocityX = inputValue * Speed;
    }

    void OnMove(InputValue value)
    {
        //�Էµ� Vector2���� X���� ����
        inputValue = value.Get<Vector2>().x;
    }
}
