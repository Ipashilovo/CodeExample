using DefaultNamespace;
using Gun;
using GunView;
using UnityEngine;

[CreateAssetMenu(fileName = "GunSO", menuName = "ScriptableObjects/GunData/GunSO", order = 1)]
public class GunSO : ScriptableObject
{
    [SerializeField] private int _price;
    [SerializeField] private GunModel _gunModel;
    [SerializeField, Range(1f,4f)] private float _speedMultipler;

    public int Price => _price;
    public GunBase Type => _gunModel.Type;
    public float SpeedMultipler => _speedMultipler;

    public GunElementsByBase GetAllGunComponents()
    {
        return _gunModel.GetGunInfo();
    }

    public string GetName(GunSaveData gunSaveData)
    {
        return _gunModel.GetNameByPiece(gunSaveData);
    }

    public GunModel GetGunModel()
    {
        return _gunModel;
    }
}