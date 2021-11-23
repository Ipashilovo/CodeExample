using System;
using DG.Tweening;
using UnityEngine;

namespace LevelSystems
{
    public class ChangeLevelAnimation : MonoBehaviour
    {
        [SerializeField] private Vector3 _endScale;
        private Vector3 _startScale;
        private Tweener _tweener;

        public void Animate(float time)
        {
            _startScale = transform.localScale; 
            gameObject.SetActive(true);
            _tweener = transform.DOScale(_endScale, time);
        }

        public void Remove()
        {
            _tweener.Kill();
            transform.localScale = _startScale;
            gameObject.SetActive(false);
        }
    }
}