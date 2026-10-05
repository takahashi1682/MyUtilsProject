using MyUtils.VContainerExtensions;
using Projects._51_データ保存;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Projects._70_VContainerサンプル
{
    public class PlayerStatus : MonoBehaviour, IScopeRegisterable
    {
        public DemoSaveData Status;

        [Inject] private DemoSaveDataStore _demoDataStore;

        // PlayerScopeRootのスコープに自身を登録する
        public void OnRegister(IContainerBuilder builder)
        {
            builder.RegisterComponent(this);
        }

        // スコープの構築はAwakeより先に終わるので、注入されたデータを使える
        private void Awake()
        {
            Status = _demoDataStore.CurrentValue;
        }
    }
}
