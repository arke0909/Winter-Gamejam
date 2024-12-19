using System;
using UnityEngine;

public class KAYTestEnemyHealth :Health
{
    int max = 100;

    /*protected override void Die()
    {
        base.Die();
        Debug.Log("die");
    }*/

    private void Start()
    {
        Initialize(max);    
    }


}
