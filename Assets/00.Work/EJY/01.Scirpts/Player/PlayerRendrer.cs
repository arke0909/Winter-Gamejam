using UnityEngine;

public class PlayerRendrer : MonoBehaviour, IPlayerComponent
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Player _player;
    private InputReader _inputReader;

    private readonly int _moveHash = Animator.StringToHash("Move");
    private readonly int _hitHash = Animator.StringToHash("Hit");
    private readonly int _idleHash = Animator.StringToHash("PlayerIdle");
    private readonly int _deadHash = Animator.StringToHash("PlayerDead");

    public void Initialize(Player player)
    {
        _player = player;
        _inputReader = _player.GetCompo<InputReader>();
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerFlip();

        _animator.SetBool(_moveHash, _inputReader.InputDir.magnitude > 0);
    }

    private void PlayerFlip()
    {
        _spriteRenderer.flipX = _inputReader.MousePos.x < transform.position;
    }

    public void Hit()
    {
        _animator.SetTrigger(_hitHash);
    }

    public void Dead()
    {
        _animator.Play(_deadHash);
    }

    public void AnimationEnd()
    {
        _animator.Play(_idleHash);
    }
}
