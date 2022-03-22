using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Anomaly
{
    [System.Serializable]
    public partial class TransformComponent : CustomComponent
    {
        public void MoveTo(Vector3 pos)
        {
            target.transform.position = pos;
        }
        public void MoveBy(Vector3 vec)
        {
            target.transform.position += vec;
        }

        public void LocalMoveTo(Vector3 pos)
        {
            target.transform.localPosition = pos;
        }
        public void LocalMoveBy(Vector3 vec)
        {
            target.transform.localPosition += vec;
        }


#if UNITY_EDITOR
        public override void OnInspectorGUI(UnityEditor.Editor editor, SerializedProperty target)
        {
        }
#endif
    }
}
