using System;
using UnityEngine;

public class Gun : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    private InputReader _inputReader;

    public void Initialize(Player player)
    {
        _player = player;

        _inputReader = _player.GetCompo<InputReader>();

        _inputReader.OnAttackEvent += HandleSAttackEvent;
    }

    private void HandleSAttackEvent()
    {

    }

    private void OnDisable()
    {
        _inputReader.OnAttackEvent -= HandleSAttackEvent;
    }
}
