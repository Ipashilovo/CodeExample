using DG.Tweening;
using UnityEngine;

namespace Gun.GunShootAnimations
{
    public class RecoilAnimation : GunShootAnimation
    {
        [SerializeField] private float _firstAnimationScale;
        [SerializeField] private float _moveScale;

        public override void Animate(float time)
        {
            float fistTime = time / _firstAnimationScale;
            Vector3 currentPosition = transform.localPosition;
            DOTween.Sequence().Append(transform.DOMove(transform.position - transform.forward/_moveScale, fistTime))
                .Append(transform.DOLocalMove(currentPosition, time - fistTime));
        }
    }
}