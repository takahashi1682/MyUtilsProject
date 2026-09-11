using MyUtils.Gauge;
using MyUtils.Parameter.Basic;
using UnityEngine;

namespace Projects._20_ゲージ
{
    /// <summary>
    /// Gauge系（MemoryGauge / FillSegmentGauge / UI.Gauge）のデモ用スクリプト
    /// MemoryGaugeはMemoryGaugeBinder経由でHealthと連動して自動更新されるため、
    /// ここではライフ（Health）の増減ボタンと、FillSegmentGaugeをスライダーで直接操作する処理のみを行う。
    /// UI.Gauge（HPバー）はValue(0〜1)をボタンから直接増減し、サブゲージ（ダメージ表示）が
    /// ゆっくり追従する様子を確認できる。
    /// </summary>
    public class GaugeDemo : MonoBehaviour
    {
        [SerializeField] private Health _health;

        [SerializeField] private FillSegmentGauge _mpGauge;
        [SerializeField] private int _maxMp = 3000;

        [SerializeField] private MyUtils.UI.Gauge _hpBarGauge;

        public void OnLoseLife() => _health.Sub(1);

        public void OnGainLife() => _health.Add(1);

        /// <summary>MPスライダーのOnValueChangedから呼び出される</summary>
        public void OnMpSliderChanged(float value)
        {
            Debug.Log(Mathf.Clamp(Mathf.RoundToInt(value), 0, _maxMp));
            _mpGauge.Current.Value = Mathf.Clamp(Mathf.RoundToInt(value), 0, _maxMp);
        }

        public void OnHpBarDamage() => _hpBarGauge.Value -= 0.2f;
        public void OnHpBarHeal() => _hpBarGauge.Value += 0.2f;
        public void OnHpBarFull() => _hpBarGauge.Value = 1f;
    }
}
