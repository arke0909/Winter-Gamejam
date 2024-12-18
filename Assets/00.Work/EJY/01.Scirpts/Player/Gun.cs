using GGMPool;
using System;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour, IPlayerComponent
{
    [SerializeField] private PoolTypeSO _poolType;
    [SerializeField] private PoolManagerSO _poolManager;

    private Player _player;
    private InputReader _inputReader;

    private bool _canFire;

    [field: SerializeField]
    public float ReloadTime { get; private set; } = 2;
    public float CurrentReloadTime { get; private set; } = 0;

    public void Initialize(Player player)
    {
        _player = player;

        _inputReader = _player.GetCompo<InputReader>();

        _inputReader.OnAttackEvent += HandleSAttackEvent;
    }

    private void Update()
    {
        RotateGun();
    }

    private void RotateGun()
    {
        Vector2 mousePos = (Vector3)_inputReader.MousePos - transform.position;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    private void GunFlip()
    {

    }

    private void HandleSAttackEvent()
    {
        if (_canFire)
        {
            Fire();
            Reload();
        }
    }

    private void Fire()
    {

    }

    private void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        _canFire = false;
        yield return new WaitForSeconds(ReloadTime);
        _canFire = true;
    }

    private void OnDisable()
    {
        _inputReader.OnAttackEvent -= HandleSAttackEvent;
    }
}
