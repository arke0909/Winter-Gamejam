using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoSingleton<GameManager>
{
    public NotifyValue<int> Penetation = new NotifyValue<int>(0);
    public NotifyValue<bool> IsHoming = new NotifyValue<bool>();

    [SerializeField] private float _multiplyValueExpLimit = 20;

    [SerializeField] private float _maxExp = 100;
    [SerializeField] private float _exp;

    private float _mutiplyExp = 1;

    private float _originMaxExp;

    public UnityEvent LevelUpEvent;


    private Player player;
    public Player Player => player;
    [field : SerializeField] public int Level { get; private set; } = 1;

    public float EXP
    {
        get
        {
            return _exp;
        }

        set
        {
            if (value < 0)
                _exp = 0;
        }
    }


    private void Awake()
    {
        _originMaxExp = _maxExp;

        player = FindFirstObjectByType<Player>();

    }

    public void EXPUp(float expValue)
    {
        _exp += expValue * _mutiplyExp;

        if (_exp >= _maxExp)
        {
            _exp -= _maxExp;
            EXPLimitUp(_multiplyValueExpLimit);
            LevelUp();
        }
    }

    public void EXPLimitUp(float multiplyValue)
    {
        _maxExp += (_originMaxExp * multiplyValue);
    }

    private void LevelUp()
    {
        LevelUpEvent?.Invoke();
        Level++;
    }

    public void SetMultiplyWithExp(float value)
    {
        _mutiplyExp = value;
    }

    public void SetHomingValue(bool value)
    {
        IsHoming.Value = value;
    }
    public void SetPenetation(int value)
    {
        Penetation.Value = value;
    }
}
