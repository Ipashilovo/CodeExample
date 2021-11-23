using System.Collections;
using Move.Animation;
using Player;
using UnityEngine;

namespace Interactive.Animation
{
    public class ChangeLayerAnimation : AnimationFolder
    {
        [SerializeField] private float _startDelay;
        [SerializeField] private LayerAmnimation[] _layerAmnimations;
        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            StartCoroutine(ChangeLayer(skeletonHandler));
        }

        private IEnumerator ChangeLayer(ISkeletonHandler skeletonHandler)
        {
            yield return new WaitForSeconds(_startDelay);
            foreach (var layer in _layerAmnimations)
            {
                skeletonHandler.SetLayer(layer.layer);
                yield return new WaitForSeconds(layer.time);
            }
            
            skeletonHandler.SetDefaultLayer();
        }
    }

    [System.Serializable]
    public struct LayerAmnimation
    {
        public int layer;
        public float time;
    }
}