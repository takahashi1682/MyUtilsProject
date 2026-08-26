using MyUtils.VContainerExtensions;
using Projects._51_データ保存;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Projects._70_VContainerサンプル
{
    public class PlayerStatus : MonoBehaviour, IPlayerScopeInitializable
    {
        public DemoSaveData Status;

        public void OnRegister(IContainerBuilder builder)
        {
            // PlayerのScopeRootに登録する
            builder.RegisterComponent(this);
        }

        public void OnResolve(IObjectResolver resolver)
        {
            // RootLifetimeScope に登録した DemoSaveDataStore を取得する
            var demoDataStore = resolver.Resolve<DemoSaveDataStore>();
            Status = demoDataStore.CurrentValue;
        }
    }
}