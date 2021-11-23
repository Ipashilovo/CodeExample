using UnityEngine;

namespace LevelSystems
{
    public class ParallaxX : MonoBehaviour
    {
        [SerializeField] private ParallaxEffect _parallaxEffect;
        private Vector3 _startCameraPosition;
        private float _startPosition;
        private Camera _camera;

        private void Awake()
        {
            _startPosition = transform.position.x;
            _camera = Camera.main;
            _startCameraPosition = _camera.transform.position;
        }

        private void Update()
        {
            Vector2 cameraDelta = _camera.transform.position - _startCameraPosition;
            Vector2 distance = cameraDelta * _parallaxEffect.Effect;
            transform.position = new Vector2(_startPosition + distance.x, transform.position.y);
        }
    }
}