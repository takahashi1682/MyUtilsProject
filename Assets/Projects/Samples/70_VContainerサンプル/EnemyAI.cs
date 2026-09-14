using MyUtils.VContainerExtensions;
using UnityEngine;
using VContainer;

namespace Projects._70_VContainerサンプル
{
    public class EnemyAI : MonoBehaviour, IEnemyScopeInitializable, IScopeLaunchable
    {
        // EnemyAIは登録しない（他のコンポーネントから呼ばれない）ためIScopeRegisterableは実装しない

        [Inject] private PlayerScopeRoot _playerScope;

        public void OnLaunch()
        {
            // PlayerScopeRoot に登録された PlayerStatus を取得する
            var playerStatus = _playerScope.Container.Resolve<PlayerStatus>();
            Debug.Log(playerStatus.Status.PlayerName);
        }
    }
}