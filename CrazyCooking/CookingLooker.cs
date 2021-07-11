using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingLooker : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _targetShowerBase;
    private IActionTargetShower _targetShower => (IActionTargetShower)_targetShowerBase;
    [SerializeField] private LifeLooker _lifeLooker;
    [SerializeField] private RecipeLooker _recipeLooker;
    [SerializeField] private float _timeForCircle;
    private ActionCommand _currentCommand;
    private bool _isStoped;
    private bool _isCommandDone;
    private float _time;

    public ActionCommand CurrentCommand => _currentCommand;

    public event Action CommandDone;
    public event Action CookingComplited; 

    private void OnValidate()
    {
        if (_targetShowerBase is IActionTargetShower)
        {
            return;
        }
        Debug.LogError(_targetShowerBase.name + " needs to implement " + nameof(IActionTargetShower));
        _targetShowerBase = null;
    }

    private void OnEnable()
    {
        EventsLooker.ActionDone += OnActionDone;
    }

    private void OnDisable()
    {
        EventsLooker.ActionDone -= OnActionDone;
    }

    private void Start()
    {
        if (_recipeLooker.TryGetNextCommand(out ActionCommand command))
        {
            _currentCommand = command;
        }
        else
        {
            throw new ArgumentException(this.name);
        }
        _targetShower.SetAction(_currentCommand);
        _targetShower.SetCooldown(_timeForCircle);
    }

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _timeForCircle)
        {
            OnCooldownEnded();
        }
    }
    
    private void StartNewCycle()
    {
        if (_isStoped)
        {
            return;
        }

        if (TryTakeNewCommand())
        {
            _targetShower.SetAction(_currentCommand);
            ReduceCooldown();
            _isCommandDone = false;
        }
        else
        {
            CookingComplited?.Invoke();
        }
    }

    private bool TryTakeNewCommand()
    {
        if (_recipeLooker.TryGetNextCommand(out ActionCommand command))
        {
            _currentCommand = command;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnActionDone(ActionCommand command)
    {
        if (command != _currentCommand)
        {
            return;
        }
        CommandDone?.Invoke();
        Compliting();
    }

    private void OnCooldownEnded()
    {
        if (!_isCommandDone)
        {
            _targetShower.ShowFail();
            _lifeLooker.TakeDamage();
        }

        ReduceCooldown();
    }

    private void Compliting()
    {
        _isCommandDone = true;
        _targetShower.ShowComplite();
        StartNewCycle();
    }

    private void ReduceCooldown()
    {
        _time = 0;
        _targetShower.SetCooldown(_timeForCircle);
    }
}
