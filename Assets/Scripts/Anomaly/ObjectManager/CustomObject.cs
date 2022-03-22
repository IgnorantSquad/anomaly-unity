using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Anomaly
{
    public class CustomObject : MonoBehaviour
    {

        [System.NonSerialized] public bool cachedActiveFlag = false;

        GameObject _gameObject = null;
        new public GameObject gameObject
        {
            get
            {
                if (_gameObject == null) return base.gameObject;
                return _gameObject;
            }
        }

        Transform _transform = null;
        new public Transform transform
        {
            get
            {
                if (_transform == null) return base.transform;
                return _transform;
            }
        }


        void Awake()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            MethodInfo GetMethod(string methodName)
            {
                return GetType()
                    .GetMethod(methodName,
                            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            }
            bool IsValidMagicFunction(MethodInfo method)
            {
                return method != null
                    && method.GetParameters().Length == 0
                    && method.ReturnType == typeof(void);
            }

            _gameObject = base.gameObject;
            _transform = base.transform;

            var self = this;

            if (IsValidMagicFunction(GetMethod("OnStart")))
            {
                ObjectManager.Register(this, GetMethod("OnStart"), ObjectManager.EFunctionType.START);
            }
            if (IsValidMagicFunction(GetMethod("OnActivate")))
            {
                ObjectManager.Register(this, GetMethod("OnActivate"), ObjectManager.EFunctionType.ACTIVATE);
            }
            if (IsValidMagicFunction(GetMethod("OnDeactivate")))
            {
                ObjectManager.Register(this, GetMethod("OnDeactivate"), ObjectManager.EFunctionType.DEACTIVATE);
            }
            if (IsValidMagicFunction(GetMethod("OnFixedUpdate")))
            {
                ObjectManager.Register(this, GetMethod("OnFixedUpdate"), ObjectManager.EFunctionType.FIXEDUPDATE);
            }
            if (IsValidMagicFunction(GetMethod("OnISOFixedUpdate")))
            {
                ObjectManager.Register(this, GetMethod("OnISOFixedUpdate"), ObjectManager.EFunctionType.FIXEDUPDATE_ISO);
            }
            if (IsValidMagicFunction(GetMethod("OnUpdate")))
            {
                ObjectManager.Register(this, GetMethod("OnUpdate"), ObjectManager.EFunctionType.UPDATE);
            }
            if (IsValidMagicFunction(GetMethod("OnISOUpdate")))
            {
                ObjectManager.Register(this, GetMethod("OnISOUpdate"), ObjectManager.EFunctionType.UPDATE_ISO);
            }
            if (IsValidMagicFunction(GetMethod("OnLateUpdate")))
            {
                ObjectManager.Register(this, GetMethod("OnLateUpdate"), ObjectManager.EFunctionType.LATEUPDATE);
            }
            if (IsValidMagicFunction(GetMethod("OnISOLateUpdate")))
            {
                ObjectManager.Register(this, GetMethod("OnISOLateUpdate"), ObjectManager.EFunctionType.LATEUPDATE_ISO);
            }
        }


#if UNITY_EDITOR
        public virtual void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedObject serializedObject)
        {

        }
#endif
    }
}


#if UNITY_EDITOR
namespace Anomaly.Editor
{
    using UnityEditor;

    [CustomEditor(typeof(CustomObject), true)]
    public class CustomObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUI.BeginChangeCheck();
            (target as CustomObject).OnInspectorGUI(this, serializedObject);
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(target);
                UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty((target as CustomObject).gameObject.scene);
            }
        }
    }
}
#endif
