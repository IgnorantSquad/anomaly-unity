using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anomaly;

public class Room : CustomBehaviour
{
    [SerializeField]
    private CompositeCollider2D cameraBoundary;

    [SerializeField]
    private List<RoomConnector> connectors = new List<RoomConnector>();


    public void OnEnter(params object[] args) 
    {

    }

    public void OnExit() 
    {

    }



    #if UNITY_EDITOR
    public override void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedObject serializedObject, UnityEditor.SerializedProperty targetProperty)
    {
        base.OnInspectorGUI(editor, serializedObject, targetProperty);
    }
    #endif
}
