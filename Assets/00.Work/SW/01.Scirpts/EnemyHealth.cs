using UnityEngine;

public class EnemyHealth : Health
{
    private EnemyBrain _brain;

    private void Awake()
    {
        _brain = GetComponent<EnemyBrain>();
        Initialize(_brain.EnemyDataSO.hp);
    }
}
