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


    public CollisionFlags Move(Vector3 move) 
    {
        return (latestFlag = controller.Move(move));
    }

    public Vector3 GetSlideVector(float slideSpeed)
    {
        var transform = target.transform;

        float radius = controller.radius * transform.localScale.x;
        float height = controller.height * transform.localScale.y;
        Vector3 center = new Vector3(controller.center.x * transform.localScale.x, controller.center.y * transform.localScale.y, controller.center.z * transform.localScale.z);

        Vector3 std = transform.position + center - transform.up * (height - 1F) * 0.5f;

        bool cast = Physics.SphereCast(transform.position + center, radius, -transform.up, out var hit, (height - 1F) * 0.5f + radius) && !Physics.Raycast(std, -transform.up, radius * 1.5f);
        Debug.DrawRay(transform.position, -transform.up * ((height - 1F) * 0.5f + radius), Color.blue);
        if (!cast) return Vector3.zero;

        float cos = Mathf.Max(Vector3.Dot(-transform.up, (hit.point - std).normalized), 0.01f);

        float dot = Vector3.Dot(Vector3.Cross(hit.point - std, -transform.up), transform.forward);

        float threshold = Mathf.Pow(Mathf.Sin(Mathf.Acos(cos)), 0.1f);

        return (transform.right * Mathf.Sign(dot) - transform.up) * threshold * Time.fixedDeltaTime * slideSpeed;
    }

    public void CalculateGravity() 
    {
        gravityValue += gravityScale * Time.fixedDeltaTime * Physics.gravity.y;
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
