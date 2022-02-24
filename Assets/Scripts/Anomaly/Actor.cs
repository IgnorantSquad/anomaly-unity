using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    public partial class Actor : MonoBehaviour, IUpdate
    {
        public BehaviorManager Behavior { get; protected set; }
        public ActorStatus Status { get; protected set; }


        private void Awake()
        {
            Behavior = new BehaviorManager(this);
            Status = new ActorStatus();

            OnInitialized();
        }


        protected virtual void OnInitialized()
        {
        }


        public void OnFixedUpdate(float dt)
        {
            Behavior.OnFixedUpdate(dt);
        }

        public void OnUpdate(float dt)
        {
            Behavior.OnUpdate(dt);
        }

        public void OnLateUpdate(float dt)
        {
            Behavior.OnLateUpdate(dt);
        }

    }
}



#if UNITY_EDITOR
namespace Anomaly
{
    public partial class Actor
    {
        public virtual void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedObject target)
        {
            GUILayout.Label("Actor");
        }
    }
}

namespace Anomaly.Editor
{
    using UnityEditor;

    [CustomEditor(typeof(Actor), true)]
    public class ActorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var self = target as Actor;

            GUILayout.Space(10);

            EditorGUI.BeginChangeCheck();
            self.OnInspectorGUI(this, serializedObject);
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(target);
                UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(self.gameObject.scene);
            }
        }
    }
}
#endif