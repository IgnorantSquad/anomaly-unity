using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly.Temp
{
    public partial class Player : Actor
    {
        [SerializeField]
        private ActorPhysicsComponent physics = new ActorPhysicsComponent();
        public ActorPhysicsComponent Physics => physics;

        protected override void RegisterComponents()
        {
            base.RegisterComponents();
            components.AddRange(new IComponent[] { new ActorPhysicsComponent() });
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            //UpdateManager.Instance.Register(this);

            Physics.Initialize(this);

            //Behavior.RegisterBehaviors((BehaviorType.BASIC_LOCOMOTION, CompositeBehavior.Bind(new PlayerLocomotionBehavior())));
            Behavior.SetBehavior(new PlayerLocomotionBehavior());
        }
    }
}



#if UNITY_EDITOR
namespace Anomaly.Temp
{
    public partial class Player
    {
        public override void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedObject target)
        {
            base.OnInspectorGUI(editor, target);

            physics.OnInspectorGUI(editor, target.FindProperty(nameof(physics)));
        }
    }
}
#endif
