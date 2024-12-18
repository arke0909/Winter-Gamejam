using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Control;

[CreateAssetMenu(fileName = "InputReader", menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public event Action OnAttackEvent;
    public event Action OnMoveEvent;
    public event Action OnESCEvent;

    private Control _control;

    private void OnEnable()
    {
        if (_control == null)
        {
            _control = new Control();

            _control.Player.SetCallbacks(this);
        }



        _control.Player.Enable();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnAttackEvent?.Invoke();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnMoveEvent?.Invoke();
    }

    public void OnESC(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnESCEvent?.Invoke();
    }

}
