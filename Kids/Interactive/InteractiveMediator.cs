using System;

namespace Interactive
{
    public static class InteractiveMediator
    {
        public static event Action InteractStarted;
        public static event Action InteractEnded;

        public static void NotifyStart()
        {
            InteractStarted?.Invoke();
        }

        public static void NotifyEnd()
        {
            InteractEnded?.Invoke();
        }
    }
}