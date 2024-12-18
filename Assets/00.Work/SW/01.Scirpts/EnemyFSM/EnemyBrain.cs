using GGMPool;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class EnemyBrain : MonoBehaviour, IPoolable
{
    [SerializeField] private EnmyState startState;
    [SerializeField] private EnemyDataSO _enemyDataSO;
    [SerializeField] private PoolTypeSO _poolType;

    private Player _player;
    private List<EnmyState> _enmyStates;
    private EnmyState _currentState;
    private Rigidbody2D _rigidbody;
    private EnemyStat _enemyStat;
    private EnemyHealth _enemyHealth;
    private Pool _pool;

    [SerializeField] private bool IsLongRange;
    [SerializeField] private Transform gunBasePosition;

    public EnemyStat EnemyStatCompo { get { return _enemyStat; } }
    public Player Target { get { return _player; } }
    public Rigidbody2D EnemyRIgidCompo {  get { return _rigidbody; } }
    public EnemyHealth EnemyHealthCompo { get { return _enemyHealth; } }

    public PoolTypeSO PoolType => _poolType;

    public GameObject GameObject => gameObject;

    private bool _alreadyCollected;

    public void Init(Player target)
    {
        _player = target;
        if (_alreadyCollected) return;
        _alreadyCollected = true;

        _enmyStates = new List<EnmyState>();
        GetComponentsInChildren(_enmyStates);

        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyStat = GetComponent<EnemyStat>();
        _enemyStat.SetStat(_enemyDataSO);
        _enemyHealth.Initialize(EnemyStatCompo.Hp);
        StartCoroutine(SpawnTiem());
        _enmyStates.ForEach(state => state.Init(this, _enemyStat));
        _currentState = startState;
        
    }

    private IEnumerator SpawnTiem()
    {
        yield return null;
        _enemyHealth.Initialize(EnemyStatCompo.Hp);
    }

    private void Update()
    {
        if (_currentState == null) return;
        _currentState.UpdateState();

        if (IsLongRange)
        {
            Vector3 dir = Target.transform.position - transform.position;
            float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            gunBasePosition.rotation = Quaternion.Euler(0,0,z);
        }

    }

    public void ChangeState(EnmyState golemAIState)
    {
        if(_currentState != null)
            _currentState.OnExitState();
        _currentState = golemAIState;
        _currentState.OnEnterState();
    }

    public void SetUpPool(Pool pool)
    {
        _pool = pool;
    }

    public void ResetItem()
    {
        _alreadyCollected = false;
    }
}
