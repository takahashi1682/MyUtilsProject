using UnityEngine;
using VContainer;

namespace Projects._70_VContainerサンプル
{
    public class EnemyAI : MonoBehaviour, IEnemyScopeInitializable
    {
        private PlayerScopeRoot _playerScope;

        public void OnRegister(IContainerBuilder builder)
        {
            // EnemyAIは登録しない（他のコンポーネントから呼ばれない）
        }

        public void OnResolve(IObjectResolver resolver)
        {
            // SceneLifetimeScope に登録した PlayerScopeRoot を取得する
            _playerScope = resolver.Resolve<PlayerScopeRoot>();
        }

        public void OnAllResolved()
        {
            // PlayerScopeRoot に登録された PlayerStatus を取得する
            var playerStatus = _playerScope.Container.Resolve<PlayerStatus>();
            Debug.Log(playerStatus.Status.PlayerName);
        }
    }
}