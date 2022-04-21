namespace LittleBit.Modules.SequenceLogicModule
{
    public class DirectLogic : UnitLogic
    {
        public DirectLogic(bool value = true)
        {
            SetValue(value);
        }
        
        public override void Dispose()
        {
            ClearListeners();
        }
        
        public void SetValue(bool value)
        {
            IsAvailable = value;
        }
    }
}