using GGMPool;
using UnityEngine;

public class SoundFeedback : Feedback
{
    [SerializeField] private PoolTypeSO _poolType;
    [SerializeField] private SoundSO _soundData;

    private PoolManagerSO _poolManager => GameManager.Instance.PoolManagerSO;

    public override void PlayFeedback()
    {
        SoundPlayer soundPlayer = _poolManager.Pop(_poolType) as SoundPlayer;
        soundPlayer.PlaySound(_soundData);
    }

    public override void StopFeedback()
    {

    }
}
