using UnityEngine;

public class 
    Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody2D _rigidCompo;

    private void Awake()
    {
        _rigidCompo = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(Vector2 moveDir)
    {
        _rigidCompo.linearVelocity = moveDir * _moveSpeed;
    }
}
