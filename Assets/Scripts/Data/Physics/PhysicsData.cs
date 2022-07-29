using UnityEngine;

[CreateAssetMenu(fileName = "NewActorPhysicsData", menuName = "Data/Actor/Physics Data")]
public class PhysicsData : ScriptableObject
{
    [SerializeField, TextArea(3, 3)]
    private string description;

    [HideInInspector]
    public Anomaly.Utils.PolymorphValue<float> moveSpeed, jumpPower;
}
