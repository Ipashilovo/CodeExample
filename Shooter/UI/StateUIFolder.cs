using GameSystems;
using UI.EndGame;
using UI.GameplayScreens;
using UI.StartGame;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class StateUIFolder : MonoBehaviour
    {
        [SerializeField] private Image _aimImage;
        [SerializeField] private EndGameUI _endGameUI;
        [SerializeField] private StartGameUI _startGameUI;
        [SerializeField] private GameplayScreen _gameplayScreen;

        public void ShowWin()
        {
            _aimImage.gameObject.SetActive(false);
            _endGameUI.ShowWin();
        }

        public void CloseStartGameUI()
        {
            _startGameUI.gameObject.SetActive(false);
            _aimImage.gameObject.SetActive(true);
            _gameplayScreen.gameObject.SetActive(true);
        }

        public void ShowLoose()
        {
            _aimImage.gameObject.SetActive(false);
            _gameplayScreen.gameObject.SetActive(false);
            _endGameUI.ShowLoose();
        }

        public void ShowUnrewardScreen(RewardLooker rewardLooker)
        {
            _gameplayScreen.gameObject.SetActive(false);
            _endGameUI.ShowLevelRezults(rewardLooker);
            _aimImage.gameObject.SetActive(false);
        }
    }
}