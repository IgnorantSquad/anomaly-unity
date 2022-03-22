using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Anomaly
{
    public enum BehaviorType
    {
        BASIC_LOCOMOTION
    }

    public class BehaviorComponent : CustomComponent
    {
        private Dictionary<BehaviorType, IBehavior> behaviorDictionary = new Dictionary<BehaviorType, IBehavior>();
        private IBehavior baseBehavior;

        private Actor targetActor;

        public void SetTargetActor(Actor actor)
        {
            this.targetActor = actor;
        }

        public void RegisterBehaviors(params (BehaviorType, IBehavior)[] list)
        {
            for (int i = 0; i < list.Length; ++i)
            {
                behaviorDictionary.Add(list[i].Item1, list[i].Item2);
            }
        }

        public void SetBehavior(IBehavior behavior)
        {
            baseBehavior?.OnExit(targetActor);
            baseBehavior = behavior;
            baseBehavior?.OnEnter(targetActor);
        }
        public void SetBehavior(BehaviorType type)
        {
            baseBehavior?.OnExit(targetActor);
            baseBehavior = behaviorDictionary[type];
            baseBehavior?.OnEnter(targetActor);
        }

        public void StopBehavior()
        {
            baseBehavior?.OnExit(targetActor);
            baseBehavior = null;
        }


        public void OnFixedUpdate()
        {
            baseBehavior?.OnFixedUpdate(targetActor, Time.fixedDeltaTime);
        }
        public void OnUpdate()
        {
            baseBehavior?.OnUpdate(targetActor, Time.deltaTime);
        }
        public void OnLateUpdate()
        {
            baseBehavior?.OnLateUpdate(targetActor, Time.deltaTime);
        }


#if UNITY_EDITOR
        public override void OnInspectorGUI(UnityEditor.Editor editor, SerializedProperty target)
        {
        }
#endif
    }
}