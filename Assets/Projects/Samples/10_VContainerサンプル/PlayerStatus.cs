using MyUtils.VContainerExtensions;
using Projects._03_データ保存;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Projects._10_VContainerサンプル
{
    public class PlayerStatus : MonoBehaviour, IScopeInitializable
    {
        public DemoSaveData Status;
        private DemoSaveDataStore _demoDataStore;

        public void OnRegister(IContainerBuilder builder)
        {
            // PlayerのScopeRootに登録する
            builder.RegisterComponent(this);
        }

        public void OnResolve(IObjectResolver resolver)
        {
            // RootLifetimeScope に登録した DemoSaveDataStore を取得する
            _demoDataStore = resolver.Resolve<DemoSaveDataStore>();
        }

        private void Start()
        {
            Status = _demoDataStore.CurrentValue;
        }
    }
}