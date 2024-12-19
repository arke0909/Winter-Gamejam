using GGMPool;
using System.Collections;
using UnityEngine;

public class EffectPlayer : MonoBehaviour, IPoolable
{
    [SerializeField] private PoolTypeSO _poolType;
    [SerializeField] private PoolManagerSO _poolManager;

    private Pool _pool;

    public GameObject ObjectPrefab => gameObject;

    public PoolTypeSO PoolType => _poolType;

    public GameObject GameObject => gameObject;

    private ParticleSystem _particle;
    private float _duration;
    private WaitForSeconds _particleDuration;


    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
        _duration = _particle.main.duration; //��ƼŬ �ý����� ���θ�⿡�� 
        _particleDuration = new WaitForSeconds(_duration);
    }

    public void SetPositionAndPlay(Vector3 position)
    {
        transform.position = position;
        _particle.Play();
        StartCoroutine(DelayAndGotoPoolCoroutine());
    }

    private IEnumerator DelayAndGotoPoolCoroutine()
    {
        yield return _particleDuration;
        _poolManager.Push(this);
    }

    public void ResetItem()
    {
        _particle.Stop();
        _particle.Simulate(0); //��ƼŬ �����ġ�� ó������ �ǵ���.
    }

    public void SetUpPool(Pool pool)
    {
        _pool = pool;
    }
}
