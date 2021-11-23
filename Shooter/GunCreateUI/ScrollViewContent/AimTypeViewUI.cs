using System.Collections.Generic;
using System.Linq;
using Gun;
using GunCreateUI.SO;
using GunModelView;

namespace GunCreateUI.ScrollViewContent
{
    public class AimTypeViewUI : TypeView<AimType>
    {
        protected override void SetLockSprite(List<LockGunElementView> gunElementViews, SpriteFolder<AimType> spriteFolder, List<AimType> types, GunBase gunBase,
            PiecePriceByGunBase<AimType>[] skinPriceByGunBases)
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
                elementsByBase.Aim.Add(types[i]);
                gunElementViews[i].SpecialInit(currentPrice.Price, elementsByBase);
            }
        }

        protected override void SetSprite(List<GunElementView> gunElementViews, SpriteFolder<AimType> spriteFolder, List<AimType> unlockedType)
        {
            var sprites = spriteFolder.GetSprites();
            for (int i = 0; i < gunElementViews.Count; i++)
            {
                var currentSpriteFolder = sprites.First(s => s.Type == unlockedType[i]);
                
                gunElementViews[i].Init(currentSpriteFolder.GetSprite());
            }
        }
    }
}