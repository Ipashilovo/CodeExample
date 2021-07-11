using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private PlayerCurrentMaterialHandler _currentMaterialHandler;
    [SerializeField] private ObjectColor _objectColor;

    public ObjectColor ObjectColor => _objectColor;
    
    public event Action MaterialChanged;

    public virtual void SetMaterial(StickmanMaterial material)
    {
        _currentMaterialHandler.SetCurrentMaterial(material.Material);
        _objectColor = material.ObjectColor;
        MaterialChanged?.Invoke();
    }
}
