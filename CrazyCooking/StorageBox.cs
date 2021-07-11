using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class StorageBox : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private CookingAction _cookingAction;
    [SerializeField] private StorageBoxMediator _storageBoxMediator;
    private List<CookingItemType> _itemsInBox;

    private void Start()
    {
        _itemsInBox = _spawner.GetCookingTypes();
    }

    public event Action Opening;
    
    


    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Leg leg))
        {
            if (_storageBoxMediator.TryGetCurrentItemType(_itemsInBox, out CookingItemType cookingItemType))
            {
                Opening?.Invoke();
                Spawn(cookingItemType);
                GenerateAction();
            }
        }
    }

    protected void Spawn()
    {
        _spawner.Spawn();
    }

    protected void Spawn(CookingItemType cookingItemType)
    {
        _spawner.Spawn(cookingItemType);
    }

    protected void GenerateAction()
    {
        ActionCommand command = new ActionCommand(_cookingAction, CookingItemType.Foot);
        EventsLooker.ActionDone?.Invoke(command);
    }
}
