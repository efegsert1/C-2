using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    void Start()
    {
        Application.targetFrameRate = 60;    
    }

    
    void Update()
    {
        //만약에 왼쪽 방향키를 눌렀다면
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
