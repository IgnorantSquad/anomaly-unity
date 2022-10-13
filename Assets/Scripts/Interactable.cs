using System;
using System.Collections;
using System.Collections.Generic;
using Anomaly;
using UnityEngine;

public class Interactable : Anomaly.CustomBehaviour
{
    public override void OnEventReceived(BaseEvent e, Type t)
    {
        Debug.Log($"{e.receiver.name} was interacted by {e.sender.name}");
    }
}
