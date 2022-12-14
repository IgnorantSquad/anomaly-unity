using Anomaly.Utils;
using UnityEngine;


// TODO: Refactoring
public partial class PhysicsComponent : Anomaly.CustomComponent
{
    [SerializeField]
    private PhysicsData physicsData;
    public PhysicsData CurrentPhysicsData => physicsData;

    [SerializeField]
    protected SerializableDictionary<Rigidbody> rigidbodies = new SerializableDictionary<Rigidbody>("Main", null);
    [SerializeField]
    protected SerializableDictionary<Collider> colliders = new SerializableDictionary<Collider>("Main", null);

    public Rigidbody rigidbody => rigidbodies == null ? null : rigidbodies.Container["Main"];
    //public Collider collider => colliders == null ? null : colliders.Container["Main"];

    //public bool IsGrounded { get; private set; } = false;
    public bool IsGrounded => rigidbody.useGravity && Math.IsNotZero(Physics.gravity.y) && Math.IsZero(rigidbody.velocity.y);


    public void Move(Vector3 dir, string name = "Main")
    {
        var rb = rigidbodies.Container[name];
        //rb.velocity = dir;
        rb.MovePosition(rb.transform.position + dir);
    }

    public void AddForce(Vector3 power, ForceMode forceMode = ForceMode.Force, string name = "Main")
    {
        rigidbodies.Container[name].AddForce(power, forceMode);
    }
    public void AddForce(Vector3 dir, float power, ForceMode forceMode = ForceMode.Force, string name = "Main")
    {
        AddForce(dir * power, forceMode, name);
    }

    public void AddForceAtPosition(Vector3 power, Vector3 position, ForceMode forceMode = ForceMode.Force, string name = "Main")
    {
        rigidbodies.Container[name].AddForceAtPosition(power, position, forceMode);
    }
    public void AddForceAtPosition(Vector3 dir, float power, Vector3 position, ForceMode forceMode = ForceMode.Force, string name = "Main")
    {
        AddForceAtPosition(dir * power, position, forceMode, name);
    }

    public void Stop(string name = "Main")
    {
        rigidbodies.Container[name].velocity = Vector3.zero;
    }
}