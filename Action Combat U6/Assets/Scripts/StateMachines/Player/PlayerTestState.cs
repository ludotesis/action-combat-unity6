using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
      
    }

    public override void Tick(float deltaTime)
    { 
       Vector3 movimiento = CalcularMovimiento();
       
       //stateMachine.transform.Translate(movement * deltaTime);
       stateMachine.CharacterController.Move(movimiento * stateMachine.FreeLookMovementSpeed * deltaTime);

       if (stateMachine.InputReader.MovementValue == Vector2.zero)
       {
           stateMachine.Animator.SetFloat("FreeLookSpeed", 0f,0.1f,deltaTime);
           return;
       }
       stateMachine.Animator.SetFloat("FreeLookSpeed", 1f,0.1f,deltaTime);
       stateMachine.transform.rotation = Quaternion.LookRotation(movimiento);
    }

    public override void Exit()
    {
        
    }

    private Vector3 CalcularMovimiento()
    {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right   = stateMachine.MainCameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        return forward.normalized * stateMachine.InputReader.MovementValue.y +
               right.normalized * stateMachine.InputReader.MovementValue.x;
    }
}