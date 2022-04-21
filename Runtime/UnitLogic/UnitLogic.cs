using System;

namespace LittleBit.Modules.SequenceLogicModule
{
    public abstract class UnitLogic : IDisposable
    {
        public event Action <bool> OnChangeAvailable;


        public virtual void Dispose()
        {
            ClearListeners();
        }
        
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
        
        private void ClearListeners()
        {
            Listeners.ClearListeners<bool>(OnChangeAvailable);
        }
    }
}
