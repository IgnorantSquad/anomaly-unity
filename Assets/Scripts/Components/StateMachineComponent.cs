using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anomaly;

[System.Serializable]
public class StateMachineComponent : CustomComponent
{
    private List<State> states = new List<State>();
    public State CurrentState { get; private set; }

    public void AddStates(params State[] states)
    {
        this.states.AddRange(states);
    }

    public void Run(int entryIndex = 0)
    {
        Debug.Assert(entryIndex >= 0 && entryIndex < states.Count);
        ChangeState(entryIndex);
    }

    public void ChangeState(State.Identity id)
    {
        ChangeState(states.FindIndex(s => s.ID == id));
    }

    public void ChangeState(int index)
    {
        CurrentState?.OnExit(target);
        CurrentState = states[index];
        CurrentState?.OnEnter(target);
    }

    public void OnFixedUpdate() => CurrentState?.OnFixedUpdate(target);
    public void OnUpdate() => CurrentState?.OnUpdate(target);
    public void OnLateUpdate() => CurrentState?.OnLateUpdate(target);


#if UNITY_EDITOR
    public override void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedProperty target)
    {

    }
#endif
}
