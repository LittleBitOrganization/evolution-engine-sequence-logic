using System;
using LittleBit.Modules.CoreModule;

namespace LittleBit.Modules.SequenceLogicModule
{
    public class ResourceLogic : UnitLogic, IDisposable
    {
        private readonly IDataStorageService _dataStorageService;
        private readonly double _value;
        
        public ResourceLogic(IDataStorageService dataStorageService, string idResource, double value)
        {
            _dataStorageService = dataStorageService;
            _value = value;

            CheckCondition(_dataStorageService.GetData<Resource>(idResource));
            _dataStorageService.AddUpdateDataListener<Resource>(this, idResource, CheckCondition);
        }
        
        public override void Dispose()
        {
            _dataStorageService.RemoveAllUpdateDataListenersOnObject(this);
            ClearListeners();
        }
        
        private void CheckCondition(Resource resource)
        {
            IsAvailable = resource.Value >= _value;
        }
        
    }
}