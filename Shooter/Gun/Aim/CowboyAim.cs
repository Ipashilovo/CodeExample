using System;
using System.Collections;
using DefaultNamespace.Stickman.SticknamHead;
using UnityEngine;

namespace Gun.Aim
{
    public class CowboyAim : MonoBehaviour
    {
        [SerializeField] private CowboyAimData _cowboyAimData;
        private Coroutine _coroutine;
        
        private void OnEnable()
        {
            HeadShootLisenerMediator.Shooted += Slowing;
        }

        private void OnDisable()
        {
            ClearCoroutine();
            HeadShootLisenerMediator.Shooted -= Slowing;
            Time.timeScale = 1;
        }

        private void Slowing()
        {
            ClearCoroutine();
            Time.timeScale = _cowboyAimData.Scale;
            _coroutine = StartCoroutine(RemoveTimeScale());
        }

        private void ClearCoroutine()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private IEnumerator RemoveTimeScale()
        {
            yield return new WaitForSeconds(_cowboyAimData.Time);
            Time.timeScale = 1;
            _coroutine = null;
        }
    }
}