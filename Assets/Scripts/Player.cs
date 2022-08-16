using UnityEngine;
using Anomaly;

public class Player : Actor
{
    public SpineComponent Spine;

    public CharacterComponent Character;

    public CameraComponent Camera;


    protected override void Initialize()
    {
        base.Initialize();

        StateMachine.Run(0,
            State.Bind(
                State.New<PlayerLocomotionState>(),
                State.New<PlayerInteractionState>()));
    }
}