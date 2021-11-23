using System;
using System.Collections.Generic;
using DG.Tweening;
using Gun;
using UnityEngine;
using UnityEngine.UI;

namespace GunCreateUI.ScrollViewContent
{
    public class ButtonConteiner : MonoBehaviour
    {
        [SerializeField] private ButtonHandler _buttonHandler;
        private List<GunElementView> _gunElementViewsButtons = new List<GunElementView>();
        [SerializeField] private Image _selected;
        
        public event Action<ButtonConteiner> Selected;
        public event Action<ButtonConteiner> Choosed;

        private void OnEnable()
        {
            _buttonHandler.Clicked += Select;
        }

        private void OnDisable()
        {
            _buttonHandler.Clicked -= Select;
        }

        public void Clear()
        {
            foreach (var gunElementViewsButton in _gunElementViewsButtons)
            {
                Destroy(gunElementViewsButton.gameObject);
            }
            _gunElementViewsButtons.Clear();
        }

        public void SetButtons(List<GunElementView> gunElementViewsButtons)
        {
            _gunElementViewsButtons = gunElementViewsButtons;
        }

        public void Hide()
        {
            _selected.DOFade(0, 0.25f);
            foreach (var gunElementViewsButton in _gunElementViewsButtons)
            {
                gunElementViewsButton.gameObject.SetActive(false);
            }
        }

        public void Select(bool isColorTab = false)
        {
            _selected.DOFade(1, 0.25f);
            Selected?.Invoke(this);
            Show();
        }

        public void Show()
        {
            foreach (var gunElementViewsButton in _gunElementViewsButtons)
            {
                gunElementViewsButton.gameObject.SetActive(true);
            }
        }

        public void Choose()
        {
            Choosed?.Invoke(this);
        }
    }
}