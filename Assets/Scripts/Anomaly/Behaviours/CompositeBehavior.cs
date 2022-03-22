using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    public class CompositeBehavior : IBehavior
    {
        private IBehavior[] behaviors;

        public static CompositeBehavior Bind(params IBehavior[] behaviors)
        {
            CompositeBehavior b = new CompositeBehavior();
            System.Array.Copy(behaviors, b.behaviors, behaviors.Length);
            return b;
        }

        public void OnEnter(Actor actor)
        {
            for (int i = 0; i < behaviors.Length; ++i)
            {
                behaviors[i].OnEnter(actor);
            }
        }

        public void OnExit(Actor actor)
        {
            for (int i = 0; i < behaviors.Length; ++i)
            {
                behaviors[i].OnExit(actor);
            }
        }

        public void OnFixedUpdate(Actor actor, float dt)
        {
            for (int i = 0; i < behaviors.Length; ++i)
            {
                behaviors[i].OnFixedUpdate(actor, dt);
            }
        }

        public void OnLateUpdate(Actor actor, float dt)
        {
            for (int i = 0; i < behaviors.Length; ++i)
            {
                behaviors[i].OnLateUpdate(actor, dt);
            }
        }

        public void OnUpdate(Actor actor, float dt)
        {
            for (int i = 0; i < behaviors.Length; ++i)
            {
                behaviors[i].OnUpdate(actor, dt);
            }
        }
    }
}
