using DefaultNamespace.GunCreateUI;
using GameSystems.GunsInfo;
using GunCreateUI;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.GameSystems
{
    public class GunCreateSceneInjection : MonoBehaviour
    {
        [SerializeField] private GunPieceMediator _gunPieceMediator;
        [SerializeField] private GunSetter _gunSetter; 

        [Inject]
        public void Inject(UnlockElementsFolder unlockElementsFolder)
        {
            _gunPieceMediator.SetUnlockElementsFolder(unlockElementsFolder);
            _gunSetter.SetUnlockElementsFolder(unlockElementsFolder);
        }
        
    }
}