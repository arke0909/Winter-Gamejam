using System.Collections.Generic;
using UnityEngine;

public class RePositioning : MonoBehaviour
{
    private List<Spawner> _spawns;
    [SerializeField] private Vector2 _size;
    [SerializeField] private Vector2 _position;
    private void Awake()
    {
        var colliders = Physics2D.OverlapBoxAll(_position, _size, 0);
        foreach (var collider in colliders)
        {
            if(collider.GetComponent<Spawner>() != null)
                _spawns.Add(collider.GetComponent<Spawner>());
        }
    }
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
                foreach(Spawner spawner in _spawns)
                {
                    spawner.SetSpawnerPoint();
                }
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_position, _size);
    }
}
