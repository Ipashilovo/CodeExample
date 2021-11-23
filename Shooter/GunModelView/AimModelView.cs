using Gun;
using GunModelView;
using UnityEngine;

namespace GunView
{
    public class AimModelView : MonoBehaviour
    {
        [SerializeField] private AimType _aimType;
        [SerializeField] private GunPieceName _name;

        public string Name => _name.Name;
        public AimType Type => _aimType;
    }
}