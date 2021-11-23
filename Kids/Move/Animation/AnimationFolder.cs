using System;
using System.Collections;
using Player;
using UnityEngine;

namespace Move.Animation
{
    public abstract class AnimationFolder : MonoBehaviour
    {
        public event Action Ended;

        public abstract void Animate(ISkeletonHandler skeletonHandler);

        protected void Notify()
        {
            Ended?.Invoke();
        }
        
        protected IEnumerator NotifyAfterDelay(float time)
        {
            yield return new WaitForSeconds(time);
            Notify();
        }
    }
}