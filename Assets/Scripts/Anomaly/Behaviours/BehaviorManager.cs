using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    public class BehaviorManager
    {
        private IBehavior baseBehavior;
        private List<IBehavior> overlayBehaviors = new List<IBehavior>();

        private Actor targetActor;

        public BehaviorManager(Actor actor)
        {
            this.targetActor = actor;
        }

        public void SetTargetActor(Actor actor)
        {
            this.targetActor = actor;
        }

        public void SetBehavior(IBehavior behavior, bool clear = true)
        {
            baseBehavior?.OnExit(targetActor);
            baseBehavior = behavior;
            if (clear)
            {
                for (int i = 0; i < overlayBehaviors.Count; ++i)
                {
                    overlayBehaviors[i].OnExit(targetActor);
                }
                overlayBehaviors.Clear();
            }
            baseBehavior?.OnEnter(targetActor);
        }

        public void SetOverlayBehavior(params IBehavior[] behaviors)
        {
            for (int i = 0; i < behaviors.Length; ++i)
            {
                if (behaviors[i] == null) continue;

                overlayBehaviors.Add(behaviors[i]);
                behaviors[i].OnEnter(targetActor);
            }
        }

        public void StopBehavior(bool clear = true)
        {
            baseBehavior?.OnExit(targetActor);
            if (clear)
            {
                for (int i = 0; i < overlayBehaviors.Count; ++i)
                {
                    overlayBehaviors[i].OnExit(targetActor);
                }
                overlayBehaviors.Clear();
            }
            baseBehavior = null;
        }


        public void OnFixedUpdate(float dt)
        {
            baseBehavior?.OnFixedUpdate(targetActor, dt);
            for (int i = 0; i < overlayBehaviors.Count; ++i)
            {
                overlayBehaviors[i].OnFixedUpdate(targetActor, dt);
            }
        }

        public void OnUpdate(float dt)
        {
            baseBehavior?.OnUpdate(targetActor, dt);
            for (int i = 0; i < overlayBehaviors.Count; ++i)
            {
                overlayBehaviors[i].OnUpdate(targetActor, dt);
            }
        }

        public void OnLateUpdate(float dt)
        {
            baseBehavior?.OnLateUpdate(targetActor, dt);
            for (int i = 0; i < overlayBehaviors.Count; ++i)
            {
                overlayBehaviors[i].OnLateUpdate(targetActor, dt);
            }
        }
    }
}