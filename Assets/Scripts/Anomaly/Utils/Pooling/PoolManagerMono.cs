using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly.Utils
{
    public class PoolManagerMono : CustomObject
    {

        [SerializeField] PoolObject[] prefabs;

        void OnActivate()
        {
            PoolManager.Instance.Init(prefabs);
        }

    }
}