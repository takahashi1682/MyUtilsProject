using MyUtils.DataStore;

namespace Projects._03_データ保存
{
    public class DemoSaveDataStore : AbstractDataStore<DemoSaveData, DemoSaveDataAsset>
    {
        protected override string FileName => "DemoSaveData.json";
    }
}