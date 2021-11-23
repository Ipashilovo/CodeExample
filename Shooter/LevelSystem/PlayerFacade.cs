using System;
using System.Collections;
using ActivityLevel;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LevelSystem
{
    public class PlayerFacade : MonoBehaviour, IDamageTaker
    {
        [SerializeField] private int _hp = 12;
        [SerializeField] private Transform _lookAtPosition;
        [SerializeField, Range(0f, 1f)] private float _chanceToTakeDamage;
        [SerializeField] private TakeDamageView _takeDamageView;

        public event Action<int> TakedDamage;
        public event Action Dying;

        public Transform GetPosition()
        {
            return _lookAtPosition;
        }
        
        public void TakeDamage(int damage)
        {
            float value = Random.Range(0f, 1f);
            if (value > _chanceToTakeDamage) return;
            _takeDamageView.Animate();
            _hp -= damage;
            TakedDamage?.Invoke(_hp);
            if (_hp <= 0)
            {
                Dying?.Invoke();
            }
        }

        public void TakeDamageAfterDelay(int damage, float delay)
        {
            StartCoroutine(TakeDelayDamage(damage, delay));
        }

        private IEnumerator TakeDelayDamage(int damage, float delay)
        {
            yield return new WaitForSeconds(delay);
            TakeDamage(damage);
        }
    }
}