using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIFailColorChanger : MonoBehaviour
{
    [SerializeField] private Color _reactColor;
    private Color _baseColor;
    
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        _baseColor = _image.color;
    }

    public void React()
    {
        _image.color = _reactColor;
        StartCoroutine(ResetColor());
    }

    private IEnumerator ResetColor()
    {
        float delay = 0.2f;
        yield return new WaitForSeconds(delay);
        _image.color = _baseColor;
    }
}
