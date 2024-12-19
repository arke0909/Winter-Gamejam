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
        brain.Init(_player, transform); 
        if (minuteCount > 0)
            brain.EnemyStatCompo.UpgradeStat(1.3f * minuteCount);
    }

    

    private void Update()
    {
        if (Time.time >= 60 * (minuteCount + 1))
        {
            print("°­È­");
            minuteCount++;
            SpawnerProbability--;
        }
        if(!spawnCoolTiem)
        {
            int random = Random.Range(0, SpawnerProbability);
            if(random == 0) Spawn();
            spawnCoolTiem = true;
            StartCoroutine(StartSpawnCoolTiem());
        }
    }

    public void SetSpawnerPoint()
    {
        float x = Random.Range(-20, 20);
        float y = Random.Range(-20, 20);
        transform.position = new Vector2(_player.transform.position.x + x, _player.transform.position.y + y);
    }

    private IEnumerator StartSpawnCoolTiem()
    {
        yield return new WaitForSeconds(0.5f);
        spawnCoolTiem = false;
    }
}
