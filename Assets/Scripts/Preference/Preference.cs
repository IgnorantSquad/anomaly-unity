using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anomaly;


    public class Preference : CustomBehaviour
    {
        public static Preference Instance { get; private set; }

        [SerializeField]
        private PreferenceData setting;

        public PreferenceData Current
        {
            get { return setting; }
            set
            {
                setting = value;
                OnSettingChanged();
            }
        }


        void OnSettingChanged()
        {
            Application.targetFrameRate = setting.targetFrameRate;

            QualitySettings.vSyncCount = setting.vSyncCount;

            Cursor.visible = setting.isCursorVisible;
            Cursor.lockState = setting.cursorLockMode;
        }


        protected override void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
            OnSettingChanged();
        }

        private void Start()
        {
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Environment");
        }
    }