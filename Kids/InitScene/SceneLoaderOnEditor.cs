#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InitScene
{
    public class SceneLoaderOnEditor : MonoBehaviour
    {
        [SerializeField] private FirstSceneName _firstSceneName;

        [ContextMenu("Load")]
        public void Load()
        {
            _firstSceneName.Name = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(0);
        }
    }
}
#endif