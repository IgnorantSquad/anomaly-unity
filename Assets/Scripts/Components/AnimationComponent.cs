using UnityEngine;
using Spine.Unity;
using Anomaly;

public enum AnimationTrack
{
    BASE = 0,
    UPPER_BODY = 1,
    HAND = 2,
    HEAD = 3
}

[System.Serializable]
public class AnimationComponent : Anomaly.CustomComponent
{
    [SerializeField]
    private SkeletonAnimation skeletonAnimation;

    public Spine.AnimationState.TrackEntryDelegate onStartEvent, onEndEvent, onCompleteEvent;


    public override void Initialize(CustomBehaviour target)
    {
        base.Initialize(target);
        if (skeletonAnimation == null) return;
        RegisterEvents();
    }

    public void AssignSkeletonAnimation(SkeletonAnimation sk)
    {
        skeletonAnimation = sk;
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        if (onStartEvent != null) skeletonAnimation.AnimationState.Start += onStartEvent;
        if (onEndEvent != null) skeletonAnimation.AnimationState.End += onEndEvent;
        if (onCompleteEvent != null) skeletonAnimation.AnimationState.Complete += onCompleteEvent;
    }


    public Spine.TrackEntry Play(AnimationTrack track, string name, bool loop = false)
    {
        return skeletonAnimation.AnimationState.SetAnimation((int)track, name, loop);
    }

    public Spine.TrackEntry PlayAfter(AnimationTrack track, string name, bool loop = false, float delay = 0F)
    {
        return skeletonAnimation.AnimationState.AddAnimation((int)track, name, loop, delay);
    }


#if UNITY_EDITOR
    public override void OnInspectorGUI(UnityEditor.Editor editor, UnityEditor.SerializedProperty target)
    {
        GUILayout.Space(5);
        GUILayout.BeginVertical("box");
        GUILayout.Label("Animation");
        skeletonAnimation = UnityEditor.EditorGUILayout.ObjectField(skeletonAnimation, typeof(SkeletonAnimation), true) as SkeletonAnimation;
        GUILayout.EndVertical();
        GUILayout.Space(5);
    }
#endif
}