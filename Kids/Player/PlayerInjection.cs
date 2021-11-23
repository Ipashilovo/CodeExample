using System;
using UnityEngine;

namespace Player
{
    public class PlayerInjection : MonoBehaviour
    {
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private PlayerFacade _playerFacade;
        [SerializeField] private ClickHandler _clickHandler;

        private InputOpportunityLisener _inputOpportunity;

        private void Start()
        {
            _inputOpportunity = new InputOpportunityLisener(_clickHandler, _playerFacade, _playerMover);
        }

        private void OnDisable()
        {
            _inputOpportunity.Clear();
            _inputOpportunity = null;
        }
    }
}