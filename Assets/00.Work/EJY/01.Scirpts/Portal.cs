using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Portal _anotherPortal;

    private bool _isUse;

    private void Awake()
    {
        _isUse = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isUse)
        {
            if (collision.TryGetComponent(out Bullet bullet))
            {
                _isUse = true;
                _anotherPortal.SetUsed(_isUse);
                bullet.Initialize(_anotherPortal.transform.position, _anotherPortal.transform.right);
            }
        }
    }

    public void SetUsed(bool value) => _isUse = value;
}
