using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    public class Player : CustomObject
    {
        [SerializeField]
        private ActorPhysicsData physicsData;

        [SerializeField]
        private PhysicsComponent physics = new PhysicsComponent();

        private TransformComponent transformComponent = new TransformComponent();

        void OnFixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical") * 0F;

            Vector3 dir = new Vector3(h, 0F, v);

            physics.Move(dir * Time.deltaTime * physicsData.moveSpeed.Default);
        }

#if UNITY_EDITOR
        public override void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedObject serializedObject)
        {
            physics.OnInspectorGUI(editor, serializedObject.FindProperty(nameof(physics)));
        }
#endif
    }
}
