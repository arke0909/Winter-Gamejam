using System.Collections.Generic;
using UnityEngine;

public class RePositioning : MonoBehaviour
{
    private List<Spawner> _spawns = new List<Spawner>();
    [SerializeField] private Vector2 _size;
    [SerializeField] private Vector2 _position;
    [SerializeField] private LayerMask spawnerLayer;

    private bool _isGameing;

    private void Awake()
    {
        _isGameing = true;

        var colliders = Physics2D.OverlapBoxAll(_position, _size, 0,spawnerLayer);
        foreach (var collider in colliders)
        {
            if(collider.GetComponent<Spawner>() != null)
                _spawns.Add(collider.GetComponent<Spawner>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!_isGameing) return;

        if (!collision.CompareTag("Area"))
        {
            return;
        }

        Vector3 playerPos = GameManager.Instance.Player.transform.position;
        Vector3 myPos = transform.position;

        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.Instance.Player.InputCompo.InputDir;

        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                //if (Mathf.Abs(diffX - diffY) <= 0.1f) // X�� Y�� ���̰� ���� ������
                //{
                //    // X�� Y ���� ��� �� ���� �̵�
                //    transform.Translate(Vector3.up * dirY * 40);
                //    transform.Translate(Vector3.right * dirX * 40);
                //}
                //else
               // Debug.Log("X" + diffX + " y" + diffY);
                if (diffX > diffY) // X�� �̵��� �� ũ��
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (diffX < diffY) // Y�� �̵��� �� ũ��
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;

            case "Enemy":
                // ���⼭ �� ���� ������ �߰��Ͻʽÿ�
                foreach (Spawner spawner in _spawns)
                {
                    spawner.SetSpawnerPoint();
                }
                break;
        }
    }

    private void OnApplicationQuit()
    {
        _isGameing = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_position, _size);
    }
}
