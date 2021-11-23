using Analytics;
using AppsFlyerSDK;
using City;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InitScene
{
    public class InitScene : MonoBehaviour
    {
        [SerializeField] private CurrentLocation _currentLocation;
        [SerializeField] private StartAnimationState _startAnimationState;
#if UNITY_EDITOR
        [SerializeField] private FirstSceneName _scene;
#endif
        private void Start()
        {
            _startAnimationState.IsPlayed = false;
            _currentLocation.SetLocation(Locations.None);
        }

        public void AcceptGDPR()
        {
            GlobalData.AcceptGDPR();
            SceneManager.LoadScene("City");
        }

    }
}