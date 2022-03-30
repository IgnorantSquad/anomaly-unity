using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    public class Player : Actor
    {
        [SerializeField]
        private PhysicsComponent physics = new PhysicsComponent();
        public PhysicsComponent actorPhysics => physics;

        protected override void Initialize()
        {
            base.Initialize();
            InitializeComponent(actorPhysics);

            actorStateMachine.AddStates(
                State.Bind(
                    State.New<PlayerLocomotionState>(),
                    State.New<PlayerInteractionState>())
            );
            actorStateMachine.Run();
        }


#if UNITY_EDITOR
        public override void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedObject serializedObject)
        {
            physics.OnInspectorGUI(editor, serializedObject.FindProperty(nameof(physics)));
        }
#endif
    }
}
