using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anomaly;
using Cinemachine;


public class CameraComponent : CustomComponent
{
    [System.Serializable]
    [SharedComponentData(typeof(CameraComponent))]
    public class Data : CustomComponent.BaseData
    {
        public CinemachineVirtualCamera virtualCamera;

        public Transform cameraHandle;
    }


    #region Camera Transform
    public void SetCameraHandlePosition(Data target, Vector3 pos)
    {
        target.cameraHandle.localPosition = pos;
    }
    #endregion


    public void SetOrthographicSize(Data target, float ortho = 7F)
    {
        target.virtualCamera.m_Lens.OrthographicSize = ortho;
    }

    public void SetCameraBound(Data target, CompositeCollider2D coll)
    {
        target.virtualCamera.GetComponent<CinemachineConfiner>().m_BoundingShape2D = coll;
    }
}
