using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    private float timer = 3f;
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Enter");
        stateMachine.InputReader.JumpEvent += OnJump;
    }

    public override void Tick(float deltaTime)
    {
        timer -= deltaTime;
        Debug.Log("Tick");

        if (timer <= 0)
        {
            stateMachine.SwitchState(new PlayerTestState(stateMachine));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit");
        stateMachine.InputReader.JumpEvent -= OnJump;
    }

    private void OnJump()
    {
        Debug.Log("Estas Saltando");
    }
}