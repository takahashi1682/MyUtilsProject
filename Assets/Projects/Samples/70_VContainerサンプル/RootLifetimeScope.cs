using Projects._03_データ保存;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Projects._10_VContainerサンプル
{
    public class RootLifetimeScope : LifetimeScope
    {
        [SerializeField] private DemoSaveDataStore _demoDataStore;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_demoDataStore);
        }
    }
}