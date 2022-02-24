using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    [System.Serializable]
    public partial class PhysicsComponent : IComponent
    {
        [SerializeField]
        protected Utils.SerializableDictionary<Rigidbody> rigidbodies = new Utils.SerializableDictionary<Rigidbody>("Main", null);
        [SerializeField]
        protected Utils.SerializableDictionary<Collider> colliders = new Utils.SerializableDictionary<Collider>("Main", null);

        public Rigidbody rigidbody => rigidbodies == null ? null : rigidbodies.Container["Main"];
        public Collider collider => colliders == null ? null : colliders.Container["Main"];

        //public bool IsGrounded { get; private set; } = false;
        public bool IsGrounded => rigidbody.useGravity && Utils.Math.IsNotZero(Physics.gravity.y) && Utils.Math.IsZero(rigidbody.velocity.y);


        public virtual void Initialize(UnityEngine.Object target)
        {
        }


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


        public virtual void OnFixedUpdate(float dt)
        {

        }

        public virtual void OnUpdate(float dt)
        {

        }

        public virtual void OnLateUpdate(float dt)
        {

        }
    }

    [System.Serializable]
    public partial class ActorPhysicsComponent : PhysicsComponent
    {
        [SerializeField]
        private ActorPhysicsData physicsData;
        public ActorPhysicsData PhysicsData => physicsData;
        public float MoveSpeed => physicsData == null ? 0F : physicsData.moveSpeed.Get(targetActor.Status.Current);
        public float JumpPower => physicsData == null ? 0F : physicsData.jumpPower.Get(targetActor.Status.Current);

        private Actor targetActor;

        public override void Initialize(UnityEngine.Object target)
        {
            this.targetActor = target as Actor;
        }

        public void MoveTo(Vector3 pos)
        {
            targetActor.transform.position = pos;
        }
        public void MoveBy(Vector3 vec)
        {
            targetActor.transform.position += vec;
        }
        //public void Move(Vector3 pos) {
        //    targetActor.transform.Translate(pos);
        //}

        public void LocalMoveTo(Vector3 pos)
        {
            targetActor.transform.localPosition = pos;
        }
        public void LocalMoveBy(Vector3 vec)
        {
            targetActor.transform.localPosition += vec;
        }

        public override void OnFixedUpdate(float dt)
        {

        }

        public override void OnUpdate(float dt)
        {

        }

        public override void OnLateUpdate(float dt)
        {

        }
    }
}



#if UNITY_EDITOR
namespace Anomaly
{
    using UnityEditor;

    public partial class PhysicsComponent
    {
        public virtual void OnInspectorGUI(UnityEditor.Editor editor, SerializedProperty target)
        {
            GUILayout.BeginVertical("box");
            rigidbodies.OnInspectorGUI(editor, target.FindPropertyRelative(nameof(rigidbodies)), "Rigidbodies");
            GUILayout.Space(5);
            colliders.OnInspectorGUI(editor, target.FindPropertyRelative(nameof(colliders)), "Colliders");
            GUILayout.EndVertical();
        }
    }

    public partial class ActorPhysicsComponent
    {
        public override void OnInspectorGUI(UnityEditor.Editor editor, SerializedProperty target)
        {
            physicsData = EditorGUILayout.ObjectField("Physics Data", physicsData, typeof(ActorPhysicsData), false) as ActorPhysicsData;

            GUILayout.Space(5);

            base.OnInspectorGUI(editor, target);
        }
    }
}
#endif