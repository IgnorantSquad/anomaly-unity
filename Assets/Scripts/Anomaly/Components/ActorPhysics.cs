using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    [System.Serializable]
    public class ActorPhysics : IComponent
    {
        [SerializeField]
        private Utils.SerializableDictionary<Rigidbody> rigidbodies = new Utils.SerializableDictionary<Rigidbody>("Main", null);
        [SerializeField]
        private Utils.SerializableDictionary<Collider> colliders = new Utils.SerializableDictionary<Collider>("Main", null);

        public Rigidbody rigidbody => rigidbodies == null ? null : rigidbodies.Container["Main"];
        public Collider collider => colliders == null ? null : colliders.Container["Main"];

        public void Initialize(Actor actor)
        {

        }

#if UNITY_EDITOR
        public void OnInspectorGUI(Object target)
        {
            GUILayout.BeginVertical("box");
            rigidbodies.OnInspectorGUI(target, "Rigidbodies");
            GUILayout.Space(5);
            colliders.OnInspectorGUI(target, "Colliders");
            GUILayout.EndVertical();
        }
#endif
    }
}
