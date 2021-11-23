using System;
using System.Collections.Generic;
using System.Linq;
using Gun;
using GunCreateUI.SkinsShop;
using GunCreateUI.SO;
using GunCreateUI.Spawner;
using GunModelView;
using UnityEngine;

namespace GunCreateUI.ScrollViewContent
{
  public abstract class TypeView<T> : MonoBehaviour
  {
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private PieceShop pieceShop;
    [SerializeField] private PiecePriceByGunBase<T>[] _priceByGunBases;
    [SerializeField] private ButtonConteiner _buttonConteiner;
    [SerializeField] private Transform _position;
    [SerializeField] private GunElementView _gunElementView;
    [SerializeField] private LockGunElementView _lockGunElementView;
    protected List<GunElementViewData<T>> _gunElementViews = new List<GunElementViewData<T>>();

    public event Action<T> SelectPiece;

    private void OnDisable()
    {
      Unfollow();
    }

    public void CreateView(List<T> unlockedType, List<T> lockedType, SpriteFolder<T> spriteFolder, GunBase gunBase,
      bool isColorTab = false)
    {
      DestroyOldCell();

      var spawner = new CellSpawner<T>();

      _gunElementViews = spawner.Spawn(unlockedType, _position, _gunElementView,
        out List<GunElementView> gunElementViews, isColorTab);

      SetSprite(gunElementViews, spriteFolder, unlockedType);

      var lockedSpawner = new LockedCellSpawner<T>();


      var lockedElements = lockedSpawner.Spawn(lockedType, _position, _lockGunElementView,
        out List<LockGunElementView> lockedElementsView, isColorTab);
      SetLockSprite(lockedElementsView, spriteFolder, lockedType, gunBase, _priceByGunBases);
      OrderByPrice(lockedElementsView);

      pieceShop.AddList(lockedElementsView);
      _gunElementViews.AddRange(lockedElements);
      gunElementViews.AddRange(lockedElementsView);

      _buttonConteiner.SetButtons(gunElementViews);
      foreach (var gunElementViewsButton in gunElementViews)
      {
        gunElementViewsButton.SetAudioSource(_audioSource);
        gunElementViewsButton.gameObject.SetActive(false);
      }

      Follow();
    }

    public void CreateEmpty()
    {
      DestroyOldCell();
    }

    protected abstract void SetLockSprite(List<LockGunElementView> gunElementViews, SpriteFolder<T> spriteFolder,
      List<T> types, GunBase gunBase, PiecePriceByGunBase<T>[] skinPriceByGunBases);

    protected abstract void SetSprite(List<GunElementView> gunElementViews, SpriteFolder<T> spriteFolder,
      List<T> unlockedType);

    protected void OrderByPrice(List<LockGunElementView> gunElementViews)
    {
      var guns = gunElementViews.OrderBy(e => e.Price);
      foreach (var gun in guns)
      {
        gun.transform.SetAsLastSibling();
      }
    }

    private void DestroyOldCell()
    {
      Unfollow();
      _buttonConteiner.Clear();
    }

    private void Follow()
    {
      foreach (var view in _gunElementViews)
      {
        view.Selected += NotifySelect;
      }
    }

    private void Unfollow()
    {
      foreach (var fGunElementView in _gunElementViews)
      {
        fGunElementView.Selected -= NotifySelect;
        fGunElementView.Clear();
      }
    }

    private void NotifySelect(T bulletType, bool isColorTab = false)
    {
      if (!isColorTab) 
        _buttonConteiner.Choose();
      
      SelectPiece?.Invoke(bulletType);
    }
  }
}