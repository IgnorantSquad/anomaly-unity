using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    public class Actor : CustomObject
    {
        public BehaviorComponent Behavior { get; set; }


        void OnFixedUpdate()
        {
            Behavior.OnFixedUpdate();
        }
        void OnUpdate()
        {
            Behavior.OnUpdate();
        }
        void OnLateUpdate()
        {
            Behavior.OnLateUpdate();
        }
    }
}