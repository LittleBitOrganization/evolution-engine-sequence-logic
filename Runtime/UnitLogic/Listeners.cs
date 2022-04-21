using System;

namespace LittleBit.Modules.SequenceLogicModule
{
    public static class Listeners
    {
        public static void ClearListeners<T>(Action<T> eventAction)
        {
            Delegate [] delegates = eventAction?.GetInvocationList();
            if (delegates != null)
            {
                foreach (var dDelegate in delegates)
                {
                    eventAction -= (Action<T>)dDelegate;
                }
            }
        }

        public static void ClearListeners(Action eventAction)
        {
            Delegate [] delegates = eventAction?.GetInvocationList();
            if (delegates != null)
            {
                foreach (var dDelegate in delegates)
                {
                    eventAction -= (Action)dDelegate;
                }
            }
        }
    }
}