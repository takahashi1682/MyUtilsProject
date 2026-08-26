using MyUtils.VContainerExtensions;
using VContainer;
using VContainer.Unity;

namespace Projects._70_VContainerサンプル
{
    public interface IGameManagerScopeInitializable : IScopeInitializable
    {
    }

    public class GameManager : AbstractScopeRoot<IGameManagerScopeInitializable>, IScopeInitializable
    {
        public override void OnRegister(IContainerBuilder builder)
        {
            // SceneLifetimeScope に自身を登録する
            builder.RegisterComponent(this);
        }

        public override void OnAllResolved()
        {
        }
    }
}