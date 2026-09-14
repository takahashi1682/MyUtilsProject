using MyUtils.VContainerExtensions;
using VContainer;
using VContainer.Unity;

namespace Projects._70_VContainerサンプル
{
    public interface IPlayerScopeInitializable : IScopeMember
    {
    }

    /// <summary>
    /// PlayerオブジェクトのScopeRoot
    /// </summary>
    public class PlayerScopeRoot : AbstractScopeRoot<IPlayerScopeInitializable>, IGameManagerScopeInitializable, IScopeLaunchable
    {
        public override void OnRegister(IContainerBuilder builder)
        {
            // SceneLifetimeScope に自身を登録する
            builder.RegisterComponent(this);
        }

        public void OnLaunch()
        {
        }
    }
}