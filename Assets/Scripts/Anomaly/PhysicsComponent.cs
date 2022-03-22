using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    [System.Serializable]
    public partial class PhysicsComponent : CustomComponent
    {
        [SerializeField]
        protected Utils.SerializableDictionary<Rigidbody> rigidbodies = new Utils.SerializableDictionary<Rigidbody>("Main", null);
        [SerializeField]
        protected Utils.SerializableDictionary<Collider> colliders = new Utils.SerializableDictionary<Collider>("Main", null);

        public Rigidbody rigidbody => rigidbodies == null ? null : rigidbodies.Container["Main"];
        public Collider collider => colliders == null ? null : colliders.Container["Main"];

        //public bool IsGrounded { get; private set; } = false;
        public bool IsGrounded => rigidbody.useGravity && Utils.Math.IsNotZero(Physics.gravity.y) && Utils.Math.IsZero(rigidbody.velocity.y);


        public void Move(Vector3 dir, string name = "Main")
        {
            var rb = rigidbodies.Container[name];
            rigidbodies.Container[name].MovePosition(rb.transform.position + dir);
        }

        public void AddForce(Vector3 power, ForceMode forceMode = ForceMode.Force, string name = "Main")
        {
            rigidbodies.Container[name].AddForce(power, forceMode);
        }
        public void AddForce(Vector3 dir, float power, ForceMode forceMode = ForceMode.Force, string name = "Main")
        {
            AddForce(dir * power, forceMode, name);
        }

        public void AddForceAtPosition(Vector3 power, Vector3 position, ForceMode forceMode = ForceMode.Force, string name = "Main")
        {
            rigidbodies.Container[name].AddForceAtPosition(power, position, forceMode);
        }
        public void AddForceAtPosition(Vector3 dir, float power, Vector3 position, ForceMode forceMode = ForceMode.Force, string name = "Main")
        {
            AddForceAtPosition(dir * power, position, forceMode, name);
        }

        public void Stop(string name = "Main")
        {
            rigidbodies.Container[name].velocity = Vector3.zero;
        }
    }
}



#if UNITY_EDITOR
namespace Anomaly
{
    using UnityEditor;

    public partial class PhysicsComponent
    {
        public override void OnInspectorGUI(UnityEditor.Editor editor, SerializedProperty target)
        {
            GUILayout.BeginVertical("box");
            rigidbodies.OnInspectorGUI(editor, target.FindPropertyRelative(nameof(rigidbodies)), "Rigidbodies");
            GUILayout.Space(5);
            colliders.OnInspectorGUI(editor, target.FindPropertyRelative(nameof(colliders)), "Colliders");
            GUILayout.EndVertical();
        }
    }
}
#endif