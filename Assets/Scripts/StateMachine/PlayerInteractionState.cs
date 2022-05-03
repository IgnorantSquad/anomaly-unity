using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anomaly;


public class PlayerInteractionState : State
{
    public override Identity ID => State.Identity.PlayerInteraction;

    private TriggerListener trigger;

    public override void OnEnter(CustomObject target)
    {
        trigger = target.GetComponentInChildren<TriggerListener>();
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
        if (trigger == null) return;
        if (trigger.colliderList.Count == 0) return;
        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach (var coll in trigger.colliderList["Interactable"])
            {
                Managers.Event.AddEvent(EventPool.Get<HitEvent>(), new EventParam() { sender = target.gameObject, receiver = coll.gameObject });
                //(target as Actor).actorInteractor.Send(coll.GetComponent<Actor>(), new HitEvent(target as Actor, coll.GetComponent<Actor>()));
                //coll.GetComponent<Actor>().actorInteractor.Receive(target as Actor, new HitEvent(target as Actor, coll.GetComponent<Actor>()));
            }
        }

    }

    public override void OnLateUpdate(CustomObject target)
    {

    }
}
