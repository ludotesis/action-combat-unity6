using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field:SerializeField]
    public InputReader InputReader { get; private set; }
    [field:SerializeField]
    public CharacterController CharacterController { get; private set; }
    [field:SerializeField]
    public Animator Animator { get; private set; }
    [field:SerializeField]
    public float FreeLookMovementSpeed { get; private set; }
    [field:SerializeField]
    public float RotationSpeed { get; private set; }
    
    public Transform MainCameraTransform { get; private set; }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainCameraTransform = Camera.main.transform;
        SwitchState(new PlayerFreeLookState(this));       
    }
}