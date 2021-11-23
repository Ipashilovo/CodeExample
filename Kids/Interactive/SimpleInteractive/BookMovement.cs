using DG.Tweening;
using UnityEngine;

namespace Interactive
{
    public class BookMovement : MonoBehaviour
    {
        [SerializeField] private Vector3[] _position;
        [SerializeField] private Vector3[] _rotations;
        private int _currentNumber;

        public void Move(float time)
        {
            _currentNumber++;
            _currentNumber %= _position.Length;

            transform.DOLocalMove(_position[_currentNumber], time);
            transform.DOLocalRotate(_rotations[_currentNumber], time);
        }
    }
}