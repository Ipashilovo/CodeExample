using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LevelSystems.BackGround
{
    public class Cloud : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed = 1;
        [SerializeField] private float _minSpeed = 5;
        private float _speed;

        private void Awake()
        {
            _speed = Random.Range(_minSpeed, _maxSpeed);
        }

        private void Update()
        {
            transform.position += Vector3.right * (_speed * Time.deltaTime);
        }
    }
}