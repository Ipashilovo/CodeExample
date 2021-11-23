using DefaultNamespace;
using DG.Tweening;
using Gun;
using UnityEngine;

namespace GunCreateUI
{
    public class GunModelViewMover : MonoBehaviour
    {
        [SerializeField] private MovePower _movePower;
        [SerializeField] private Vector3 _targetPosition;
        [SerializeField] private GunModel _gunModel;

        public GunBase Type => _gunModel.Type;
        
        public GunModel GetGunModel()
        {
            return _gunModel;
        }

        public void MoveRight()
        {
            transform.DOMoveX(transform.position.x + _movePower.Power, _movePower.Time);
        }

        public void MoveLeft()
        {
            transform.DOMoveX(transform.position.x - _movePower.Power, _movePower.Time);
        }

        public void MoveToCenterByLeftSide()
        {
            Vector3 startPosition = _targetPosition;
            startPosition.x -= _movePower.Power;
            transform.position = startPosition;
            transform.DOMove(_targetPosition, _movePower.Time);
        }

        public void MoveToCenterByRightSide()
        {
            Vector3 startPosition = _targetPosition;
            startPosition.x += _movePower.Power;
            transform.position = startPosition;
            transform.DOMove(_targetPosition, _movePower.Time);
        }
    }
}