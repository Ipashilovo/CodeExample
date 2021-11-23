using UnityEngine;

namespace Interactive.DropInputInteractive
{
    public class DropInputMultipleAnimationWithLookPosition : DropInputMultipleAnimation
    {
        [SerializeField] private Transform _position;
        public override Vector2 GetLookAtPosition()
        {
            return _position.position;
        }
    }
}