using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly.Temp
{
    public class ACollider : MonoBehaviour
    {
        public Actor attachedActor;

        public UnityEngine.Events.UnityEvent<Actor, Actor> onEnter, onStay, onExit;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (onEnter == null) return;
            onEnter?.Invoke(attachedActor, GetCollider(collision).attachedActor);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (onStay == null) return;
            onStay?.Invoke(attachedActor, GetCollider(collision).attachedActor);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (onExit == null) return;
            onExit?.Invoke(attachedActor, GetCollider(collision).attachedActor);
        }


        private ACollider GetCollider(Collider2D coll)
        {
            return coll.GetComponent<ACollider>();
        }
    }
}
