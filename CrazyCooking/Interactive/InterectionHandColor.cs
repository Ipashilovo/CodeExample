using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class InterectionHandColor : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool IsActiv { get; private set; }
    public event Action MouseUp;

    public void SetInterectionTrigger(bool trig)
    {
        if(trig)
            GetComponent<Image>().color = Color.green;
        else
            GetComponent<Image>().color = Color.white;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        MouseUp?.Invoke();
        IsActiv = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        IsActiv = true;
    }
}
