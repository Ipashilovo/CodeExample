using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField] private CookingAction _cookingAction;
    public Action<Food> FoodFalled;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FoodCollisionHandler foodComponent))
        {
            Food food = foodComponent.Food;
            ActionCommand command = new ActionCommand(_cookingAction, food.ItemType);
            EventsLooker.ActionDone?.Invoke(command);
            Destroy(foodComponent.gameObject);
            return;
        }

        if (other.TryGetComponent(out DestroingObject destroingObject))
        {
            StartCoroutine(DestroyDropObject(destroingObject));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out DestroingObject destroingObject))
        {
            StopCoroutine(DestroyDropObject(destroingObject));
        }
    }

    private IEnumerator DestroyDropObject(DestroingObject destroingObject)
    {
        float delay = 2f;
        yield return new WaitForSeconds(delay);
        Destroy(destroingObject.gameObject);
    }
}
