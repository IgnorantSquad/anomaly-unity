using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{

    public class UpdateManager : MonoBehaviour
    {
        private static Utils.LList<IUpdate> updateList = new Utils.LList<IUpdate>();
        private static HashSet<IUpdate> deleteQueue;

        public static void Register(IUpdate inst)
        {
            updateList.Add(inst);
        }

        public static void Unregister(IUpdate inst)
        {
            if (deleteQueue.Contains(inst))
            {
                Debug.Log($"Already in Queue");
                return;
            }
            deleteQueue.Add(inst);
        }


        private void FixedUpdate()
        {
            updateList.Foreach(inst =>
            {
                inst?.OnFixedUpdate(Time.fixedDeltaTime);
            });
        }

        private void Update()
        {
            updateList.Foreach(inst =>
            {
                inst?.OnUpdate(Time.deltaTime);
            });
        }

        private void LateUpdate()
        {
            updateList.Foreach(inst =>
            {
                inst?.OnLateUpdate(Time.deltaTime);
            });
        }
    }

}
