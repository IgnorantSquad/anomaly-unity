using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    [System.Serializable]
    public class AnimationComponent : CustomComponent
    {



#if UNITY_EDITOR
        public override void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedProperty target)
        {

        }
#endif
    }
}