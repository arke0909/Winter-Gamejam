using GGMPool;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] private EnmyState startState;
    [SerializeField] private EnemyDataSO _enemyDataSO;
    [SerializeField] private Player _player;

    private List<EnmyState> _enmyStates;
    private EnmyState _currentState;
    private Rigidbody2D _rigidbody;
    private EnemyHealth _enemyHealth;

    [SerializeField] private bool IsLongRange;
    [SerializeField] private Transform gunBasePosition;

    public EnemyDataSO EnemyDataSO { get { return _enemyDataSO; } }
    public Player Target { get { return _player; } }
    public Rigidbody2D EnemyRIgid {  get { return _rigidbody; } }
    public EnemyHealth EnemyHealth { get { return _enemyHealth; } }
    private void Awake()
    {
        _enmyStates = new List<EnmyState>();
        GetComponentsInChildren(_enmyStates);

        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyHealth = GetComponent<EnemyHealth>();

        _enmyStates.ForEach(state => state.Init(this, _enemyDataSO));
        _currentState = startState;
        
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
}
