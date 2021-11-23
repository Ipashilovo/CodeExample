using System;
using System.Collections;
using Input;
using UnityEngine;

namespace UI.Popup
{
    public class PopupScreen : MonoBehaviour
    {
        private void OnEnable()
        {
            InputFolder.Disable();
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.5f);
            InputFolder.Disable();
        }

        private void OnDisable()
        {
            InputFolder.Enable();
        }
    }
}