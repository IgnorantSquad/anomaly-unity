using Anomaly;
using UnityEngine;


public class HitEvent : Anomaly.BaseEvent
{
    public override void Invoke(EventParam param)
    {
        Debug.Log($"{param.sender.name} hit {param.receiver.name}");
    }
}
