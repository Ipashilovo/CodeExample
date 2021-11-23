using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ImageColorChanger : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _time = 1;

        public void Show()
        {
            StartCoroutine(ChangeA(1));
        }

        public void Hide()
        {
            StartCoroutine(ChangeA(0));
        }

        private IEnumerator ChangeA(float targetValue)
        {
            float currentTime = 0;
            Color color = _image.color;
            float startValue = color.a;
            while (currentTime <= 1)
            {
                currentTime += Time.deltaTime / _time;
                color.a = Mathf.Lerp(startValue, targetValue, currentTime);
                _image.color = color;
                yield return null;
            }
        }
    }
}