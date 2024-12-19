using System;
using UnityEngine;

public class PlayerBullet : Bullet
{
    [SerializeField] private LayerMask _whatIsEnemy;
    [SerializeField] private float _radius = 1;
    [SerializeField] private float rotateSpeed = 5;
    [SerializeField] private bool isHoming;
    private Collider2D _enemyCollider = null;

    private Vector2 moveDir;

    protected override void Awake()
    {
        base.Awake();
        GameManager.Instance.Penetation.OnValueChanged += HandlePenetationCount;
        GameManager.Instance.IsHoming.OnValueChanged += HandleHoming;
    }

    private void FixedUpdate()
    {
        if (!isHoming) return;

        _enemyCollider = Physics2D.OverlapCircle(transform.position, _radius, _whatIsEnemy);

        if (_enemyCollider == null) return;

        Vector2 targetDir = ((Vector2)_enemyCollider.transform.position - (Vector2)transform.position).normalized;
        float targetDirAngle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;

        float step = rotateSpeed * Time.fixedDeltaTime;
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            Quaternion.Euler(0, 0, targetDirAngle),
            step
        );

        float moveDirAngle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        moveDir = new Vector2(Mathf.Cos(moveDirAngle), Mathf.Sin(moveDirAngle));
        Vector2 movePosition = _rigid.position + (moveDir * speed) * Time.fixedDeltaTime;
        _rigid.MovePosition(movePosition);
    }


    private void HandleHoming(bool prev, bool next)
    {
        isHoming = next;
    }

    private void HandlePenetationCount(int prev, int next)
    {
        PenetrationCnt = next;
    }

    protected override void Hit()
    {
        SkillManager.Instance.OnHit?.Invoke(transform);
    }

    private void OnApplicationQuit()
    {
        GameManager.Instance.Penetation.OnValueChanged -= HandlePenetationCount;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

#endif
}
