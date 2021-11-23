using System;

namespace ActivityLevel.ShootHandlers
{
    public interface IShootable
    {
        public event Action Shooted;
    }
}