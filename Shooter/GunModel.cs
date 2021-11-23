using System;
using System.Collections.Generic;
using System.Linq;
using BulletData;
using DefaultNamespace.UI.GunUI;
using Gun;
using Gun.Skin;
using GunModelView;
using GunView;
using UnityEngine;

public class GunModel : MonoBehaviour
{
    [SerializeField] private GunPieceName _name;
    [SerializeField] private SkinProviderFolder _skinProviderFolder;
    [SerializeField] private DamageMultiplicate _damageMultiplicate;
    [SerializeField] private GunForShoot _gunForShoot;
    [SerializeField] private GunBase _gunBase;
    [SerializeField] private AimModelView[] _aimModelViews;
    [SerializeField] private BulletTypeView[] _bulletTypeViews;
    [SerializeField] private ElementalModelView _elementalModelView;
    [SerializeField] private LaserSlider _laserSlider;
    private AimModelView _currentAim;
    private BulletTypeView _currentBullet;
    public string Name => $"{_skinProviderFolder.Name} {_currentBullet.Name} {_elementalModelView.Name} {_currentAim.Name} {_name.Name}";
        
    public GunBase Type => _gunBase;

    public void SetSaveData(GunSaveData gunSaveData)
    {
        SetBulletType(gunSaveData.Bullet);
        SetElement(gunSaveData.Elemental);
        SetAimModel(gunSaveData.Aim);
        SetSkin(gunSaveData.Skin);
        _elementalModelView.SetType(gunSaveData.Elemental);
    }

    public GunForShoot GetGun()
    {
        return _gunForShoot;
    }

    public GunElementsByBase GetGunInfo()
    {
        List<AimType> aimTypes = new List<AimType>();
        foreach (var aim in _aimModelViews)
        {
            aimTypes.Add(aim.Type);
        }

        List<BulletType> bulletTypes = new List<BulletType>();
        foreach (var bullet in _bulletTypeViews)
        {
            bulletTypes.Add(bullet.Type);
        }
        
        List<ColorType> colorTypes = _skinProviderFolder.GetTypes();
        
        List<ElementalType> elementalTypes = Enum.GetValues(typeof(ElementalType)).Cast<ElementalType>().ToList();

        GunElementsByBase gunElementsByBase = new GunElementsByBase();
        gunElementsByBase.Colors = colorTypes;
        gunElementsByBase.Gun = _gunBase;
        gunElementsByBase.Bullets = bulletTypes;
        gunElementsByBase.Elementals = elementalTypes;
        gunElementsByBase.Aim = aimTypes;
        return gunElementsByBase;
    }

    public void SetAimModel(AimType aimType)
    {
        foreach (var aim in _aimModelViews)
        {
            aim.gameObject.SetActive(false);
        }

        _currentAim = _aimModelViews.First(a => a.Type == aimType);
        _currentAim.gameObject.SetActive(true);
    }

    public void SetElement(ElementalType elementalType)
    {
        _elementalModelView.SetType(elementalType);
    }

    public void SetSkin(ColorType skin)
    {
        _skinProviderFolder.SetSkin(skin);
    }

    public void SetBulletType(BulletType bulletType)
    {
        foreach (var bullet in _bulletTypeViews)
        {
            bullet.gameObject.SetActive(false);
        }
        _currentBullet = _bulletTypeViews.First(t => t.Type == bulletType);
        _currentBullet.gameObject.SetActive(true);
    }

    public string GetNameByPiece(GunSaveData gunSaveData)
    {
        BulletTypeView bulletTypeView = _bulletTypeViews.First(v => v.Type == gunSaveData.Bullet);
        AimModelView aimModelView = _aimModelViews.First(v => v.Type == gunSaveData.Aim);
        string elementalName = _elementalModelView.GetName(gunSaveData.Elemental);
        return $"{bulletTypeView.Name} {elementalName} {aimModelView.Name} {_name.Name}";
    }

    public DamageMultiplicate GetDamageMultiplicate()
    {
        return _damageMultiplicate;
    }

    public LaserSlider GetLaserSlider()
    {
        return _laserSlider;
    }
}