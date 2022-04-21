using System;

namespace LittleBit.Modules.SequenceLogicModule
{
    public abstract class UnitLogic
    {
        public event Action <bool> OnChangeAvailable;

        public abstract void Dispose();
        
        private bool _isAvailable = false;
        
        public bool IsAvailable
        {
            get => _isAvailable;
            protected set
            {
                _isAvailable = value;
                OnChangeAvailable?.Invoke(_isAvailable);
            }
        }
        
        protected void ClearListeners()
        {
            Listeners.ClearListeners<bool>(OnChangeAvailable);
        }
    }
}
