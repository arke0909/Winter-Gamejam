using UnityEngine;

public class HpBa : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private Transform _hpBa;
    private float x = 0.65f;
    private float y = 1.575f;
    public void SetHpBa()
    {
        float value = (_enemyHealth.CurrentHealth / _enemyHealth.MaxHealth) * 5;
        if(value <= 0 ) value = 0;
        _hpBa.localScale = new Vector2(value, 5);
        float xx = 0.65f - (1 - (value / 5));
        _hpBa.position = new Vector2(xx + _enemyHealth.transform.position.x, y + _enemyHealth.transform.position.y);
        
    }


    public void HpReset()
    {
        _hpBa.localScale = new Vector2(5,5);
        _hpBa.position = new Vector2(x + _enemyHealth.transform.position.x, y + _enemyHealth.transform.position.y);
    }
}
