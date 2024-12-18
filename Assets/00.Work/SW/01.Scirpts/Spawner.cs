using GGMPool;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PoolTypeSO poolType;
    [SerializeField] private PoolManagerSO poolManager;

    private int minuteCount = 1;
    private float Drainage = 1.3f;

    private void Spawn()
    {
        EnemyBrain brain = poolManager.Pop(poolType) as EnemyBrain;
        brain.Init();
        brain.EnemyStatCompo.UpgradeStat(1.3f * minuteCount);
    }

    private void Update()
    {
        if (Time.time >= 60 * minuteCount)
        {
            minuteCount++;
        }
    }
}
