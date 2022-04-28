using UnityEngine;
using Anomaly;

public class Player : Actor
{
    public CharacterComponent.Data characterData;

    public CameraComponent.Data cameraData;
    

    protected override void Initialize()
    {
        base.Initialize();

        stateMachineData.AddStates(
            State.Bind(
                State.New<PlayerLocomotionState>(),
                State.New<PlayerInteractionState>())
        );

        stateMachine.Run(stateMachineData);
    }
}