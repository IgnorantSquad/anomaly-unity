using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : Anomaly.CustomBehaviour
{
    public TransformComponent actorTransform { get; protected set; } = new TransformComponent();
    public AnimationComponent actorAnimation { get; protected set; } = new AnimationComponent();
    public StateMachineComponent actorStateMachine { get; protected set; } = new StateMachineComponent();

    public InteractorComponent actorInteractor { get; protected set; } = new InteractorComponent();

    protected override void Initialize()
    {
        base.Initialize();
        InitializeComponent(actorTransform, actorAnimation, actorStateMachine, actorInteractor);
    }


    // TODO: component's update manager is required
    public void OnFixedUpdate()
    {
        actorStateMachine.OnFixedUpdate();
    }
    public void OnUpdate()
    {
        actorStateMachine.OnUpdate();
        actorInteractor.OnUpdate();
    }
    public void OnLateUpdate()
    {
        actorStateMachine.OnLateUpdate();
    }
}