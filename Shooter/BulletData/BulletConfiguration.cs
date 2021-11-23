using BulletData.BulletEffect;
using Effects;
using Gun;
using UnityEngine;

namespace BulletData
{
    public class BulletConfiguration
    {
        public readonly ElementalType ElementalType;
        private float _speed;
        private ParticlePool _particlePool;
        private Effect[] _effects;
        private Color _color;
        private AudioClip _audioClip;

        public BulletConfiguration(Color color, Effect[] effects, ParticlePool particleSystem, float speed, ElementalType elementalType, AudioClip audioClip)
        {
            _color = color;
            _effects = effects;
            _particlePool = particleSystem;
            _speed = speed;
            ElementalType = elementalType;
            _audioClip = audioClip;
        }

        public float GetSpeed()
        {
            return _speed;
        }

        public AudioClip GetClip()
        {
            return _audioClip;
        }

        public ParticlePool GetParticlePool()
        {
            return  _particlePool;
        }

        public Effect[] GetEffects()
        {
            return _effects;
        }

        public Color GetColor()
        {
            return _color;
        }
    }
}