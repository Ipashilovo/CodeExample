using System;
using GameSystems.Collectibles;
using UnityEngine;

namespace Interactive.Collectibles
{
    public class InteractCollectible : MonoBehaviour
    {
        [SerializeField] private Collectible[] _collectibles;
        [SerializeField] private MonoBehaviour _interactiveBase;
        private IInteractive _interactive;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_interactiveBase is IInteractive)
            {
                _interactive = (IInteractive) _interactiveBase;
            }
            else
            {
                _interactiveBase = null;
                throw new ArgumentException(this.name);
            }
        }
        
#endif

        private void Awake()
        {
            _interactive = (IInteractive) _interactiveBase;
        }

        private void OnEnable()
        {
            _interactive.EndInteracting += Collect;
        }

        private void OnDisable()
        {
            _interactive.EndInteracting -= Collect;
        }

        private void Collect()
        {
            int minValue = _collectibles[0].Count;
            int number = 0;

            for (int i = 0; i < _collectibles.Length; i++)
            {
                if (_collectibles[i].Count < minValue)
                {
                    number = i;
                    minValue = _collectibles[i].Count;
                }
            }
            
            _collectibles[number].Collect();
            CollectiblesSpriteMover.PlayAnimation(transform.position, _collectibles[number].GetSprite());
        }
    }
}