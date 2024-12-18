using UnityEngine;

public class SlowPetBullet : PetBullet
{
    public float SlowPower { get; protected set; }

    private float _startTime = 0;
    private const float Duration = 2.75f;
    
    private bool _isSlow = false;
    
    private EnemyStat _stat;

    public void AfaterInit(float slowPower)
    {
        SlowPower = slowPower;
    }
    
    public override void ResetItem()
    {
        base.ResetItem();
        _isSlow = false;
    }

    private void Update()
    {
        if (Time.time - _startTime > Duration)
        {
            _stat.SetSpeed(1);
        }
    }
    
    protected override void PetHit()
    {
        if (_isSlow) return;
        _stat = Target.GetComponent<EnemyStat>();
        _startTime = Time.time;
        _isSlow = true;
        _stat.SetSpeed(SlowPower);
    }
}
