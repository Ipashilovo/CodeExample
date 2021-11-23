using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace.Stickman
{
    public class FrozenCharacter : MonoBehaviour
    {
        [SerializeField] private Transform[] _voronoi;
        
        private IEnumerator Start()
        {
            foreach (var voronoi in _voronoi)
            {
                voronoi.parent = null;
            }

            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
    }
}