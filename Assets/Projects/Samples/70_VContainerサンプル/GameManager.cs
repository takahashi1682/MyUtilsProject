using MyUtils.VContainerExtensions;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Projects._70_VContainerサンプル
{
    // シーン全体のScopeRoot(自身をSceneLifetimeScopeに登録する)
    public class GameManager : AbstractScopeRoot
    {
        [Header("「敵を生成」ボタンで生成するプレハブ")]
        [SerializeField] private EnemyScopeRoot _enemyPrefab;

        public override void OnRegister(IContainerBuilder builder)
        {
            builder.RegisterComponent(this);

            // 毎フレームの更新を段階(EUpdatePhase)の順に通知する。ITickableなのでEntryPointとして登録する
            builder.RegisterEntryPoint<UpdateScheduler>();
        }

        /// <summary>
        /// 「敵を生成」ボタン:実行時に敵を生成する。
        /// AbstractScopeRoot.Instantiate を使うと、生成した敵の Awake より前に [Inject] が済む
        /// </summary>
        public void SpawnEnemy()
        {
            // 説明文と重ならないよう、画面の下側に出す
            var position = new Vector3(Random.Range(-6f, 6f), Random.Range(-3.3f, -1.6f), 0f);
            this.Instantiate(_enemyPrefab, position);
        }
    }
}
