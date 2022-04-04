using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    [CreateAssetMenu(fileName = "NewActorPhysicsData", menuName = "Data/Actor/Physics Data")]
    public class PhysicsData : ScriptableObject
    {
        [SerializeField, TextArea(3, 3)]
        private string description;

        [HideInInspector]
        public Utils.PolymorphValue<float> moveSpeed, jumpPower;
    }
}


#if UNITY_EDITOR
namespace Anomaly.Editor
{
    using UnityEditor;

    [CustomEditor(typeof(PhysicsData), true)]
    public class ActorPhysicsDataEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(10);

            var self = target as PhysicsData;

            EditorGUI.BeginChangeCheck();

            self.moveSpeed.OnInspectorGUI(this, serializedObject.FindProperty(nameof(self.moveSpeed)), "Move Speed");
            GUILayout.Space(5);
            self.jumpPower.OnInspectorGUI(this, serializedObject.FindProperty(nameof(self.jumpPower)), "Jump Power");

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(target);
            }
        }
    }
}
#endif