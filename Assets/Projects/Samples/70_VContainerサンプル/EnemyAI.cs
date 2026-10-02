using UnityEngine;
using VContainer;

namespace Projects._70_VContainerサンプル
{
    public class EnemyAI : MonoBehaviour
    {
        // ScopeRootの配下にあるので、インターフェースなしでも[Inject]で注入される
        [Inject] private PlayerScopeRoot _playerScope;

        private void Start()
        {
            var playerStatus = _playerScope.Container.Resolve<PlayerStatus>();
            Debug.Log(playerStatus.Status.PlayerName);
        }
    }
}
