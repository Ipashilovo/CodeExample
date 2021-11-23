using UnityEngine;

namespace Gun.GunShootAnimations
{
    public abstract class GunShootAnimation : MonoBehaviour
    {
        public abstract void Animate(float time);
    }
}