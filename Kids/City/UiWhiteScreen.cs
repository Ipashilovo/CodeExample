using System;
using UI;
using UnityEngine;

namespace City
{
    public class UiWhiteScreen : MonoBehaviour
    {
        [SerializeField] private ImageColorChanger _imageColorChanger;

        private void Start()
        {
            _imageColorChanger.Hide();
        }
    }
}