using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly.Temp
{
    public class InteractableObject : Actor
    {
        protected override void RegisterComponents()
        {
            base.RegisterComponents();
            components.AddRange(new IComponent[] { new ActorPhysicsComponent() });
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Behavior.SetBehavior(new InteractTriggerBehavior());
        }
    }
}
