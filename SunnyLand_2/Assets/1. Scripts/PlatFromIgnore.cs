using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFromIgnore : MonoBehaviour
{
    //콜라이더 변수
    public Collider2D platformCollider;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Physics2D.IfnoreCollision(콜라이더1 콜라이더2, 무사여부)


            //접촉중일 때는 서로를 무시하고 있어야 플레이어가 아래로 내려갈 수 있으므로 무시여부를 true로 바꿔준다.
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), platformCollider, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //만약 플레이어랑 부딪혔다면
        //무시여부를 false
        if (collision.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), platformCollider, false);
        }
    }
}
