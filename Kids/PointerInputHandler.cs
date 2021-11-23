using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class PointerInputHandler : InputHandler, IPointerDownHandler, IPointerClickHandler
    {
        public override event Action Clicked;

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("PointerDown");
            Clicked?.Invoke();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("PointerDown");
            Clicked?.Invoke();
        }
    }
}