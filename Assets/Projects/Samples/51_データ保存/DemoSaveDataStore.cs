using MyUtils.DataStore;

namespace Projects._51_データ保存
{
    public class DemoSaveDataStore : AbstractDataStore<DemoSaveData, DemoSaveDataAsset>
    {
        protected override string FileName => "DemoSaveData.json";
    }
}