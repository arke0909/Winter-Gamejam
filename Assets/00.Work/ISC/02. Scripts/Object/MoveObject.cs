using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private float duration;

    [SerializeField] private Vector2 dir;

    private void Start()
    {
        Move();
    }

    private void Move()
    {
        Sequence sequence = DOTween.Sequence()
            .Append(transform.DOMove(new Vector2(transform.position.x + dir.x, transform.position.y + dir.y), duration).SetEase(Ease.Linear))
            .SetLoops(-1, LoopType.Yoyo);
    }
}
