using GGMPool;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PoolTypeSO poolType;
    [SerializeField] private PoolManagerSO poolManager;

    private int minuteCount = 0;
    private float Drainage = 1.3f;

    private void Awake()
    {
        
    }

    private void Spawn()
    {
        EnemyBrain brain = poolManager.Pop(poolType) as EnemyBrain;
        brain.Init();
        brain.EnemyStatCompo.UpgradeStat(1.3f * minuteCount);
    }

    private void Update()
    {
        if (Time.time >= 60 * minuteCount + 1)
        {
            minuteCount++;
        }
    }
}
