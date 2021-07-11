using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorGate : MonoBehaviour
{
    [SerializeField] private StickmanMaterial[] _materials;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Unit unit))
        {
            var materials =
                _materials.Where(material => material.ObjectColor != unit.ObjectColor).ToList();
            StickmanMaterial newMaterial = materials[Random.Range(0, materials.Count)];
            unit.SetMaterial(newMaterial);
        }
    }
}
