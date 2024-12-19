using UnityEngine;

public class SlowPetBullet : PetBullet
{
    public float SlowPower { get; protected set; }

    private float _slowStartTime = 0;
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
        base.Update();
        if (Time.time - _slowStartTime > Duration && _isSlow)
        {
            if (_stat == null)
            {
                Debug.Log("Stat Is Null or Empty");
                return;
            }
            _stat.SetSpeed(1);
            _isSlow = false;
        }
    }
    
    protected override void PetHit()
    {
        Debug.Log("슬로어택!");
        if (_isSlow)
        {
            _slowStartTime = Time.time;
            return;
        }
        _stat = Target.GetComponent<EnemyStat>();
        _slowStartTime = Time.time;
        _isSlow = true;
        _stat.SetSpeed(SlowPower);
    }
}
