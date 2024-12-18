using System;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private float _multiplyValueExpLimit = 20;

    [SerializeField] private float _maxExp = 100;
    private float _originMaxExp;
    private float _exp;

    private Player player;
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
        EXP += expValue;

        if (_exp >= _maxExp)
        {
            _exp -= _maxExp;
            EXPLimitUp(_multiplyValueExpLimit);
            LevelUp();
        }
    }

    public void EXPLimitUp(float multiplyValue)
    {
        _maxExp +=  (_originMaxExp * multiplyValue) - _originMaxExp;
    }

    private void LevelUp()
    {

    }

}
