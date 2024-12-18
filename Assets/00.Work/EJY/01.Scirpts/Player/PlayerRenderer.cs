using System;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour, IPlayerComponent
{
    private SpriteRenderer _spriteRenderer;
    private Player _player;
    private InputReader _inputReader;

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerSpriteFlip();
    }

    private void PlayerSpriteFlip()
    {
        _spriteRenderer.flipX = _inputReader.MousePos.x > _player.transform.position.x;
    }
}
