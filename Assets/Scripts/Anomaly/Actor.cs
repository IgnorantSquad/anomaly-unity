using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    public class Actor : MonoBehaviour
    {
        [SerializeField]
        private string guid = System.Guid.NewGuid().ToString();
        public string GUID => guid;

#if UNITY_EDITOR
        public virtual void OnInspectorGUI(Object target)
        {
            GUILayout.Label("Actor");
        }
#endif
    }

#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(Actor), true)]
    public class ActorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var self = target as Actor;

            GUILayout.BeginHorizontal("box");
            GUILayout.FlexibleSpace();
            GUILayout.Label(self.GUID);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            UnityEditor.EditorGUI.BeginChangeCheck();
            self.OnInspectorGUI(target);
            if (UnityEditor.EditorGUI.EndChangeCheck())
            {
                UnityEditor.EditorUtility.SetDirty(target);
                UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(self.gameObject.scene);
            }
        }
    }
#endif 

    public class ActorSpawner : MonoBehaviour
    {
        [SerializeField]
        private Actor[] actors;

        public Actor Spawn(int index = -1)
        {
            if (index < 0) index = Random.Range(0, actors.Length);

            return Instantiate(actors[index]);
        }
    }
}
