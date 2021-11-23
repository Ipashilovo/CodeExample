using System.Collections;
using UnityEngine;

namespace ActivityLevel
{
    public class ParticleFolder : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _fireParticle;
        [SerializeField] private ParticleSystem _coldParticle;
        [SerializeField] private float _time;
        private Coroutine _coroutine;

        public void PlayFireParticle()
        {
            PlayParticle(_fireParticle);
        }

        public void PlayColdParticle()
        {
            PlayParticle(_coldParticle);
        }

        private void PlayParticle(ParticleSystem particleSystem)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
            else
            {
                particleSystem.Play();
            }

            _coroutine = StartCoroutine(DisableParticle(particleSystem));
        }

        private IEnumerator DisableParticle(ParticleSystem particleSystem)
        {
            yield return new WaitForSeconds(_time);
            particleSystem.Stop();
            _coroutine = null;
        }
    }
}