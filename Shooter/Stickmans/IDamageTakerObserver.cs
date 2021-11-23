using System;

namespace Stickmans
{
    public interface IDamageTakerObserver
    {
        public event Action Taked;
    }
}