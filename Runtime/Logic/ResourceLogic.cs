using LittleBit.Modules.CoreModule;

namespace LittleBit.Modules.SequenceLogicModule
{
    public class ResourceLogic : UnitLogic
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
            base.Dispose();
            _dataStorageService.RemoveAllUpdateDataListenersOnObject(this);
        }
        
        private void CheckCondition(Resource resource)
        {
            IsAvailable = resource.Value >= _value;
        }
        
    }
}