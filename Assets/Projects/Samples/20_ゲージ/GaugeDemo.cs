using MyUtils.Gauge;
using MyUtils.Parameter.Basic;
using UnityEngine;

namespace Projects._20_ゲージ
{
    /// <summary>
    /// Gauge系（MemoryGauge / FillSegmentGauge）のデモ用スクリプト
    /// MemoryGaugeはMemoryGaugeBinder経由でHealthと連動して自動更新されるため、
    /// ここではライフ（Health）の増減ボタンと、FillSegmentGaugeをスライダーで直接操作する処理のみを行う
    /// </summary>
    public class GaugeDemo : MonoBehaviour
    {
        [SerializeField] private Health _health;

        [SerializeField] private FillSegmentGauge _mpGauge;
        [SerializeField] private int _maxMp = 3000;

        public void OnLoseLife() => _health.Sub(1);

        public void OnGainLife() => _health.Add(1);

        /// <summary>MPスライダーのOnValueChangedから呼び出される</summary>
        public void OnMpSliderChanged(float value)
        {
            Debug.Log(Mathf.Clamp(Mathf.RoundToInt(value), 0, _maxMp));
            _mpGauge.Current.Value = Mathf.Clamp(Mathf.RoundToInt(value), 0, _maxMp);
        }
    }
}
