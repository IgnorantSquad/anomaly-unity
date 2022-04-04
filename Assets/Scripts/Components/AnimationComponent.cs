using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimationComponent : Anomaly.CustomComponent
{



#if UNITY_EDITOR
    public override void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedProperty target)
    {

    }
#endif
}