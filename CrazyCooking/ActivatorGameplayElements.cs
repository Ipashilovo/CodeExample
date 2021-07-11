using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorGameplayElements : MonoBehaviour
{
    [SerializeField] private LimbMover[] _limbMovers;
    [SerializeField] private CookingLooker _cookingLooker;
    [SerializeField] private MonoBehaviour _UIelement;

    public void Deactivate()
    {
        _UIelement.gameObject.SetActive(false);
        foreach (var limbMover in _limbMovers)
        {
            limbMover.gameObject.SetActive(false);
        }
        _cookingLooker.enabled = false;
    }

    public void Activate()
    {
        foreach (var limbMover in _limbMovers)
        {
            limbMover.gameObject.SetActive(true);
        }

        _cookingLooker.enabled = true;
        _UIelement.gameObject.SetActive(true);
    }
}
