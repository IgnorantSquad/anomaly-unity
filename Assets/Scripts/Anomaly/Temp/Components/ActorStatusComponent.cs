using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly.Temp
{
    [System.Serializable]
    public partial class ActorStatusComponent : IComponent
    {
        [SerializeField]
        private ActorStatus actorStatus;
        public ActorStatus Data => actorStatus;

        public void Initialize(Object target)
        {
        }

        public void OnFixedUpdate(float dt)
        {
        }

        public void OnLateUpdate(float dt)
        {
        }

        public void OnUpdate(float dt)
        {
        }
    }
}



#if UNITY_EDITOR
namespace Anomaly.Temp
{
    using UnityEditor;

    public partial class ActorStatusComponent
    {
        public void OnInspectorGUI(UnityEditor.Editor editor, SerializedProperty target)
        {
            actorStatus = EditorGUILayout.ObjectField("Status Data", actorStatus, typeof(ActorStatus), false) as ActorStatus;
        }
    }
}
#endif
