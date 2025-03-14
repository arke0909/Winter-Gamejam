using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Pool/ToolInfo")]
public class ToolInfoSO : ScriptableObject
{
    [Header("PoolManager")]
    public string poolingFolder = "Assets/00.Work/Pool";
    public string poolAssetName = "PoolManager.asset";
    public string typeFolder = "Types";
    public string itemFolder = "Items";
}
