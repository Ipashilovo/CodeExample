using System;
using Player;
using UnityEngine;

namespace LevelSystems
{
    public class UpArrow : MonoBehaviour
    {
        [SerializeField] private PlayerFacade _pleyer;

        private void Update()
        {
            Vector3 position = transform.position;
            position.x = _pleyer.transform.position.x;
            transform.position = position;
        }
    }
}