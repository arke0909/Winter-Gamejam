using GGMPool;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _firePos;

    [SerializeField] private PoolManagerSO poolManager;
    [SerializeField] private PoolTypeSO poolType;

    [field: SerializeField] public InputReader InputCompo { get; private set; }

    private Dictionary<Type, IPlayerComponent> _components;
    private PlayerMover _playerMover;

    public bool IsShot { get; private set; } = false;

    private void Awake()
    {
        _components = new Dictionary<Type, IPlayerComponent>();
        _playerMover = GetComponentInChildren<PlayerMover>();

        InputCompo.OnAttackEvent += Fire;

        SetComponent();
    }

    private void FixedUpdate()
    {
        _playerMover.SetVelocity(InputCompo.InputDir);
    }

    private void SetComponent()
    {
        GetComponentsInChildren<IPlayerComponent>().ToList().ForEach(component => { _components.Add(component.GetType(), component); });

        _components.Add(InputCompo.GetType(), InputCompo);

        _components.Values.ToList().ForEach(component => { component.Initialize(this); });
    }

    public T GetCompo<T>(bool isDerived = false) where T : IPlayerComponent
    {
        if (_components.TryGetValue(typeof(T), out var component))
        {
            return (T)component;
        }

        if (isDerived != false)
        {
            Type findType = _components.Keys.FirstOrDefault(t => t.IsSubclassOf(typeof(T)));
            if (findType != null)
                return (T)_components[findType];
        }

        return default;
    }

    private void Fire()
    {
        Bullet bullet = poolManager.Pop(poolType) as Bullet;

        bullet.Initialize(_firePos.position, _firePos.right);

        InputCompo.OnAttackEvent -= Fire;
    }
}
