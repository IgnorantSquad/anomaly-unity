using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anomaly;

[System.Serializable]
public class CharacterComponent : CustomComponent
{
    [System.Serializable]
    [SharedComponentData(typeof(CharacterComponent))]
    public class Data : CustomComponent.BaseData
    {
        public float gravityValue = 0F;
    
        public float gravityScale = 1F;

        public CharacterController controller;

        public PhysicsData physicsData;


        public bool IsGrounded => controller.isGrounded;
    
        public bool IsCollidedAbove => (controller.collisionFlags & CollisionFlags.CollidedAbove) != 0;
        public bool IsCollidedBelow => (controller.collisionFlags & CollisionFlags.CollidedBelow) != 0;
        public bool IsCollidedSide => (controller.collisionFlags & CollisionFlags.Sides) != 0;
    }


    public CollisionFlags Move(Data target, Vector3 move) 
    {
        return target.controller.Move(move);
    }

    public Vector3 GetSlideVector(Data target, Transform actor, float slideSpeed)
    {
        var transform = actor.transform;

        float radius = target.controller.radius * transform.localScale.x;
        float height = target.controller.height * transform.localScale.y;
        Vector3 center = new Vector3(target.controller.center.x * transform.localScale.x, target.controller.center.y * transform.localScale.y, target.controller.center.z * transform.localScale.z);

        Vector3 std = transform.position + center - transform.up * (height - 1F) * 0.5f;

        bool cast = Physics.SphereCast(transform.position + center, radius, -transform.up, out var hit, (height - 1F) * 0.5f + radius) && !Physics.Raycast(std, -transform.up, radius * 1.5f);
        Debug.DrawRay(transform.position, -transform.up * ((height - 1F) * 0.5f + radius), Color.blue);
        if (!cast) return Vector3.zero;

        float cos = Mathf.Max(Vector3.Dot(-transform.up, (hit.point - std).normalized), 0.01f);

        float dot = Vector3.Dot(Vector3.Cross(hit.point - std, -transform.up), transform.forward);

        float threshold = Mathf.Pow(Mathf.Sin(Mathf.Acos(cos)), 0.1f);

        return (transform.right * Mathf.Sign(dot) - transform.up) * threshold * Time.fixedDeltaTime * slideSpeed;
    }

    public void CalculateGravity(Data target) 
    {
        target.gravityValue += target.gravityScale * Time.fixedDeltaTime * Physics.gravity.y;
    }
}
