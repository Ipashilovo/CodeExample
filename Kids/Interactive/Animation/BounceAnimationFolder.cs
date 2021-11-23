using DG.Tweening;
using Move.Animation;
using Player;
using UnityEngine;

namespace Interactive.Animation
{
    public class BounceAnimationFolder : AnimationFolder
    {
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private int _vibrato = 4;
        [SerializeField] private float _scale = 0.1f;
        
        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            transform.DOPunchScale(new Vector3(_scale, _scale, _scale), _duration, _vibrato).OnComplete(Notify);
        }
    }
}