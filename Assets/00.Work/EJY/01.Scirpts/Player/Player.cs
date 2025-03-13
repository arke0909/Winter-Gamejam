using GGMPool;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    

    [field: SerializeField] public InputReader InputCompo { get; private set; }
    [SerializeField] private Mover playerMover;
    [SerializeField] private Mover camMover;

    private Dictionary<Type, IPlayerComponent> _components;

    public bool IsShot { get; private set; } = false;

    private void Awake()
    {
        _components = new Dictionary<Type, IPlayerComponent>();

        SetComponent();
    }

    private void FixedUpdate()
    {
        if(InputCompo.isCamMode)
            playerMover.SetVelocity(InputCompo.InputDir);
        else
            camMover.SetVelocity(InputCompo.InputDir);
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
}
