using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    public class Enemy : Actor
    {
        [SerializeField]
        private ActorPhysics physics = new ActorPhysics();
        public ActorPhysics Physics => physics;

#if UNITY_EDITOR
        public override void OnInspectorGUI(Object target)
        {
            physics.OnInspectorGUI(target);
        }
#endif
    }
}
