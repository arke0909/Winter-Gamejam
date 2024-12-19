using UnityEngine;

public class HpBa : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private Transform _hpBa;
    private float x = 0;
    private float y;
    public void SetHpBa()
    {
        float value = (_enemyHealth.CurrentHealth / _enemyHealth.MaxHealth) * 5;
        _hpBa.localScale = new Vector2(value, 5);
        float xx = 0.65f - (1 - (value / 5));
        _hpBa.position = new Vector2(xx + _enemyHealth.transform.position.x, _hpBa.position.y);
        
    }


    public void HpReset()
    {
        _hpBa.localScale = new Vector2(5,5);
        if (x == 0)
        {
            x = _hpBa.position.x;
            y = _hpBa.position.y;
        }
        _hpBa.position = new Vector2((float)x, (float)y);
    }
}
