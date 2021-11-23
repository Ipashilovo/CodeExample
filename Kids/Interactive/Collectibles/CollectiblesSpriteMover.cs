using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Interactive.Collectibles
{
    public class CollectiblesSpriteMover : MonoBehaviour
    {
        [SerializeField] private CollectCollectiblesAnimation _collectCollectiblesAnimation;
        [SerializeField] private float _moveTime;
        [SerializeField] private Image _image;

        private static CollectiblesSpriteMover _collectibles;

        private void Awake()
        {
            _collectibles = this;
        }

        public static void PlayAnimation(Vector3 position, Sprite sprite)
        {
            _collectibles.Move(position, sprite);
        }

        private void Move(Vector3 position, Sprite sprite)
        {
            _image.sprite = sprite;
            _image.rectTransform.position = Camera.main.WorldToScreenPoint(position);
            _image.gameObject.SetActive(true);
            StartCoroutine(DisableAfterMove());

        }

        private IEnumerator DisableAfterMove()
        {
            _image.transform.DOMove(_collectCollectiblesAnimation.transform.position, _moveTime).OnComplete(PlayCollectAnimation);
            yield return new WaitForSeconds(_moveTime);
            _image.gameObject.SetActive(false);
        }

        private void PlayCollectAnimation()
        {
            _collectCollectiblesAnimation.Play();
        }
    }
}