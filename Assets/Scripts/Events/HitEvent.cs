using UnityEngine;


public class HitEvent : Anomaly.BaseEvent
{
    public HitEvent(Actor sender, Actor receiver) : base(sender, receiver)
    {
    }

    public override void Invoke()
    {
        Debug.Log($"{sender.name} hit {receiver.name}");
    }
}
