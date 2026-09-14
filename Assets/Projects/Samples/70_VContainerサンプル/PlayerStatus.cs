using MyUtils.VContainerExtensions;
using Projects._51_データ保存;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Projects._70_VContainerサンプル
{
    public class PlayerStatus : MonoBehaviour, IPlayerScopeInitializable, IScopeRegisterable, IScopeLaunchable
    {
        public DemoSaveData Status;

        [Inject] private DemoSaveDataStore _demoDataStore;

        public void OnRegister(IContainerBuilder builder)
        {
            // PlayerのScopeRootに登録する
            builder.RegisterComponent(this);
        }

        public void OnLaunch()
        {
            // RootLifetimeScope に登録した DemoSaveDataStore を[Inject]で受け取る
            Status = _demoDataStore.CurrentValue;
        }
    }
}