using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{

    public class UpdateManager : MonoBehaviour
    {
        private static UpdateManager instance = null;
        public static UpdateManager Instance
        {
            get
            {
                if (instance != null) return instance;
                instance = GameObject.FindObjectOfType<UpdateManager>();
                return instance;
            }
        }

        private List<IUpdate> updateList = new List<IUpdate>();
        private HashSet<IUpdate> deleteQueue;

        public void Register(IUpdate inst)
        {
            updateList.Add(inst);
        }

        public void Unregister(IUpdate inst)
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
            for (int i = 0; i < updateList.Count; ++i)
            {
                updateList[i]?.OnFixedUpdate(Time.fixedDeltaTime);
            }
        }

        private void Update()
        {
            for (int i = 0; i < updateList.Count; ++i)
            {
                updateList[i]?.OnUpdate(Time.deltaTime);
            }
        }

        private void LateUpdate()
        {
            for (int i = 0; i < updateList.Count; ++i)
            {
                updateList[i]?.OnUpdate(Time.deltaTime);
            }
        }
    }

}
