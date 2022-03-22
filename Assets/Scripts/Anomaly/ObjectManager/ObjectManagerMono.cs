using UnityEngine;

namespace Anomaly
{
    public class ObjectManagerMono : MonoBehaviour
    {
        [SerializeField]
        private int targetFrame = -1;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void AfterSceneLoaded()
        {
            QualitySettings.vSyncCount = 0;
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }


        void Start()
        {
            DontDestroyOnLoad(gameObject);
            Application.targetFrameRate = targetFrame;
        }


        void FixedUpdate()
        {
            ObjectManager.FixedUpdate();
        }

        void Update()
        {
            ObjectManager.Update();
        }

        void LateUpdate()
        {
            ObjectManager.LateUpdate();
        }
    }
}