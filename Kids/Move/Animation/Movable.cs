using DG.Tweening;
using UnityEngine;

namespace Move.Animation
{
    public class Movable : MonoBehaviour
    {
        public void Move(Vector3 direction, float speed)
        {
            transform.DOMove(direction, speed);
        }
    }
}