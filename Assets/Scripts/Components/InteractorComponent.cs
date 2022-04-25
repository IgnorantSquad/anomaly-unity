using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anomaly;

public class InteractorComponent : CustomComponent
{
    private Queue<BaseEvent> messageQueue = new Queue<BaseEvent>();

    public void Send(Actor receiver, BaseEvent e)
    {
        //receiver.actorInteractor.messageQueue.Enqueue(e);
    }
    public void Receive(Actor sender, BaseEvent e)
    {
        //sender.actorInteractor.Send(target as Actor, e);
    }

    public void OnUpdate()
    {
        // while (messageQueue.Count > 0)
        // {
        //     messageQueue.Dequeue().Invoke();
        // }
    }

#if UNITY_EDITOR
    public override void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedProperty target)
    {
    }
#endif
}