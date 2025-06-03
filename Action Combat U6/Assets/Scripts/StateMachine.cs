using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private State currentState;
    private void Update()
    {
        if (currentState != null)
        {
            currentState.Tick(Time.deltaTime);    
        }
    }
}