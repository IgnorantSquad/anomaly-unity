using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    public class HitEvent : BaseEvent
    {
        public HitEvent(Actor sender, Actor receiver) : base(sender, receiver)
        {
        }

        public override void Invoke()
        {
            Debug.Log($"{sender.name} hit {receiver.name}");
        }
    }
}