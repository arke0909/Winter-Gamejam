using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private Dictionary<Type, IPlayerComponent> _components;
    private PlayerMover _playerMover;

    private void Awake()
    {
        _components = new Dictionary<Type, IPlayerComponent>();
        _playerMover = GetComponent<PlayerMover>();

        SetComponent();
    }

    private void FixedUpdate()
    {
        _playerMover.SetVelocity(_inputReader.InputDir);
    }

    private void SetComponent()
    {
        GetComponentsInChildren<IPlayerComponent>().ToList().ForEach(component => { _components.Add(component.GetType(), component); });

        _components.Add(_inputReader.GetType(), _inputReader);

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
}
