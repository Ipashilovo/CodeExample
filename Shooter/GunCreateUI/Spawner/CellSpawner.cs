using System.Collections.Generic;
using GunCreateUI.ScrollViewContent;
using UnityEngine;

namespace GunCreateUI.Spawner
{
    public class CellSpawner<T>
    {
        public List<GunElementViewData<T>> Spawn(List<T> unlockedElement, Transform point,
            GunElementView gunElementView, out List<GunElementView> gunElementViews, bool isColorTab = false)
        {
            gunElementViews = new List<GunElementView>();
            List<GunElementViewData<T>> newList = new List<GunElementViewData<T>>();
            for (int i = 0; i < unlockedElement.Count; i++)
            {
                var newView = Object.Instantiate(gunElementView, point);
                
                if (isColorTab) 
                    newView.GetButtonHandler().IsColorTab = isColorTab;
                
                gunElementViews.Add(newView);
                var newViewData = new GunElementViewData<T>(unlockedElement[i], newView.GetButtonHandler());
                newList.Add(newViewData);
            }
            
            Debug.Log(unlockedElement.Count);

            return newList;
        }
    }

    public class LockedCellSpawner<T> : CellSpawner<T>
    {
        public List<GunElementViewData<T>> Spawn(List<T> unlockedElement, Transform point,
            LockGunElementView gunElementView, out List<LockGunElementView> gunElementViews, bool isColorTab = false)
        {
            gunElementViews = new List<LockGunElementView>();
            List<GunElementViewData<T>> newList = new List<GunElementViewData<T>>();
            for (int i = 0; i < unlockedElement.Count; i++)
            {
                var newView = Object.Instantiate(gunElementView, point);
                    
                if (isColorTab) 
                    newView.GetButtonHandler().IsColorTab = isColorTab;
                
                gunElementViews.Add(newView);
                var newViewData = new GunElementViewData<T>(unlockedElement[i], newView.GetButtonHandler());
                newList.Add(newViewData);
            }

            return newList;
        }
    }
}