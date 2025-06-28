using UnityEngine;

public class ChangeColorCriCle : MonoBehaviour
{
    SpriteRenderer SR;
    int state = 0;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.color = Color.gray;
    }

    void OnMouseDown()
    {
        state++;

        if (state == 1)
        {
            SR.color = Color.white;
        }

        else if(state == 2)
        {
            SR.color = Color.green;
        }

        else
        {
            SR.color = Color.red;
            state = 0;
        }


    }

    void Update()
    {
        
    }
}
