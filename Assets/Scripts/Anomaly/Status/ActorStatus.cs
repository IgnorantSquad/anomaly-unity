using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    public enum ActorState : int
    {
        DEFAULT = 0,

        BLEED = 1 << 0,
        POISON = 1 << 1
    }

    public class ActorStatus
    {
        public ActorState Current { get; private set; } = ActorState.DEFAULT;
    }
}
