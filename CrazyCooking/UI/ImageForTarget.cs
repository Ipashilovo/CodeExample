using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageForTarget : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Vector2 _bounceScale;
    [SerializeField] private RectTransform _rectTransform;
    private Vector2 _normalScale = new Vector2(100, 100);


    private void OnEnable()
    {
        _rectTransform.sizeDelta = _normalScale;
        StartCoroutine(Bounce(_bounceScale));
    }

    private void OnDisable()
    {
        StopCoroutine(Bounce(_bounceScale));
    }

    private void Start()
    {
        _normalScale = _rectTransform.rect.size;
    }

    public void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
        Color color = _image.color;
        color.a = 1;
        _image.color = color;
    }

    public void Hide()
    {
        Color color = _image.color;
        color.a = 0;
        _image.color = color;
    }

    private IEnumerator Bounce(Vector2 finishScale)
    {
        Vector2 startScale = _rectTransform.rect.size;
        Vector2 currentScale = new Vector2();
        float lerpValue = 0;
        float speed = 1;

        while (_rectTransform.rect.size != finishScale)
        {
            currentScale = Vector2.Lerp(startScale, finishScale, lerpValue * speed);
            _rectTransform.sizeDelta = currentScale;
            lerpValue += Time.deltaTime;
            yield return null;
        }

        StartCoroutine(Bounce(startScale));
    }
}
