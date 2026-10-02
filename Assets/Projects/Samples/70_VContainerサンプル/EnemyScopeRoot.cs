using MyUtils.VContainerExtensions;
using VContainer;
using VContainer.Unity;

namespace Projects._70_VContainerサンプル
{
    // EnemyのScopeRoot(自身を親のスコープに登録する)
    public class EnemyScopeRoot : AbstractScopeRoot
    {
        public override void OnRegister(IContainerBuilder builder)
        {
            builder.RegisterComponent(this);
        }
    }
}
