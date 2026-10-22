using MyUtils.VContainerExtensions;
using R3;
using UnityEngine;
using VContainer;

namespace Projects._70_VContainerサンプル
{
    public class EnemyAI : MonoBehaviour
    {
        // ScopeRootの配下にあるので、インターフェースなしでも[Inject]で注入される
        [Inject] private PlayerScopeRoot _playerScope;

        // UpdateScheduler(GameManagerで登録)。Update()の代わりに、決まった順番で毎フレーム呼ばれる
        [Inject] private IUpdateObservable _updateObservable;

        private void Start()
        {
            var playerStatus = _playerScope.Container.Resolve<PlayerStatus>();
            Debug.Log(playerStatus.Status.PlayerName);

            // 上下にゆらゆら動かす
            var basePosition = transform.position;
            _updateObservable.OnUpdate(EUpdatePhase.Default)
                .Subscribe(_ => transform.position = basePosition + Vector3.up * (Mathf.Sin(Time.time * 2f) * 0.3f))
                .AddTo(this);
        }
    }
}
