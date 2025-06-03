using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SwitchState(new PlayerTestState(this));       
    }
}
