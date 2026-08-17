using MyUtils.Parameter.Basic;
using UnityEngine;

namespace Projects._27_UIBinder
{
    /// <summary>
    /// UIBinderフォルダ配下の各種バインダー（IntBinder / FloatBinder / StringBinder /
    /// FloatAnimatedBinder / SliderBinder / RateToGradientBinder / RateToTextBinder /
    /// ViewSwitchBinder / MemoryGaugeBinder）のデモ用スクリプト。
    /// ボタン操作でLife（Health）とScore（DemoScore）を増減させ、各バインダーの表示更新を確認できる。
    /// </summary>
    public class UIBinderDemo : MonoBehaviour
    {
        [SerializeField] private Health _life;
        [SerializeField] private DemoScore _score;

        [SerializeField] private int _damageAmount = 20;
        [SerializeField] private int _healAmount = 20;
        [SerializeField] private float _scoreAddAmount = 150f;
        [SerializeField] private float _scoreSubAmount = 100f;

        public void OnDamage() => _life.Sub(_damageAmount);

        public void OnHeal() => _life.Add(_healAmount);

        public void OnScoreAdd() => _score.Add(_scoreAddAmount);

        public void OnScoreSub() => _score.Sub(_scoreSubAmount);
    }
}
