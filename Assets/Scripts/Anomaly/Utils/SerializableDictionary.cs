using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Anomaly.Utils
{
    [System.Serializable]
    public class SerializableDictionary<_Typ> : ISerializationCallbackReceiver where _Typ : UnityEngine.Object
    {
        public SerializableDictionary() { }
        public SerializableDictionary(string defaultKey, _Typ defaultValue = null)
        {
            keyList.Add(defaultKey);
            valueList.Add(defaultValue);
            OnAfterDeserialize();
        } 
        public SerializableDictionary(IEnumerable<string> defaultKeys, IEnumerable<_Typ> defaultValues = null)
        {
            Debug.Assert(defaultKeys.Count() == defaultValues.Count());
            keyList.AddRange(defaultKeys);
            valueList.AddRange(defaultValues);
            OnAfterDeserialize();
        }

        public Dictionary<string, _Typ> Container { get; set; } = new Dictionary<string, _Typ>();

        [SerializeField]
        private List<string> keyList = new List<string>();
        [SerializeField]
        private List<_Typ> valueList = new List<_Typ>();

        public void OnAfterDeserialize()
        {
            Container.Clear();
            for (int i = 0; i < keyList.Count; ++i)
            {
                Container.Add(keyList[i], valueList[i]);
            }
            keyList = null;
            valueList = null;
        }

        public void OnBeforeSerialize()
        {
            keyList = Container.Keys.ToList();
            valueList = Container.Values.ToList();
        }

#if UNITY_EDITOR
        // Utils 클래스 같은걸로 묶어도 좋을듯
        public void OnInspectorGUI(Object target, string fieldName = "")
        {
            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label(fieldName);
            if (GUILayout.Button("+", GUILayout.Width(40)))
            {
                Container.Add(Container.Count.ToString(), null);
            }
            EditorGUILayout.EndHorizontal();

            OnBeforeSerialize();

            EditorGUI.BeginChangeCheck();

            for (int i = 0; i < keyList.Count; ++i)
            {
                EditorGUILayout.BeginHorizontal();
                keyList[i] = EditorGUILayout.TextField(keyList[i], GUILayout.Width(120));
                valueList[i] = EditorGUILayout.ObjectField(valueList[i], typeof(_Typ), true) as _Typ;
                GUILayout.Space(40);
                Color prevColor = GUI.backgroundColor;
                GUI.backgroundColor = Color.red;
                if (GUILayout.Button("-", GUILayout.Width(40)))
                {
                    keyList.RemoveAt(i);
                    valueList.RemoveAt(i);
                    i--;
                }
                GUI.backgroundColor = prevColor;
                EditorGUILayout.EndHorizontal();
            }

            if (EditorGUI.EndChangeCheck())
            {
                OnAfterDeserialize();
            }

            EditorGUILayout.EndVertical();
        }
#endif
    }
}