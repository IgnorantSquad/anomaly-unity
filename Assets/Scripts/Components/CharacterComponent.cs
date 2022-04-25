using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anomaly;

[System.Serializable]
public class CharacterComponent : CustomComponent
{
    private float gravityValue = 0F;
    [SerializeField]
    private float gravityScale = 1F;

    [SerializeField]
    private CharacterController controller;

    private CollisionFlags latestFlag;


    [SerializeField]
    private PhysicsData physicsData;
    public PhysicsData CurrentPhysicsData => physicsData;


    public bool IsGrounded => controller.isGrounded;
    
    public bool IsCollidedAbove => (latestFlag & CollisionFlags.CollidedAbove) != 0;
    public bool IsCollidedBelow => (latestFlag & CollisionFlags.CollidedBelow) != 0;
    public bool IsCollidedSide => (latestFlag & CollisionFlags.Sides) != 0;


    public float GravityValue => gravityValue;
    public float DeltaGravityValue => gravityScale * Time.fixedDeltaTime * Physics.gravity.y * 0.02f; // threshold


    public CollisionFlags Move(Vector3 move) 
    {
        latestFlag = controller.Move(move);
        return latestFlag;
    }

    public Vector3 GetGravityVector() 
    {
        gravityValue += DeltaGravityValue;
        //if (IsGrounded) gravityValue = 0F;
        return Vector3.up * gravityValue;
    }
    public void CalculateGravity() 
    {
        if (IsGrounded) gravityValue = 0F;
    }


    public void SetGravityValue(float v) 
    {
        gravityValue = v;
    }
    
    public void SetGravityScale(float s)
    {
        gravityScale = s;
    }


#if UNITY_EDITOR
    public override void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedProperty target)
    {
        GUILayout.Space(5);

        GUILayout.BeginVertical("box");
        GUILayout.Label("Physics Data");
        physicsData = UnityEditor.EditorGUILayout.ObjectField(physicsData, typeof(PhysicsData), true) as PhysicsData;
        GUILayout.EndVertical();

        GUILayout.BeginVertical("box");
        GUILayout.Label("Character Controller");
        controller = UnityEditor.EditorGUILayout.ObjectField(controller, typeof(CharacterController), true) as CharacterController;
        GUILayout.EndVertical();

        GUILayout.Space(5);

        GUILayout.BeginVertical("box");
        GUILayout.Label("Gravity Scale");
        gravityScale = UnityEditor.EditorGUILayout.FloatField(gravityScale);
        GUILayout.EndVertical();

        GUILayout.Space(5);
    }
#endif
}
