namespace Anomaly
{
    public abstract class CustomComponent
    {
        protected CustomObject target;

        public void Initialize(CustomObject target)
        {
            this.target = target;
        }

#if UNITY_EDITOR
        public abstract void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedProperty target);
#endif
    }
}