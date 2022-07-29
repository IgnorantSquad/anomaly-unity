using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anomaly.Utils;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "NewActorStatus", menuName = "Data/Actor/Status Data")]
public class ActorStatus : ScriptableObject
{
    public FlexibleValue HP;
    public FlexibleValue MP;
    public FlexibleValue Stamina;
}




#if UNITY_EDITOR

[CustomEditor(typeof(ActorStatus))]
public class ActorStatusEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var self = target as ActorStatus;
    }
}

#endif
