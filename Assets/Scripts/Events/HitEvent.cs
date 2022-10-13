using Anomaly;
using UnityEngine;


public class TestInteractEvent : Anomaly.BaseEvent
{
    public override void Invoke()
    {
        Debug.Log($"{sender.name} interact {receiver.name}");
    }
}
