using System.Collections.Generic;

namespace LittleBit.Modules.SequenceLogicModule
{
    
    public class SequenceLogic : UnitLogic
    {
        private readonly List<UnitLogic> _unitComponents;

        public SequenceLogic()
        {
            _unitComponents = new List<UnitLogic>();
        }

        public void Add(UnitLogic unitLogic)
        {
            unitLogic.OnChangeAvailable += OnUpdateSomething;
            _unitComponents.Add(unitLogic);
        }

        public void Remove(UnitLogic unitLogic)
        {
            unitLogic.OnChangeAvailable -= OnUpdateSomething;
            _unitComponents.Remove(unitLogic);
        }

        private void Unsubscribe(UnitLogic unitLogic)
        {
            unitLogic.OnChangeAvailable -= OnUpdateSomething;
        }

        public void Check(bool isAvailable = false)
        {
            foreach (var unit in _unitComponents)
            {
                if (unit.IsAvailable)
                {
                    isAvailable = true;
                }
                else
                {
                    isAvailable = false;
                    break;
                }
            }

            IsAvailable = isAvailable;
        }


        private void OnUpdateSomething(bool isAvailable)
        {
            Check(isAvailable);
        }

        public override void Dispose()
        {
            foreach (var unit in _unitComponents)
            {
                Unsubscribe(unit);
                unit.Dispose();
            }

            _unitComponents.Clear();
            ClearListeners();
        }
    }
}