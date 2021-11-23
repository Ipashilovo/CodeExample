using UnityEngine;

namespace UI.VolumeSettingS
{
    public class WebLink : MonoBehaviour
    {
        [SerializeField] private string _url;
        
        public void Open()
        {
            Application.OpenURL(_url);    
        }
    }
}
