using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    public partial class Player : Actor
    {
        [SerializeField]
        private ActorPhysicsComponent physics = new ActorPhysicsComponent();
        public ActorPhysicsComponent Physics => physics;

        protected override void OnInitialized()
        {
            Physics.Initialize(this);

            Behavior.SetBehavior(new PlayerLocomotionBehavior());

            UpdateManager.Register(this);
        }
    }
}



#if UNITY_EDITOR
namespace Anomaly
{
    public partial class Player
    {
        public override void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedObject target)
        {
            physics.OnInspectorGUI(editor, target.FindProperty(nameof(physics)));
        }
    }
}
#endif
