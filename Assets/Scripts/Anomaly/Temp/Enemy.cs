using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly.Temp
{
    public partial class Enemy : Actor
    {
        [SerializeField]
        private ActorPhysicsComponent physics = new ActorPhysicsComponent();
        public ActorPhysicsComponent Physics => physics;
    }
}



#if UNITY_EDITOR
namespace Anomaly.Temp
{
    public partial class Enemy
    {
        public override void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedObject target)
        {
            physics.OnInspectorGUI(editor, target.FindProperty(nameof(physics)));
        }
    }
}
#endif
