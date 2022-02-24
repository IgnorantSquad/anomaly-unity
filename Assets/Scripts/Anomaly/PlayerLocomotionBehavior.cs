using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anomaly;

public class PlayerLocomotionBehavior : IBehavior
{
    public void OnEnter(Actor actor)
    {

    }

    public void OnExit(Actor actor)
    {

    }

    public void OnFixedUpdate(Actor actor, float dt)
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical") * 0F;

        Vector3 dir = new Vector3(h, 0F, v);

        var physics = (actor as Player).Physics;

        physics.Move(dir * dt * physics.MoveSpeed); 
    }

    public void OnUpdate(Actor actor, float dt)
    {
    }

    public void OnLateUpdate(Actor actor, float dt)
    {

    }
}
