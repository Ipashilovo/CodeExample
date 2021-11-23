using System;
using UnityEngine;

namespace Gun.Skin
{
    [RequireComponent(typeof(MeshRenderer))]
    public class SkinProvider : MonoBehaviour
    {
        private SkinFolderSo _skinFolder;
        [SerializeField] private int[] _materialNumbers = {0};
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public void Init(SkinFolderSo skinFolderSo)
        {
            _skinFolder = skinFolderSo;
        }

        public void SetSkin(ColorType skin)
        {
            if (_meshRenderer == null)
            {
                _meshRenderer = GetComponent<MeshRenderer>();
            }

            foreach (var number in _materialNumbers)
            {
                _meshRenderer.materials[number].color = _skinFolder.GetColor(skin);
            }
        }
    }
}