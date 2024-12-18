using UnityEngine;

public class RePositioning : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (!collision.CompareTag("Area"))
        {
            return;
        }

      
        Vector3 playerPos = WorldManager.instance.player.transform.position;
        Vector3 myPos = transform.position;

      
        float diffX = playerPos.x - myPos.x;
        float diffY = playerPos.y - myPos.y;

        
        if (Mathf.Abs(diffX) > Mathf.Abs(diffY))
        {
           
            float dirX = diffX > 0 ? 1 : -1; 
            transform.Translate(Vector3.right * dirX * 40);
        }
        else
        {
           
            float dirY = diffY > 0 ? 1 : -1; 
            transform.Translate(Vector3.up * dirY * 40);
        }
    }
}
