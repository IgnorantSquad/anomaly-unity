using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly.Temp
{
    public class InteractTriggerBehavior : IBehavior
    {
        public void OnEnter(Actor actor)
        {
        }

        public void OnExit(Actor actor)
        {

        }

        void A(Actor self, Actor target)
        {
            Debug.Log($"{self.gameObject.name} <=> {target.gameObject.name} Enter");
        }
        void B(Actor self, Actor target)
        {
            Debug.Log($"{self.gameObject.name} <=> {target.gameObject.name} Stay");
        }
        void C(Actor self, Actor target)
        {
            Debug.Log($"{self.gameObject.name} <=> {target.gameObject.name} Exit");
        }

        public void OnFixedUpdate(Actor actor, float dt)
        {
        }

        public void OnUpdate(Actor actor, float dt)
        {
        }

        public void OnLateUpdate(Actor actor, float dt)
        {
        }
    }
}
