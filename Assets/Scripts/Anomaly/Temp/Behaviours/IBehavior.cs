using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly.Temp
{
    public interface IBehavior
    {
        void OnEnter(Actor actor);
        void OnFixedUpdate(Actor actor, float dt);
        void OnUpdate(Actor actor, float dt);
        void OnLateUpdate(Actor actor, float dt);
        void OnExit(Actor actor);
    }
}