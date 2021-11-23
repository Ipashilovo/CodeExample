using System;
using System.Collections;
using Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuButton : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
    {
        [SerializeField] private Button _button;
        [SerializeField] private float _delay;

        private Coroutine _coroutine;

        private void OnEnable()
        {
            _button.onClick.AddListener(PrepareToExit);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(PrepareToExit);
            _button.onClick.RemoveListener(Exit);
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            InputFolder.Disable();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            InputFolder.Enable();
        }

        private void PrepareToExit()
        {
            _button.onClick.RemoveListener(PrepareToExit);
            _button.onClick.AddListener(Exit);
            _coroutine = StartCoroutine(WaitEndOfExitTime());
        }

        private void Exit()
        {
            SceneManager.LoadScene(0);
        }

        private IEnumerator WaitEndOfExitTime()
        {
            yield return new WaitForSeconds(_delay);
            _button.onClick.RemoveListener(Exit);
            _button.onClick.AddListener(PrepareToExit);
        }
    }
}