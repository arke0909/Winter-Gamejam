using GGMPool;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PoolTypeSO poolType;
    [SerializeField] private PoolManagerSO poolManager;
    [SerializeField] private Player _player;

    private int minuteCount = 0;
    private float Drainage = 1.3f;

    private int SpawnerProbability = 10;
    private bool spawnCoolTiem;

    private void Spawn()
    {
        EnemyBrain brain = poolManager.Pop(poolType) as EnemyBrain;
        brain.Init(_player); 
        if (minuteCount > 0)
            brain.EnemyStatCompo.UpgradeStat(1.3f * minuteCount);
    }

    

    private void Update()
    {
        if (Time.time >= 60 * minuteCount + 1)
        {
            minuteCount++;
            print("레벨업");
        }
        int random = Random.Range(0, SpawnerProbability);
        if(!spawnCoolTiem)
        {
            
            print("스폰함");
            spawnCoolTiem = true;
            StartCoroutine(StartSpawnCoolTiem());
        }
    }

    private IEnumerator StartSpawnCoolTiem()
    {
        yield return new WaitForSeconds(1.5f);
        print("스폰시작");
        spawnCoolTiem = false;
    }
}
