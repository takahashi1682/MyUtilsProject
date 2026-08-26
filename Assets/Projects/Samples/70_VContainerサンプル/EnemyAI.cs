using UnityEngine;
using VContainer;

namespace Projects._70_VContainerサンプル
{
    public class EnemyAI : MonoBehaviour, IEnemyScopeInitializable
    {
        public void OnRegister(IContainerBuilder builder)
        {
            // EnemyAIは登録しない（他のコンポーネントから呼ばれない）
        }

        public void OnResolve(IObjectResolver resolver)
        {
            // SceneLifetimeScope に登録した PlayerScopeRoot を取得する
            var playerScope = resolver.Resolve<PlayerScopeRoot>();

            // PlayerScopeRoot に登録された PlayerStatus を取得する
            var playerStatus = playerScope.Container.Resolve<PlayerStatus>();
            Debug.Log(playerStatus.Status.PlayerName);
        }
    }
}