using Input;
using Interactive.DropInputInteractive;
using UnityEngine;

namespace Player
{
    public class InputOpportunityLisener
    {
        private PlayerMover _playerMover;
        private PlayerFacade _playerFacade;
        private ClickHandler _clickHandler;

        private IDropInputBase _dropInputBase;
        private bool _isInteractive;
        private int number = 0;

        public InputOpportunityLisener(ClickHandler clickHandler, PlayerFacade playerFacade, PlayerMover playerMover)
        {
            _playerFacade = playerFacade;
            _playerMover = playerMover;
            _clickHandler = clickHandler;
            _playerMover.MoveEnded += InteractIfPossible;
            _playerMover.ReachedPosition += OnPositionReached;
            _playerFacade.SettedInteractOpportunity += SetInteractOpportunity;
            _playerFacade.DropedInteractOpportunity += DropInteractOpporunity;
            _clickHandler.ClickEnded += InteractIfPossible;
        }

        public void Clear()
        {
            _playerMover.MoveEnded -= InteractIfPossible;
            _playerMover.ReachedPosition -= OnPositionReached;
            _playerFacade.SettedInteractOpportunity -= SetInteractOpportunity;
            _playerFacade.DropedInteractOpportunity -= DropInteractOpporunity;
            _clickHandler.ClickEnded -= InteractIfPossible;
            if (_dropInputBase != null)
            {
                _dropInputBase.EndInteracting -= OnInteractEnded;
                _dropInputBase = null;
            }
        }

        private void DropInteractOpporunity(IDropInputBase dropInputBase)
        {
            if (!_isInteractive && _dropInputBase != null)
            {
                _dropInputBase.EndInteracting -= OnInteractEnded;
                _dropInputBase = null;
            }
        }

        private void SetInteractOpportunity(IDropInputBase dropInputBase)
        {
            if(_isInteractive) return;
            
            if (_dropInputBase != null)
            {
                _dropInputBase.EndInteracting -= OnInteractEnded;
                _dropInputBase = null;
            }

            _dropInputBase = dropInputBase;
            _dropInputBase.EndInteracting += OnInteractEnded;
        }

        private void InteractIfPossible()
        {
            if (_dropInputBase != null && !_isInteractive && !_clickHandler.IsMoving && !_playerMover.IsMoving && InputFolder.IsEnable)
            {
                _isInteractive = true;
                InputFolder.Disable();
                _playerMover.MoveToInteractiblePosition(_dropInputBase.GetStartPosition());
            }
        }

        private void OnPositionReached()
        {
            _playerMover.LookAt(_dropInputBase.GetLookAtPosition());
            _dropInputBase.Interact(_playerFacade.GetSceletonHandler());
        }

        private void OnInteractEnded()
        {
            ReturnMoveOpportunity();
        }

        private void ReturnMoveOpportunity()
        {
            _isInteractive = false;
            _dropInputBase.EndInteracting -= OnInteractEnded;
            _dropInputBase = null;
        }
    }
}