using ActivityLevel.DestroibleItems;
using LevelSystem.GroundEffects;
using UnityEngine;

namespace ActivityLevel.Cars
{
    public class Car : DestroybleItem
    {
        [SerializeField] private float _forcePower;
        [SerializeField] private DamageGroundEffect _damageGroundEffect;
        [SerializeField] private ForceGroundEffect _forceGroundEffect;
        [SerializeField] private ParticleSystem _particleSystem;


        protected override void Explosive()
        {
            _particleSystem = Instantiate(_particleSystem, transform.position, Quaternion.identity);
            _particleSystem.Play();
            foreach (var voronoiPiece in _voronoiPieces)
            {
                voronoiPiece.EnablePhysics();
            }

            foreach (var voronoiPiece in _voronoiPieces)
            {
                Vector3 direction = voronoiPiece.transform.position - transform.position;
                voronoiPiece.AddForce(direction * _forcePower);
            }
            
            _damageGroundEffect.Effect(transform.position);
            _forceGroundEffect.Effect(transform.position);
        }
    }
}