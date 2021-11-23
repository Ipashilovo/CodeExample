using UnityEngine;

namespace UI.Kapcha
{
    public class ButtonSetter : MonoBehaviour
    {
        [SerializeField] private NumberButton[] _numberButtons;

        public NumberButton[] CreateButtons()
        {
            for (int i = 0; i < _numberButtons.Length; i++)
            {
                _numberButtons[i].SetValue(i);
            }

            return _numberButtons;
        }
    }
}