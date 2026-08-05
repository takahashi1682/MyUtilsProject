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
    }
}
