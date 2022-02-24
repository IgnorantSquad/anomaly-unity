namespace Anomaly
{
    public interface IComponent : IUpdate
    {
        void Initialize(UnityEngine.Object target);

#if UNITY_EDITOR
        void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedProperty target);
#endif
    }
}