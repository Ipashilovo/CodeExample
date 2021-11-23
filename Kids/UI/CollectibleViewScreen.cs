using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CollectibleViewScreen : MonoBehaviour
    {
        [SerializeField] private CollectibleViewSpawner _collectibleViewSpawner;
        [SerializeField] private Button _leftButton;
        [SerializeField] private Button _rightButton;
        [SerializeField] private int _maxCountonOneScreen = 8;
        private List<List<CollectibleViewCell>> _collectibleViewList;
        private int _currentNumber;

        private void OnEnable()
        {
            _leftButton.onClick.AddListener(OnLeftArrow);
            _rightButton.onClick.AddListener(OnRightArroyClick);
        }

        private void OnDisable()
        {
            _leftButton.onClick.RemoveListener(OnLeftArrow);
            _rightButton.onClick.RemoveListener(OnRightArroyClick);
        }

        private void Start()
        {
            SetViewCell(_collectibleViewSpawner.Spawn());
            ShowCurrent();
        }

        public void SetViewCell(List<CollectibleViewCell> collectibleViewCells)
        {
            _collectibleViewList = new List<List<CollectibleViewCell>>();
            int coint = collectibleViewCells.Count / _maxCountonOneScreen + 1;
            for (int i = 0; i < coint; i++)
            {
                List<CollectibleViewCell> newCollectibleViewCells = new List<CollectibleViewCell>();
                if (_maxCountonOneScreen * i + _maxCountonOneScreen < collectibleViewCells.Count)
                {
                    for (int j = 0; j < _maxCountonOneScreen; j++)
                    {
                        newCollectibleViewCells.Add(collectibleViewCells[_maxCountonOneScreen * i + j]);
                    }
                }
                else
                {
                    for (int j = _maxCountonOneScreen * i; j < collectibleViewCells.Count; j++)
                    {
                        newCollectibleViewCells.Add(collectibleViewCells[j]);
                    }
                }
                _collectibleViewList.Add(newCollectibleViewCells);
            }
        }

        private void OnRightArroyClick()
        {
            if (_currentNumber + 1 < _collectibleViewList.Count)
            {
                HideCurrent();
                _currentNumber++;
                ShowCurrent();
            }
        }

        private void OnLeftArrow()
        {
            if (_currentNumber - 1 >= 0)
            {
                HideCurrent();
                _currentNumber--;
                ShowCurrent();
            }
        }

        private void HideCurrent()
        {
            foreach (var collectible in _collectibleViewList[_currentNumber])
            {
                collectible.gameObject.SetActive(false);
            }  
        }

        private void ShowCurrent()
        {
            foreach (var collectible in _collectibleViewList[_currentNumber])
            {
                collectible.gameObject.SetActive(true);
            }
        }
    }
}