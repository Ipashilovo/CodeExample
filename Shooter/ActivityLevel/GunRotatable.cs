using System;
using System.Collections;
using ActivityLevel.Reward;
using DefaultNamespace;
using DefaultNamespace.Input;
using Gun;
using UnityEngine;

namespace ActivityLevel
{
    public class GunRotatable : MonoBehaviour
    {
        [SerializeField] private GunSetter _gunSetter;
        [SerializeField] private RotatePower _rotatePower;
        [SerializeField] private CameraLimitation _cameraLimitation;
        private InputFolder _inputFolder;
        private EndLevelLisener _endLevelLisener;
        private GunForShoot _gunForShoot;
        private Camera _camera;

        [SerializeField] private Vector2 _offcet = new Vector2(2.8f, 5.7f);
        private Vector2 _previousInputPosition;

        private bool _isShooting;

        public void Init(InputFolder inputFolder, EndLevelLisener endLevelLisener)
        {
            _endLevelLisener = endLevelLisener;
            _inputFolder = inputFolder;
            _endLevelLisener.LevelEnded += Disable;
        }

        private void Awake()
        {
            _camera = Camera.main;
            _gunSetter.GunCreated += SetModel;
            enabled = false;
        }

        private void Start()
        {
            _inputFolder.ClickStarted += SetStartPosition;
            _inputFolder.ClickEnded += EndRotate;
        }

        private void OnDestroy()
        {
            _inputFolder.ClickStarted -= SetStartPosition;
            _inputFolder.ClickEnded -= EndRotate;
            _gunSetter.GunCreated -= SetModel;
            _endLevelLisener.LevelEnded -= Disable;
        }

        private void SetModel(GunModel gunModel)
        {
            _gunForShoot = gunModel.GetGun();
            var position = _camera.transform.forward;
            Vector3 direction = new Vector3(position.x - _offcet.x, position.y + _offcet.y, position.z);
            _camera.transform.LookAt(direction);
            Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _gunForShoot.SetLookAt(hit.point);
            }
        }

        private void Update()
        {
            if (!_isShooting) return;

            CalculateOffcet();

            var position = _camera.transform.forward;
            Vector3 direction = new Vector3(position.x - _offcet.x, position.y + _offcet.y, position.z);
            _camera.transform.LookAt(direction);
        }

        private void CalculateOffcet()
        {
            Vector2 currentPosition = _inputFolder.GetPosition();
            Vector2 value = (currentPosition - _previousInputPosition) * _rotatePower.Power;
            value.x = CalculateCurrentOffcetValue(_offcet.x, value.x, _cameraLimitation.MaxX, _cameraLimitation.MinX);
            value.y = CalculateCurrentOffcetValue(_offcet.y, value.y, _cameraLimitation.MaxY, _cameraLimitation.MinY);
            
            _offcet += value;
            _previousInputPosition = currentPosition;
        }

        private float CalculateCurrentOffcetValue(float allValue, float currentValue, float max, float min)
        {
            if (allValue + currentValue > max)
            {
                currentValue = max - allValue;
            }
            else if (allValue + currentValue < min)
            {
                currentValue = allValue - min;
            }

            return currentValue;
        }

        private void EndRotate()
        {
            _isShooting = false;
        }

        private void Disable()
        {
            _isShooting = false;
            _inputFolder.ClickStarted -= SetStartPosition;
            _inputFolder.ClickEnded -= EndRotate;
            _gunSetter.GunCreated -= SetModel;
            enabled = false;
        }

        private void SetStartPosition()
        {
            _previousInputPosition = _inputFolder.GetPosition();
            _isShooting = true;
        }
    }

    [Serializable]
    public struct CameraLimitation
    {
        public float MinX;
        public float MaxX;
        public float MinY;
        public float MaxY;
    }
}