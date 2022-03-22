using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    [CreateAssetMenu(fileName = "NewActorStatus", menuName = "Data/Actor/Status Data")]
    public class ActorStatus : ScriptableObject
    {
        public Utils.FlexibleValue HP;
        public Utils.FlexibleValue MP;
        public Utils.FlexibleValue Stamina;
    }
}



#if UNITY_EDITOR
namespace Anomaly.Editor
{
    using UnityEditor;

    [CustomEditor(typeof(ActorStatus))]
    public class ActorStatusEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var self = target as ActorStatus;

            self.HP.OnInspectorGUI("HP");
            self.MP.OnInspectorGUI("MP");
            self.Stamina.OnInspectorGUI("Stamina");
        }
    }
}
#endif
