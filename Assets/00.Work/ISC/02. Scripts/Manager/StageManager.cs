using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class StageManager : MonoSingleton<StageManager>
{
    private List<StageUI> _stages;
    
    private int _currentStage;
    
    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StageOpen();
        }
    }

    private void Initialize()
    {
        _stages = GetComponentsInChildren<StageUI>().ToList();

        for (int i = 1; i < _stages.Count; i++)
        {
            _stages[i].Initialize();
        }

        _currentStage = 1;
    }

    public void StageOpen()
    {
        if (_currentStage > _stages.Count - 1) return;
        _stages[_currentStage].Open();
        _currentStage++;
    }
}
