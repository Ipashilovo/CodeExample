using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class StartGameButton : MonoBehaviour
    {
        [SerializeField] private ImageColorChanger _imageColorChanger;
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(Load);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Load);
        }

        private void Load()
        {
            _button.onClick.RemoveListener(Load);
            _imageColorChanger.Show();
            StartCoroutine(WaitEndOfAnimation());
        }

        private IEnumerator WaitEndOfAnimation()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadSceneAsync("City", LoadSceneMode.Single);
        }
    }
}