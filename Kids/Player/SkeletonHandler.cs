using System;
using System.Collections;
using LevelSystems;
using Spine.Unity;
using UnityEngine;

namespace Player
{
    public class SkeletonHandler : MonoBehaviour, ISkeletonHandler, IBurdMovementAnimation
    {
        [SerializeField] private AnimationReferenceAsset _flyAnimation;
        [SerializeField] private AnimationReferenceAsset _walkAnimation;
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private SkinHandler _skinHandler;
        [SerializeField] private AnimationReferenceAsset _inactionAnimation;
        [SerializeField] private float _time;
        [SerializeField] private int _maxTimeInactionAnimation = 10;
        private int _currentTimeInactionAnimation;

        private Coroutine _coroutine;

        private bool _isMoving;
        private MeshRenderer _meshRenderer;
        private int _startLayer;

        private AnimationReferenceAsset _currentMovementAnimation;


        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _startLayer = _meshRenderer.sortingOrder;
            _currentMovementAnimation = _flyAnimation;
        }

        public SkeletonAnimation GetSkeleton()
        {
            return _skeletonAnimation;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public void SetAnimation(AnimationReferenceAsset animationReferenceAsset, float animationScale)
        {
            DropCoroutine();
            _skeletonAnimation.state.SetAnimation(0, animationReferenceAsset, false).TimeScale = animationScale;
            _coroutine =
                StartCoroutine(PlayInactionAnimationAfterDelay(animationReferenceAsset.Animation.Duration + _time));
            _skeletonAnimation.state.AddAnimation(0, _flyAnimation, true, 0);
        }

        public void PlayIdle()
        {
            _skeletonAnimation.state.SetAnimation(0,_flyAnimation, true);
        }

        public void SetLayer(int value)
        {
            _meshRenderer.sortingOrder = value;
        }

        public void SetDefaultLayer()
        {
            _meshRenderer.sortingOrder = _startLayer;
        }

        public ISkinHandler GetSkinHandler()
        {
            return _skinHandler;
        }

        public void Fly()
        {
            _currentMovementAnimation = _flyAnimation;
            if (_isMoving)
            {
                _skeletonAnimation.state.SetAnimation(0,_flyAnimation, true);
            }
        }

        public void Walk()
        {
            if (_isMoving)
            {
                _skeletonAnimation.state.SetAnimation(0,_walkAnimation, true);
            }

            _currentMovementAnimation = _walkAnimation;
        }

        public void StartMoving()
        {
            if (!_isMoving)
            {
                _isMoving = true;
                _skeletonAnimation.state.SetAnimation(0, _currentMovementAnimation, true);
                DropCoroutine();
            }
        }

        public void StopMoving()
        {
            _isMoving = false;
            _skeletonAnimation.state.SetAnimation(0,_flyAnimation, true);
            DropCoroutine();
            _coroutine = StartCoroutine(PlayInactionAnimationAfterDelay(_time));
        }

        private void DropCoroutine()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }

            _currentTimeInactionAnimation = 0;
        }

        private IEnumerator PlayInactionAnimationAfterDelay(float time)
        {
            yield return new WaitForSeconds(time);
            _skeletonAnimation.state.AddAnimation(0, _inactionAnimation, false, 0);
            _skeletonAnimation.state.AddAnimation(0, _flyAnimation, true, 0);
            _currentTimeInactionAnimation++;
            if (_currentTimeInactionAnimation < _maxTimeInactionAnimation)
            {
                _coroutine = StartCoroutine(PlayInactionAnimationAfterDelay(_time));
            }
            else
            {
                _coroutine = null;
            }
        }
    }
}