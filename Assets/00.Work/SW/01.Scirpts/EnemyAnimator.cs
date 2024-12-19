using System;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator _enemyAni;
    private EnemyBrain _brain;

    public event Action OnAttackAnimation;

    private void Awake()
    {
        _enemyAni = GetComponent<Animator>();
        _brain = GetComponentInParent<EnemyBrain>();
    }

    public void EnemyAniChange(EnemyAnimation enemyAnimation)
    {
        switch (enemyAnimation)
        {
            case EnemyAnimation.Move:
                _enemyAni.Play(_brain.PoolType.typeName + "Move");
                break;
            case EnemyAnimation.Attack:
                _enemyAni.Play(_brain.PoolType.typeName + "Attack");
                break;
            case EnemyAnimation.Hit:
                _enemyAni.Play(_brain.PoolType.typeName + "Hit");
                break;
            case EnemyAnimation.Dead:
                _enemyAni.Play(_brain.PoolType.typeName + "Dead");
                break;
        }
    }

    public void Flip(float x)
    {
        _brain.transform.rotation = x > 0 ? new Quaternion(0, 0, 0, 0) : new Quaternion(0, -180, 0, 0);
    }

    public void InvokeOnAttackAnimationAction()
    {
        OnAttackAnimation?.Invoke();
    }

}

public enum EnemyAnimation
{
    Move,
    Attack,
    Hit,
    Dead
}
