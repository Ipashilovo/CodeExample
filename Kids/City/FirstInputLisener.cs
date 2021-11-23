using System;
using System.Collections;
using Input;
using Move;
using Player;
using Spine.Unity;
using UI.Popup;
using UnityEngine;

namespace City
{
    public class FirstInputLisener : MonoBehaviour
    {
        [SerializeField] private StartAnimationState _startAnimationState;
        [SerializeField] private ClickHandler _clickHandler;
        [SerializeField] private SkeletonHandler _skeletonHandler;
        [SerializeField] private StartCameraOffcetAnimation _startCameraOffcetAnimation;
        [SerializeField] private StartZoomSetter _startZoomSetter;
        [SerializeField] private AnimationReferenceAsset _animationReferenceAsset;
        [SerializeField] private AnimationReferenceAsset _flyAnimationReferenceAsset;
        [SerializeField] private MoverToPoints _bee;

        private void Start()
        {
            if (!_startAnimationState.IsPlayed)
            {
                InputFolder.Clicked += OnClickStarted;
                _startZoomSetter.Zoome();
                _startCameraOffcetAnimation.SetOffcet();
            }
            else
            {
                _bee.gameObject.SetActive(false);
                _skeletonHandler.SetAnimation(_flyAnimationReferenceAsset, 1);
                _clickHandler.enabled = true;
            }
        }

        private void OnDestroy()
        {
            InputFolder.Clicked -= OnClickStarted;
        }

        private void OnClickStarted()
        {
            InputFolder.Clicked -= OnClickStarted;
            _skeletonHandler.SetAnimation(_animationReferenceAsset, 1);
            StartCoroutine(AnimationDelay(_animationReferenceAsset.Animation.Duration));
        }

        private IEnumerator AnimationDelay(float time)
        {
            yield return new WaitForSeconds(time);
            _bee.enabled = true;
            _startZoomSetter.Rezoome();
            _startCameraOffcetAnimation.Remove();
            _clickHandler.enabled = true;
            _startAnimationState.IsPlayed = true;
        }
    }
}