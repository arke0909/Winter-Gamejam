using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] private EnmyState startState;
    [SerializeField] private EnemyDataSO _enemyDataSO;
    [SerializeField] private Player _player;
    private List<EnmyState> _enmyStates;
    private EnmyState _currentState;
    private Rigidbody2D _rigidbody;

    public EnemyDataSO EnemyDataSO { get { return _enemyDataSO; } }
    public Player Target { get { return _player; } }
    public Rigidbody2D EnemyRIgid {  get { return _rigidbody; } }
    private void Awake()
    {
        _enmyStates = new List<EnmyState>();
        GetComponentsInChildren(_enmyStates);

        _rigidbody = GetComponent<Rigidbody2D>();

        _enmyStates.ForEach(state => state.Init(this, _enemyDataSO));
        _currentState = startState;
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
}
