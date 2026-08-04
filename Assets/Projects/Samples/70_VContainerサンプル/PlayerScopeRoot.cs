using MyUtils.VContainerExtensions;
using VContainer;
using VContainer.Unity;

namespace Projects._70_VContainerサンプル
{
    /// <summary>
    /// PlayerオブジェクトのScopeRoot
    /// </summary>
    public class PlayerScopeRoot : AbstractScopeRoot<IScopeInitializable>
    {
        public override void OnRegister(IContainerBuilder builder)
        {
            // SceneLifetimeScope に自身を登録する
            builder.RegisterComponent(this);
        }

        protected override void ConfigureScope(IContainerBuilder builder)
        {
        }
    }
}