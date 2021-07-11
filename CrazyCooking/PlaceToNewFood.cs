using System;
using UnityEngine;

public class PlaceToNewFood : MonoBehaviour
{
    private FoodsConteiner _conteiner;

    private void Awake()
    {
        _conteiner = new FoodsConteiner();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FoodCollisionHandler foodComponent) && foodComponent.Food.CutingState != FoodState.FinishSlicing)
        {
            Food food = foodComponent.Food;
            _conteiner.Add(food);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out FoodCollisionHandler foodComponent) && foodComponent.Food.CutingState != FoodState.FinishSlicing)
        {
            Food food = foodComponent.Food;
            _conteiner.Remove(food);
        }
    }

    public IFoodFinder GetFinder()
    {
        return _conteiner;
    }
}
