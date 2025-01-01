using UnityEngine;

public class PlayerRenderer : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    private InputReader _inputReader;

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
        Vector2 mousePos = _inputReader.MousePos;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.parent.rotation = Quaternion.Euler(0, 0, angle);

        float scaleY = mousePos.x < _player.transform.position.x ? -1 : 1;

        transform.localScale = new Vector3(1, scaleY, 1);
    }
}
