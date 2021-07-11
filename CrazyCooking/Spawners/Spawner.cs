using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoint;

    public Action<GameObject> Spawned;

    public abstract CookingItemType Spawn();

    public abstract CookingItemType Spawn(CookingItemType cookingItemType);

    public abstract List<CookingItemType> GetCookingTypes();

    protected Vector3 GetPosition()
    {
        Vector3 position = _spawnPoint[Random.Range(0, _spawnPoint.Length)].position;
        return position;
    }
}
