using BulletData;
using Gun;
using GunModelView;
using UnityEngine;

namespace GunView
{
    public class BulletTypeView : MonoBehaviour
    {
        [SerializeField] private BulletType _bulletType;
        [SerializeField] private GunPieceName _name;

        public string Name => _name.Name;
        public BulletType Type => _bulletType;
    }
}