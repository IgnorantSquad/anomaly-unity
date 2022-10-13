using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anomaly;


public class PlayerInteractionState : State<Player>
{
    public override StateID ID => StateID.PlayerInteraction;


    public override void OnEnter(Player target)
    {
    }

    public override void OnExit(Player target)
    {
    }


    public override bool IsTransition(Player target, out StateID next)
    {
        next = StateID.None;
        return false;
    }


    public override void OnFixedUpdate(Player target)
    {
    }

    public override void OnUpdate(Player target)
    {
        if (target.Entry == null) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach (var collider in target.Entry.EntryList)
            {
                var interactable = collider.gameObject.GetComponent<Interactable>();
                if (interactable == null) continue;
                target.SendEvent<TestInteractEvent>(to: interactable, new TestInteractEvent());
                break;
            }
        }
    }

    public override void OnLateUpdate(Player target)
    {
    }
}
