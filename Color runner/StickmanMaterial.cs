using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanMaterial : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private ObjectColor _objectColor;

    public Material Material => _material;
    public ObjectColor ObjectColor => _objectColor;
}
