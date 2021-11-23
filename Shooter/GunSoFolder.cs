using System.Linq;
using Gun;
using UnityEngine;

[CreateAssetMenu(fileName = "GunSoFolder", menuName = "ScriptableObjects/GunData/GunSoFolder", order = 1)]
public class GunSoFolder : ScriptableObject
{
    [SerializeField] private GunSO[] _guns;

    public GunSO GetGun(GunBase gunBase)
    {
        return _guns.First(g => g.Type == gunBase);
    }
}