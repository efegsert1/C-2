using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    void Start()
    {
        Application.targetFrameRate = 60;    
    }

    
    void Update()
    {
        //���࿡ ���� ����Ű�� �����ٸ�
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-2, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(2, 0, 0);
        }
    }
}
