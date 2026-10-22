using MyUtils.Parameter.Basic;
using UnityEngine;

namespace Projects._40_パラメータ
{
    /// <summary>
    /// Parameter系（Health / Level / Exp）のデモ用スクリプト
    /// ボタン操作でHPの増減・経験値の獲得を行う。
    /// 経験値が上限に達したときは、上限を超えた分（余り）を次のレベルの経験値として繰り越しながらレベルアップする。
    /// </summary>
    public class ParameterDemo : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Level _level;
        [SerializeField] private Exp _exp;

        [SerializeField] private int _damageAmount = 20;
        [SerializeField] private int _healAmount = 20;
        [SerializeField] private int _expAmount = 30;

        // 起動時の値(リセット用)
        private (int Min, int Max, int Current) _healthDefault;
        private (int Min, int Max, int Current) _levelDefault;
        private (int Min, int Max, int Current) _expDefault;

        private void Start()
        {
            _healthDefault = (_health.MinValue, _health.MaxValue, _health.CurrentValue);
            _levelDefault = (_level.MinValue, _level.MaxValue, _level.CurrentValue);
            _expDefault = (_exp.MinValue, _exp.MaxValue, _exp.CurrentValue);
        }

        public void OnDamage() => _health.Sub(_damageAmount);

        public void OnHeal() => _health.Add(_healAmount);

        public void OnGainExp()
        {
            int min = _exp.Min.CurrentValue;
            int max = _exp.Max.CurrentValue;
            int capacity = max - min;
            int total = _exp.Current.CurrentValue + _expAmount;

            // 上限を超えた分だけレベルアップし、超過分（余り）は次のレベルの経験値として繰り越す
            while (capacity > 0 && total >= max)
            {
                total -= capacity;
                _level.Add(1);
            }

            _exp.SetClampValue(total);
        }

        /// <summary>
        /// 「リセット」ボタン:Initialize(min, max, current) で、最小値・最大値・現在値をまとめて起動時の値に戻す
        /// </summary>
        public void OnReset()
        {
            _health.Initialize(_healthDefault.Min, _healthDefault.Max, _healthDefault.Current);
            _level.Initialize(_levelDefault.Min, _levelDefault.Max, _levelDefault.Current);
            _exp.Initialize(_expDefault.Min, _expDefault.Max, _expDefault.Current);
        }
    }
}
