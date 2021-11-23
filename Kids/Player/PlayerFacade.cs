using System;
using Interactive.DropInputInteractive;
using UnityEngine;

namespace Player
{
    public class PlayerFacade : MonoBehaviour
    {
        [SerializeField] private SkeletonHandler _sceletonHandler;

        public event Action<IDropInputBase> SettedInteractOpportunity;
        public event Action<IDropInputBase> DropedInteractOpportunity;

        public void SetInteractOpportunity(IDropInputBase dropInputBase)
        {
            SettedInteractOpportunity?.Invoke(dropInputBase);
        }

        public void RemoveInteractOpportunity(IDropInputBase dropInputBase)
        {
            DropedInteractOpportunity?.Invoke(dropInputBase);
        }

        public void PlayIdle()
        {
            _sceletonHandler.PlayIdle();
        }

        public ISkeletonHandler GetSceletonHandler()
        {
            return _sceletonHandler;
        }
    }
}