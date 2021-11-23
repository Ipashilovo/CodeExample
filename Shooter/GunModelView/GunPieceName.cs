using UnityEngine;

namespace GunModelView
{
    public class GunPieceName : MonoBehaviour
    {
        [SerializeField] private string _name;

        public string Name => _name;
    }
}