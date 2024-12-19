using GGMPool;
using System.Collections.Generic;
using UnityEngine;

public class ExpSpawner : MonoBehaviour
{
    [SerializeField] private PoolManagerSO _poolManager;
    [SerializeField]
    private List<PoolTypeSO> _poolType;

    public void ExpDrop(Transform transform)
    {
        Debug.Log("¶³±À");

        int idx = Random.Range(0, _poolType.Count);
        PoolTypeSO poolType = _poolType[idx];

        _poolManager.Pop(poolType).GameObject.transform.position = transform.position;
    }
}
