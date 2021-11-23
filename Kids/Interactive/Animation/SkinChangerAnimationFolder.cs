using System.Collections;
using Move.Animation;
using Player;
using UnityEngine;

namespace Interactive.Animation
{
    public class SkinChangerAnimationFolder : AnimationFolder
    {
        [SerializeField] private float _startDelay = 1f;
        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            StartCoroutine(AnimateAfterDelay(skeletonHandler));
        }

        private IEnumerator AnimateAfterDelay(ISkeletonHandler skeletonHandler)
        {
            yield return new WaitForSeconds(_startDelay);
            skeletonHandler.GetSkinHandler().SetRandomSkin();
        }
    }
}