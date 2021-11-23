using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Gun;
using Stickmans;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace.Stickman
{
    public class StickmanAnimator
    {
        private StickmanStats _stickmanStats;
        private Animator _animator;
        private StickmanIdleAnimation _stickmanIdleAnimation;

        public event Action ShootedAnimationEnded;
        public event Action ShootedAnimationStarted;

        private readonly Dictionary<LimbType, List<string>> animationByDamageType =
            new Dictionary<LimbType, List<string>>()
            {
                {LimbType.Eggs, new List<string>() {"Stomach"}},
                {LimbType.Head, new List<string>() {"Head"}},
                {LimbType.None, new List<string>() {"React4", "React3"}}
            };

        private readonly Dictionary<ElementalType, List<string>> animationByConditionType =
            new Dictionary<ElementalType, List<string>>()
            {
                {ElementalType.Fire, new List<string>() {"Burning"}},
                {ElementalType.Cold, new List<string>() {"Freeze"}}
            };

        private bool _isPlayingDamageAnimation;

        public StickmanAnimator(Animator animator, StickmanStats stickmanStats)
        {
            _animator = animator;
            _stickmanStats = stickmanStats;
            _stickmanIdleAnimation = _animator.GetBehaviour<StickmanIdleAnimation>();
            _stickmanIdleAnimation.StateEntered += OnDamageAnimationEnd;
        }

        public void Destroy()
        {
            _animator.enabled = false;
            Clear();
        }

        public void Clear()
        {
            _stickmanIdleAnimation.StateEntered -= OnDamageAnimationEnd;
        }

        public void StartMoving()
        {
            _animator.SetBool("IsMoving", true);
        }

        public void StopMoving()
        {
            _animator.SetBool("IsMoving", false);
        }

        public void PlayDamageAnimation(LimbType limbType)
        {
            if (CheckPlayingAnimation()) return;
            
            float value = Random.Range(0f, 1f);
            if (value <= _stickmanStats.ChanceToPlayAnimation)
            {
                var animationName = animationByDamageType[limbType];
                var currentAnimation = animationName[Random.Range(0, animationName.Count)];
                _animator.SetTrigger(currentAnimation);
                
                NotifyStartAnimation();
            }
        }

        private bool CheckPlayingAnimation()
        {
            return _isPlayingDamageAnimation;
        }

        public void PlayBurning()
        {
            if (CheckPlayingAnimation()) return;
            float value = Random.Range(0f, 1f);
            TryPlayElementAnimation(ElementalType.Fire, value);
        }

        private void NotifyStartAnimation()
        {
            _isPlayingDamageAnimation = true;
            ShootedAnimationStarted?.Invoke();
        }

        private void OnDamageAnimationEnd()
        {
            _isPlayingDamageAnimation = false;

            ShootedAnimationEnded?.Invoke();
        }

        public void PlayFreeze()
        {
            if (CheckPlayingAnimation()) return;
            TryPlayElementAnimation(ElementalType.Cold, 0);
        }

        private void TryPlayElementAnimation(ElementalType elementalType, float value)
        {
            if (value <= _stickmanStats.ChanceToPlayAnimation)
            {
                var animationName = animationByConditionType[elementalType];
                var currentAnimation = animationName[Random.Range(0, animationName.Count)];
                _animator.SetTrigger(currentAnimation);
                NotifyStartAnimation();
            }
        }

        public void PlayShoot()
        {
            _animator.SetTrigger("Shoot");
        }
    }
}