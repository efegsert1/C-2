using UnityEngine;

public class HeroMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector2 = new Vector2(0, 0);

        if (Input.GetKeyDown(KeyCode.D))
        {
            vector2.x = -1f;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            vector2.y = 1f;
        }
    }
}
