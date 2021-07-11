using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrentMaterialHandler : MonoBehaviour
{
    [SerializeField] private Renderer _playerMesh;

    public void SetCurrentMaterial(Material material)
    {
        _playerMesh.material = material;
    }
}
