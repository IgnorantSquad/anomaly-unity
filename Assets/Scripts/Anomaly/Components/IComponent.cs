namespace Anomaly
{
    public interface IComponent
    {
        void Initialize(Actor actor);

#if UNITY_EDITOR
        void OnInspectorGUI(UnityEngine.Object target);
#endif
    }
}