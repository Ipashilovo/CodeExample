using DefaultNamespace.GameSystems;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private Text _text;
        private MoneyFolder _moneyFolder;

        public void Init(MoneyFolder moneyFolder)
        {
            _moneyFolder = moneyFolder;
            ShowNewValue();
        }

        private void Start()
        {
            _moneyFolder.MoneyCountChanged += ShowNewValue;
        }

        private void OnDestroy()
        {
            _moneyFolder.MoneyCountChanged -= ShowNewValue;
        }

        private void ShowNewValue()
        {
            _text.text = _moneyFolder.Money.ToString();
        }
    }
}