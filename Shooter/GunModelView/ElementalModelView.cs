using System;
using System.Collections.Generic;
using System.Linq;
using Gun;
using UnityEngine;

namespace GunView
{
    public class ElementalModelView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private int _materialNumber = 0;
        [SerializeField] private ColorByElementalType[] _colorsByElementalType;
        [SerializeField] private GunPieceElementalName[] _gunPieceColorNames;

        private GunPieceElementalName _currentColorName;

        public string Name => _currentColorName != null? _currentColorName.Name : "";


        public void SetType(ElementalType elementalType)
        {
            if (elementalType == ElementalType.None)
            {
                gameObject.SetActive(false);
            }
            else if (_colorsByElementalType.Any(c => c.ElementalType == elementalType))
            {
                var type = _colorsByElementalType.First(c => c.ElementalType == elementalType);
                _meshRenderer.materials[_materialNumber].color = type.GetColor();
                gameObject.SetActive(true);
            }

            _currentColorName = _gunPieceColorNames.First(c => c.Type == elementalType);
        }

        public string GetName(ElementalType elementalType)
        {
            return _gunPieceColorNames.First(c => c.Type == elementalType).Name;
        }
    }
}