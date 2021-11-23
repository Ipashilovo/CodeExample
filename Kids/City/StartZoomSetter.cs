using System;
using System.Collections;
using LevelSystems;
using UnityEngine;

namespace City
{
    public class StartZoomSetter : MonoBehaviour
    {
        [SerializeField] private float _zoomValue;

        public void Zoome()
        {
            CameraZoom.Zoom(_zoomValue, 0);
        }

        public void Rezoome()
        {
            CameraZoom.Rezoome();
        }
    }
}