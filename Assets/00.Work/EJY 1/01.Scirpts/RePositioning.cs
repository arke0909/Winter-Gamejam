using System.Collections.Generic;
using UnityEngine;

public class RePositioning : MonoBehaviour
{
    private List<Spawner> _spawns = new List<Spawner>();
    [SerializeField] private Vector2 _size;
    [SerializeField] private Vector2 _position;
    [SerializeField] private LayerMask spawnerLayer;
    private void Awake()
    {
        var colliders = Physics2D.OverlapBoxAll(_position, _size, 0,spawnerLayer);
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

        Vector3 playerPos = WorldManager.instance.player.transform.position; // => �̰� ��ǲ���ͷ� �ٲ㺼�� �ֳ� 
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        // Vector3 playerDir = GameManager.instance.player.inputVec;   // ���;���
        Vector3 playerDir = WorldManager.instance.player.transform.position;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {    //X�� �̵���
                    transform.Translate(Vector3.right * dirX * 40); //X������ 2ĭ �̵�
                }
                else if (diffX < diffY)
                {   //Y�� �̵���
                    transform.Translate(Vector3.up * dirY * 40);    //Y������ 2ĭ �̵�
                }
                break;
            case "Enemy":

                break;

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_position, _size);
    }
}
