using System;

namespace ActivityLevel.ShootHandlers
{
    public interface IValueCanger
    {
        public event Action<float> ValueChanged; 
        public float GetMaxValue();
    }
}