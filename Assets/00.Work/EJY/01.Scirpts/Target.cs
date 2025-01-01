using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public UnityEvent OnDeadEvent;

    private bool _isDead;

    private void Awake()
    {
        _isDead = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isDead)
        {
            _isDead = true;
            gameObject.SetActive(false);
            OnDeadEvent?.Invoke();
        }
    }
}
