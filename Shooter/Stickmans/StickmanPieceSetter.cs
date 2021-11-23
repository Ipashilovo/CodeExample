#if UNITY_EDITOR
using UnityEngine;

namespace DefaultNamespace.Stickman
{
    public class StickmanPieceSetter : MonoBehaviour
    {
        [ContextMenu("CreateHitParticle")]
        public void CreateHitParticle()
        {
            var limbs = transform.GetComponentsInChildren<StickmanLimb>();
            foreach (var limb in limbs)
            {
                limb.gameObject.AddComponent<HitParticle>();
            }
        }
    }
}
#endif