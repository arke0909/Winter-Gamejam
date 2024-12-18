using GGMPool;
using System.Collections;
using UnityEngine;

public class EXP : Collectable, IPoolable
{
    [SerializeField] private PoolManagerSO _poolManager;
    [SerializeField] private PoolTypeSO _poolType;
    [SerializeField] private float _expValue;

    private Pool _pool;

    public PoolTypeSO PoolType => _poolType;

    public GameObject GameObject => gameObject;

    public override void Collect(Transform collector, float magneticPower)
    {
        if (_alreadyCollected) return;

        _alreadyCollected = true;

        StartCoroutine(CollectCoroutine(collector, magneticPower));
    }

    private IEnumerator CollectCoroutine(Transform collector, float magneticPower)
    {
        float distance = Vector2.Distance(transform.position, collector.position);
        float time = distance / magneticPower;
        float currentTime = 0;

        Vector3 startPosition = transform.position;
        while (currentTime <= time)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / time;
            transform.position =
                Vector3.Lerp(startPosition, collector.position, t * t * t);
            yield return null;
        }

        _poolManager.Push(this);
        GameManager.Instance.EXPUp(_expValue);
    }

    public void ResetItem()
    {
        _alreadyCollected = false;
    }

    public void SetUpPool(Pool pool)
    {
        _pool = pool;
    }
}
