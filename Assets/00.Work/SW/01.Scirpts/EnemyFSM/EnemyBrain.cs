using GGMPool;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
    private EnemyAnimator _enemyAnimator;

    [SerializeField] private bool IsLongRange;

    public EnemyStat EnemyStatCompo { get { return _enemyStat; } }
    public Player Target { get { return _player; } }
    public Rigidbody2D EnemyRIgidCompo {  get { return _rigidbody; } }
    public EnemyHealth EnemyHealthCompo { get { return _enemyHealth; } }
    public EnemyAnimator EnemyAnimatorCompo => _enemyAnimator;
    public PoolTypeSO PoolType => _poolType;
    public GameObject GameObject => gameObject;
    public DamageCaster DamageCasterCompo { get; private set; }
    public bool _CanMove { get; set; }

    private bool _alreadyCollected;

    public void Init(Player target, Transform startingPoint)
    {
        _player = target;
        transform.position = startingPoint.position;
        if (_alreadyCollected) return;
        _alreadyCollected = true;

        _enmyStates = new List<EnmyState>();
        GetComponentsInChildren(_enmyStates);

        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyStat = GetComponent<EnemyStat>();
        _enemyAnimator = GetComponentInChildren<EnemyAnimator>();
        DamageCasterCompo = GetComponentInChildren<DamageCaster>();

        _enemyStat.SetStat(_enemyDataSO);
        _enemyHealth.Initialize(EnemyStatCompo.Hp);
        _enemyHealth.NextHealth = 1;
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
