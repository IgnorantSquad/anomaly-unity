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
public class SpineComponent : Anomaly.CustomComponent
{
    [System.Serializable]
    [SharedComponentData(typeof(SpineComponent))]
    public class Data : CustomComponent.BaseData
    {
        public SkeletonAnimation skeletonAnimation;

        //public Spine.AnimationState.TrackEntryDelegate onStartEvent, onEndEvent, onCompleteEvent;
    }


    public void AssignSkeletonAnimation(Data target, SkeletonAnimation sk)
    {
        target.skeletonAnimation = sk;
        RegisterEvents(target);
    }

    private void RegisterEvents(Data target)
    {
        //if (target.onStartEvent != null) target.skeletonAnimation.AnimationState.Start += target.onStartEvent;
        //if (target.onEndEvent != null) target.skeletonAnimation.AnimationState.End += target.onEndEvent;
        //if (target.onCompleteEvent != null) target.skeletonAnimation.AnimationState.Complete += target.onCompleteEvent;
    }


    public Spine.TrackEntry Play(Data target, AnimationTrack track, string name, bool loop = false)
    {
        return target.skeletonAnimation.AnimationState.SetAnimation((int)track, name, loop);
    }

    public Spine.TrackEntry PlayAfter(Data target, AnimationTrack track, string name, bool loop = false, float delay = 0F)
    {
        return target.skeletonAnimation.AnimationState.AddAnimation((int)track, name, loop, delay);
    }
}