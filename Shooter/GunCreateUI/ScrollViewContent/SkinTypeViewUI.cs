using System.Collections.Generic;
using System.Linq;
using Gun;
using Gun.Skin;
using GunCreateUI.SkinsShop;
using GunCreateUI.SO;
using GunCreateUI.Spawner;
using GunModelView;
using UnityEngine;

namespace GunCreateUI.ScrollViewContent
{
    public class SkinTypeViewUI : TypeView<ColorType>
    {
        protected override void SetSprite(List<GunElementView> gunElementViews, SpriteFolder<ColorType> spriteFolder, List<ColorType> unlockedType)
        {
            var sprites = spriteFolder.GetSprites();
            for (int i = 0; i < gunElementViews.Count; i++)
            {
                var currentSpriteFolder = sprites.First(s => s.Type == unlockedType[i]);
                
                gunElementViews[i].Init(currentSpriteFolder.GetSprite());
            }
        }

        protected override void SetLockSprite(List<LockGunElementView> gunElementViews, SpriteFolder<ColorType> spriteFolder, List<ColorType> types, GunBase gunBase, PiecePriceByGunBase<ColorType>[] skinPriceByGunBases)
        {
            var currentSkinPrice = skinPriceByGunBases.First(p => p.Type == gunBase);
            var prices = currentSkinPrice.GetSkinPrices();
            var sprites = spriteFolder.GetSprites();
            for (int i = 0; i < gunElementViews.Count; i++)
            {
                var currentSpriteFolder = sprites.First(s => s.Type == types[i]);
                var currentPrice = prices.First(p => p.Type == types[i]);

                gunElementViews[i].Init(currentSpriteFolder.GetSprite());
                var elementsByBase = GunElementsByBaseDefultCreater.CreateEmpty(gunBase);
                elementsByBase.Colors.Add(types[i]);
                gunElementViews[i].SpecialInit(currentPrice.Price, elementsByBase);
            }
        }
    }
}