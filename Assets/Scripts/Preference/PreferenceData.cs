using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Anomaly/Preference", fileName = "Preference")]
public class PreferenceData : ScriptableObject
{
    [Header("Optimization")]
    public int targetFrameRate = 60;
    public int vSyncCount = 0;

    [Header("Cursor")]
    public bool isCursorVisible = true;
    public CursorLockMode cursorLockMode = CursorLockMode.None;
}
