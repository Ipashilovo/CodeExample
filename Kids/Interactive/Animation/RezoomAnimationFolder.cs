using System.Collections;
using LevelSystems;
using Move.Animation;
using Player;
using UnityEngine;

namespace Interactive.Animation
{
    public class RezoomAnimationFolder : AnimationFolder
    {
        [SerializeField] private float _time;
        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            StartCoroutine(Zooming());
        }

        private IEnumerator Zooming()
        {
            yield return new WaitForSeconds(_time);
            Debug.Log("Rezoome");
            CameraZoom.Rezoome();
        }
    }
}