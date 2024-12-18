using System;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{

    [SerializeField] private float _multiplyValueExpLimit = 20;

    [SerializeField] private float _maxExp = 100;
    [SerializeField] private float _exp;

    private float _originMaxExp;

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
        _exp += expValue;

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
        Level++;
    }

}
