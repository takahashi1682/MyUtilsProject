using MyUtils.VContainerExtensions;
using VContainer;
using VContainer.Unity;

namespace Projects._70_VContainerサンプル
{
    // PlayerのScopeRoot(自身を親のスコープに登録する)
    public class PlayerScopeRoot : AbstractScopeRoot
    {
        public override void OnRegister(IContainerBuilder builder)
        {
            builder.RegisterComponent(this);
        }
    }
}
