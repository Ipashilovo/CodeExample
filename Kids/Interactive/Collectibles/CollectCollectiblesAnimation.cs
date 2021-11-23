using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Interactive.Collectibles
{
    public class CollectCollectiblesAnimation : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _time;
        [SerializeField] private float _rotateSpeed;

        public void Play()
        {
            _image.gameObject.SetActive(true);
            StartCoroutine(Rotate());
        }

        private IEnumerator Rotate()
        {
            float time = 0;
            while (time < 1)
            {
                time += Time.deltaTime / _time;
                _image.transform.Rotate(0,0, _rotateSpeed * Time.deltaTime);
                yield return null;
            }
            _image.gameObject.SetActive(false);
        }
    }
}