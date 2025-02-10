using UnityEngine;

public class PlayerRenderer : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    private InputReader _inputReader;
    [SerializeField] private Transform _tm;

    public void Initialize(Player player)
    {
        _player = player;
        _inputReader = _player.GetCompo<InputReader>();
    }

    private void Update()
    {
        if (_player.IsShot == true) return;

        RotateAndFlip();
    }

    private void RotateAndFlip()
    {
        Vector2 mousePos = new Vector2( _inputReader.MousePos.x - _tm.transform.position.x , _inputReader.MousePos.y - _tm.transform.position.y);
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.parent.rotation = Quaternion.Euler(0, 0, angle);

        float scaleY = mousePos.x < _player.transform.position.x ? -1 : 1;

        transform.localScale = new Vector3(1, scaleY, 1);
    }
}
