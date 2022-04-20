using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anomaly;
using Cinemachine;

[System.Serializable]
public class CameraComponent : CustomComponent
{
    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    private Transform cameraHandle;


    #region Camera Transform
    public void SetCameraHandlePosition(Vector3 pos) 
    {
        cameraHandle.localPosition = pos;
    }
    #endregion


    public void SetOrthographicSize(float ortho = 7F) 
    {
        virtualCamera.m_Lens.OrthographicSize = ortho;
    }

    public void SetCameraBound(CompositeCollider2D coll) 
    {
        virtualCamera.GetComponent<CinemachineConfiner>().m_BoundingShape2D = coll;
    }


#if UNITY_EDITOR
    public override void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedProperty target)
    {
        GUILayout.Space(5);
        GUILayout.BeginVertical("box");
        GUILayout.Label("Camera");

        virtualCamera = UnityEditor.EditorGUILayout.ObjectField(virtualCamera, typeof(CinemachineVirtualCamera), true) as CinemachineVirtualCamera;
        cameraHandle = UnityEditor.EditorGUILayout.ObjectField(cameraHandle, typeof(Transform), true) as Transform;

        GUILayout.EndVertical();
        GUILayout.Space(5);
    }
#endif
}
