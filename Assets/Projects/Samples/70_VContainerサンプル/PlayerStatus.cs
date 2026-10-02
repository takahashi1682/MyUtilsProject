using MyUtils.VContainerExtensions;
using Projects._51_データ保存;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Projects._70_VContainerサンプル
{
    public class PlayerStatus : MonoBehaviour, IScopeRegisterable, IScopeLaunchable
    {
        public DemoSaveData Status;

        [Inject] private DemoSaveDataStore _demoDataStore;

        // PlayerScopeRootのスコープに自身を登録する
        public void OnRegister(IContainerBuilder builder)
        {
            builder.RegisterComponent(this);
        }

        // 注入が済んだ後に呼ばれるので、受け取ったデータを使える
        public void OnLaunch()
        {
            Status = _demoDataStore.CurrentValue;
        }
    }
}
