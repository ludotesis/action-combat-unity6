using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    
    public Vector2 MovementValue { get; private set; }
    
    public event Action JumpEvent;
    public event Action DodgeEvent;
    
    private Controls controls;
    private void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
    }
    private void OnDestroy()
    {
        controls.Player.Disable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            JumpEvent?.Invoke();    
        }
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {

    }

    public void OnNext(InputAction.CallbackContext context)
    {

    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DodgeEvent?.Invoke();    
        }
    }
}