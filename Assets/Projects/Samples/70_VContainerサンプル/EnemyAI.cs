using MyUtils.VContainerExtensions;
using UnityEngine;
using VContainer;

namespace Projects._70_VContainerサンプル
{
    public class EnemyAI : MonoBehaviour, IScopeInitializable
    {
        private PlayerScopeRoot _playerScopeRoot;

        public void OnRegister(IContainerBuilder builder)
        {
            // EnemyAIは登録しない（他のコンポーネントから呼ばれない）
        }

        public void OnResolve(IObjectResolver resolver)
        {
            // SceneLifetimeScope に登録した PlayerScopeRoot を取得する
            _playerScopeRoot = resolver.Resolve<PlayerScopeRoot>();
        }

        private void Start()
        {
            // PlayerScopeRoot に登録された PlayerStatus を取得する
            var playerStatus = _playerScopeRoot.Container.Resolve<PlayerStatus>();
            Debug.Log(playerStatus.Status.PlayerName);
        }
    }
}