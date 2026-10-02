using MyUtils.VContainerExtensions;
using VContainer;
using VContainer.Unity;

namespace Projects._70_VContainerサンプル
{
    // シーン全体のScopeRoot(自身をSceneLifetimeScopeに登録する)
    public class GameManager : AbstractScopeRoot
    {
        public override void OnRegister(IContainerBuilder builder)
        {
            builder.RegisterComponent(this);
        }
    }
}
