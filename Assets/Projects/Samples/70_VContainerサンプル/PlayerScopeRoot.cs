using MyUtils.VContainerExtensions;
using VContainer;
using VContainer.Unity;

namespace Projects._70_VContainerサンプル
{
    public interface IPlayerScopeInitializable : IScopeInitializable
    {
    }

    /// <summary>
    /// PlayerオブジェクトのScopeRoot
    /// </summary>
    public class PlayerScopeRoot : AbstractScopeRoot<IPlayerScopeInitializable>, IGameManagerScopeInitializable
    {
        public override void OnRegister(IContainerBuilder builder)
        {
            // SceneLifetimeScope に自身を登録する
            builder.RegisterComponent(this);
        }

        public override void OnResolve(IObjectResolver resolver)
        {
        }
    }
}