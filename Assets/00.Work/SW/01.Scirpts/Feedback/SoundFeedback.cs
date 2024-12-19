using GGMPool;
using UnityEngine;

public class SoundFeedback : Feedback
{
    [SerializeField] private PoolManagerSO poolManager;
    [SerializeField] private PoolTypeSO poolType;
    [SerializeField] private SoundSO soundData;
    private SoundPlayer soundPlayer;
    public override void PlayFeedback()
    {
        soundPlayer = poolManager.Pop(poolType) as SoundPlayer;
        soundPlayer.PlaySound(soundData);
    }

    public override void StopFeedback()
    {
        soundPlayer.StopAndGoToPool();
    }
}
