using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly.Temp
{
    public partial class Actor : MonoBehaviour, IUpdate
    {
        [SerializeField, HideInInspector]
        protected List<IComponent> components = new List<IComponent>();

        public BehaviorManagerComponent Behavior { get; protected set; }
        public ActorStatusComponent Status { get; protected set; }

        //public EventManager EventManager { get; protected set; }

        private void Awake()
        {
            OnInitialized();
        }

        protected virtual void RegisterComponents()
        {
            components.AddRange(new IComponent[] { new BehaviorManagerComponent(this), new ActorStatusComponent() });
            Behavior = components[0] as BehaviorManagerComponent;
            Status = components[1] as ActorStatusComponent;
        }

        protected void InitializeComponents()
        {
            for (int i = 0; i < components.Count; ++i)
            {
                components[i].Initialize(this);
            }
        }

        protected virtual void OnInitialized()
        {
            RegisterComponents();
            InitializeComponents();
        }


        public virtual void OnFixedUpdate(float dt)
        {
            for (int i = 0; i < components.Count; ++i)
            {
                components[i].OnFixedUpdate(dt);
            }
        }

        public virtual void OnUpdate(float dt)
        {
            for (int i = 0; i < components.Count; ++i)
            {
                components[i].OnUpdate(dt);
            }
        }

        public virtual void OnLateUpdate(float dt)
        {
            for (int i = 0; i < components.Count; ++i)
            {
                components[i].OnLateUpdate(dt);
            }
        }

    }
}



#if UNITY_EDITOR
namespace Anomaly.Temp
{
    public partial class Actor
    {
        public virtual void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedObject target)
        {
            for (int i = 0; i < components.Count; ++i)
            {
                components[i].OnInspectorGUI(editor, target.FindProperty(nameof(components)).GetArrayElementAtIndex(i));
            }
        }
    }
}

namespace Anomaly.Temp.Editor
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