using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ExitButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Exit);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Exit);
        }

        private void Exit()
        {
            SceneManager.LoadScene("GunCreateScene");
        }
    }
}