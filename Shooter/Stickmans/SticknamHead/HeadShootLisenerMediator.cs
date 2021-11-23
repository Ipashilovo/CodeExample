using System;
using UnityEngine;

namespace DefaultNamespace.Stickman.SticknamHead
{
    public static class HeadShootLisenerMediator
    {
        public static event Action Shooted;

        public static void Notify()
        {
            Shooted?.Invoke();
        }
    }
}