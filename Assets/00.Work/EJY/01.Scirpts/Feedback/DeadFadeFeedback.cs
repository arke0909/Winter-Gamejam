using DG.Tweening;
using UnityEngine;

public class DeadFadeFeedback : Feedback
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _duration = 0.5f;

    public override void PlayFeedback()
    {
        _spriteRenderer.DOFade(0, _duration);
    }

    public override void StopFeedback()
    {
    }
}
