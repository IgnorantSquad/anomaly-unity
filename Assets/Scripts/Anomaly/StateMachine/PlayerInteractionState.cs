using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    public class PlayerInteractionState : State
    {
        public override Identity ID => State.Identity.PlayerInteraction;

        private TriggerListener trigger;

        public override void OnEnter(CustomBehaviour target)
        {
            trigger = target.GetComponent<TriggerListener>();
        }

        public override void OnExit(CustomBehaviour target)
        {

        }

        public override void OnFixedUpdate(CustomBehaviour target)
        {
        }

        public override void OnUpdate(CustomBehaviour target)
        {
            if (trigger.colliderList.Count == 0) return;
            if (Input.GetKeyDown(KeyCode.F))
            {
                foreach (var coll in trigger.colliderList["Interactable"])
                {
                    coll.GetComponent<Actor>().actorInteractor.Receive(target as Actor, new HitEvent(target as Actor, coll.GetComponent<Actor>()));
                }
            }

        }

        public override void OnLateUpdate(CustomBehaviour target)
        {

        }
    }
}