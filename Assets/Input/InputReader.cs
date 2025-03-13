using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Control;

[CreateAssetMenu(fileName = "InputReader", menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions, IPlayerComponent
{
    public event Action OnAttackEvent;
    public event Action OnESCEvent;

    public Vector2 InputDir { get; private set; }

    public bool isCamMode;

    public Vector2 MousePos
    {
        get
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(_mousePos);
            return mousePos;
        }
    }
    private Vector2 _mousePos;

    private Control _control;

    private Player _player;

    private void OnEnable()
    {
        if (_control == null)
        {
            _control = new Control();

            _control.Player.SetCallbacks(this);
        }

        _control.Player.Enable();
    }

    private void OnDisable()
    {
        _control.Disable();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnAttackEvent?.Invoke();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        InputDir = context.ReadValue<Vector2>();
    }

    public void OnESC(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnESCEvent?.Invoke();
    }

    public void OnMouse(InputAction.CallbackContext context)
    {
        _mousePos = context.ReadValue<Vector2>();
    }

    public void OnMode(InputAction.CallbackContext context)
    {
        if(context.performed)
            isCamMode = !isCamMode;
    }

    public void Initialize(Player player)
    {
        _player = player;
    }

}
