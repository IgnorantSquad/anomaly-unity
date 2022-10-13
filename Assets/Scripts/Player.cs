using UnityEngine;
using Anomaly;

public class Player : Actor
{
    public StateMachineComponent<Player> StateMachine;
    public SpineComponent Spine;
    public CharacterComponent Character;
    public CameraComponent Camera;

    public EntryDetector Entry;


    protected override void Initialize()
    {
        base.Initialize();

        StateMachine.Run(0,
            State<Player>.Bind(
                new PlayerLocomotionState(),
                new PlayerInteractionState()));
    }
}