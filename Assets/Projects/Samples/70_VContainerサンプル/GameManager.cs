using MyUtils.VContainerExtensions;
using VContainer;
using VContainer.Unity;

namespace Projects._70_VContainerサンプル
{
    public interface IGameManagerScopeInitializable : IScopeMember
    {
    }

    public class GameManager : AbstractScopeRoot<IGameManagerScopeInitializable>
    {
        public override void OnRegister(IContainerBuilder builder)
        {
            // SceneLifetimeScope に自身を登録する
            builder.RegisterComponent(this);
        }
    }
}