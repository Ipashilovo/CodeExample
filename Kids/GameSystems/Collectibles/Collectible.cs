using System;
using UnityEditor;
using UnityEngine;

namespace GameSystems.Collectibles
{
    [CreateAssetMenu(fileName = "Collectible", menuName = "ScriptableObjects/Collectibles/Collectible", order = 1)]
    public class Collectible : ScriptableObject
    {
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private Sprite _sprite;
        private int _lastCount;
        private bool _isShowing;
        private int _count;

        public int Count
        {
            get => _count;
            set => PlayerPrefs.SetInt(_audioClip.name, value);
        }

        public bool IsShowing => _lastCount == _count;
        public event Action<Collectible> Collecting;
        
#if UNITY_EDITOR
        public void SetSprite(Sprite sprite)
        {
            EditorUtility.SetDirty(this);
            _sprite = sprite;
        }

        [ContextMenu("ClearCount")]
        public void ClearCount()
        {
            EditorUtility.SetDirty(this);
            Count = 0;
        }
#endif

        private void OnEnable()
        {
            _lastCount = PlayerPrefs.GetInt(_audioClip.name + "LastCount");
            _count = PlayerPrefs.GetInt(_audioClip.name);
        }

        public Sprite GetSprite()
        {
            return _sprite;
        }

        public AudioClip GetAudioClip()
        {
            return _audioClip;
        }
        
        public void Show()
        {
            _lastCount = _count;
            PlayerPrefs.SetInt(_audioClip.name + "LastCount", _lastCount);
        }

        public void Collect()
        {
            _count++;
            Count = _count;
            Collecting?.Invoke(this);
        }
    }
}