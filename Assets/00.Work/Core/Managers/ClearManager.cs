using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour
{
    [SerializeField] private List<Target> _target;  

    public bool Check()
    {
        foreach (Target target in _target)
        {
            if (target.IsDead == false) return false;
        }

        return true;
    }
}
