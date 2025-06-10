using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    private readonly int FreeLookSpeedHash = Animator.StringToHash("FreeLookSpeed");
    private const float AnimatorDampTime = 0.1f;
    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine)
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
           stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0f,AnimatorDampTime,deltaTime);
           return;
       }
       stateMachine.Animator.SetFloat(FreeLookSpeedHash, 1f,AnimatorDampTime,deltaTime);
       FaceMovementDirection(movimiento, deltaTime);
    }

    private void FaceMovementDirection(Vector3 movimiento, float deltaTime)
    {
        stateMachine.transform.rotation = Quaternion.Lerp(
                                            stateMachine.transform.rotation,
                                            Quaternion.LookRotation(movimiento), 
                                            deltaTime * stateMachine.RotationSpeed);
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