using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anomaly;


public class PlayerInteractionState : State
{
    public override Identity ID => State.Identity.PlayerInteraction;

    private TriggerListListener triggerList;


    public override void OnEnter(CustomObject target)
    {
        triggerList = target.GetComponentInChildren<TriggerListListener>();
    }

    public override void OnExit(CustomObject target)
    {
    }


    public override bool IsTransition(out Identity next)
    {
        next = Identity.None;
        return false;
    }


    public override void OnFixedUpdate(CustomObject target)
    {
    }

    public override void OnUpdate(CustomObject target)
    {
        if (triggerList == null) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < triggerList.List.Count; ++i)
            {
                if (triggerList.List[i].tag != "Interactable") continue;
                Managers.Event.AddEvent(EventPool.Get<HitEvent>(), new EventParam() { sender = target.gameObject, receiver = triggerList.List[i].gameObject });
            }
        }
    }

    public override void OnLateUpdate(CustomObject target)
    {
    }
}
