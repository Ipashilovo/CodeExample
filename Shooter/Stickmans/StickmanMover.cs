using System;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace.Stickman
{
    public class StickmanMover : MonoBehaviour
    {
        [SerializeField] private MoveSpeed _moveSpeed;
        [SerializeField] private NavMeshAgent _meshAgent;
        private Transform _endPosition;

        private float _currentTime;
        private float _timeTOCheckDistance = 0.3f;
        public event Action ReachedPosition;

        private void Start()
        {
            _meshAgent.speed = _moveSpeed.Speed;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _timeTOCheckDistance)
            {
                _currentTime = 0;
                CheckDistance();
            }
        }

        public void DestroyThis()
        {
            Destroy(_meshAgent);
            Destroy(this);
        }

        public float GetDistance()
        {
            NavMeshPath navMeshPath = new NavMeshPath();
            _meshAgent.CalculatePath(_endPosition.position, navMeshPath);
            float distance = 0;
            for (int i = 0; i < navMeshPath.corners.Length - 1; i++)
            {
                distance += Vector3.Distance(navMeshPath.corners[i], navMeshPath.corners[i + 1]);
            }

            return distance;
        }

        public void StopMoving()
        {
            if (_meshAgent.hasPath)
            {
                _meshAgent.ResetPath();
            }

            enabled = false;
        }

        public void StartMoving()
        {
            _meshAgent.SetDestination(_endPosition.position);
            enabled = true;
        }

        public void SetPoint(Transform endPosition)
        {
            _endPosition = endPosition;
        }

        private void CheckDistance()
        {
            if (GetDistance() < 1)
            {
                ReachedPosition?.Invoke();
                if (_meshAgent.hasPath)
                {
                    _meshAgent.ResetPath();
                }
            }
        }
    }
}