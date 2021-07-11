using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutVisualCanvas : MonoBehaviour
{
    [SerializeField] private Image _imageState;

    public void SetImageFillValue(float val)
    {
        _imageState.fillAmount = val;
    }
}
