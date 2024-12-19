using UnityEngine;

public class RePositioning : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        print("Triggered");

        if (!collision.CompareTag("Area"))
        {
            return;
        }

        Vector3 playerPos = WorldManager.instance.player.transform.position;
        Vector3 myPos = transform.position;

       
        float dirX = playerPos.x - myPos.x;
        float dirY = playerPos.y - myPos.y;

        float diffX = Mathf.Abs(dirX);
        float diffY = Mathf.Abs(dirY);

      
        dirX = dirX > 0 ? 1 : -1;
        dirY = dirY > 0 ? 1 : -1;

       
        switch (transform.tag)
        {
            case "Ground":
               
                if (Mathf.Abs(diffX - diffY) <= 0.1f)
                {
                    
                    transform.Translate(Vector3.up * dirY * 40 + Vector3.right * dirX * 40);
                }
                else if (diffX < diffY)
                {
                  
                    transform.Translate(Vector3.up * dirY * 40);
                }
                else if (diffX > diffY)
                {
                   
                    transform.Translate(Vector3.right * dirX * 40);
                }
                break;

            case "Enemy":
                // 여따가 적 지우는 로직 하긴 해야함
                break;
        }
    }
}
