using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : Anomaly.CustomBehaviour
{
    public AnimationComponent.Data animationData;
    
    public StateMachineComponent.Data stateMachineData;


    protected StateMachineComponent stateMachine;


    protected override void Initialize()
    {
        base.Initialize();

        stateMachine = GetSharedComponent<StateMachineComponent>();
    }


    // TODO: component's update manager is required
    public void OnFixedUpdate()
    {
        stateMachine.OnFixedUpdate(stateMachineData);
    }
    public void OnUpdate()
    {
        stateMachine.OnUpdate(stateMachineData);
    }
    public void OnLateUpdate()
    {
        stateMachine.OnLateUpdate(stateMachineData);
    }
}