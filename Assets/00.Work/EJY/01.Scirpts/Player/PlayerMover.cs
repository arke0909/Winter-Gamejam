using UnityEngine;

public class PlayerMover : MonoBehaviour, IPlayerComponent
{
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody2D _rigidCompo;
    private Player _player;


    public void Initialize(Player player)
    {
        _player = player;
    }

    private void Awake()
    {
        _rigidCompo = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(Vector2 moveDir)
    {
        _rigidCompo.linearVelocity = moveDir * _moveSpeed;
    }
}
