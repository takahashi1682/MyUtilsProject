using System.Collections.Generic;
using System.Linq;
using MyUtils.Misc;
using MyUtils.Movement;
using TMPro;
using UnityEngine;

namespace Projects._90_小物ユーティリティ集
{
    /// <summary>
    /// MyUtilsの小物ユーティリティ群（DelayDestroy / TimeScaler / OnBecameInvisibleDestroy /
    /// GradientImage / MaterialOffsetMover / SpriteScroller / PlaySEOnSliderChanged /
    /// ProjectVersionViewer / SerializableKeyPair / CustomBounds / ParticleSystemSimulator /
    /// DelayTrack）のまとめデモ用スクリプト。ObjectMover / ObjectRotator も補助的に使用しています。
    /// </summary>
    public class MiscUtilsDemo : MonoBehaviour
    {
        [Header("① DelayDestroy")]
        [SerializeField] private GameObject _delayDestroyTemplate;
        [SerializeField] private RectTransform _delayDestroySpawnArea;

        [Header("② TimeScaler（ObjectRotatorで速度変化を可視化）")]
        [SerializeField] private GameObject _timeScalerObject;
        [SerializeField] private TextMeshProUGUI _timeScaleText;

        [Header("③ OnBecameInvisibleDestroy（ObjectMoverで画面外へ移動）")]
        [SerializeField] private GameObject _invisibleDestroyTemplate;
        [SerializeField] private Transform _invisibleDestroySpawnPoint;

        [Header("④ GradientImage")]
        [SerializeField] private GradientImage _gradientImage;

        [Header("⑨ SerializableKeyPair")]
        [SerializeField] private List<SerializableKeyPair<string, int>> _items;
        [SerializeField] private TextMeshProUGUI _itemsText;

        [Header("⑪ ParticleSystemSimulator")]
        [SerializeField] private GameObject _particleTarget;

        [Header("⑫ DelayTrack")]
        [SerializeField] private RectTransform _delayTrackTarget;
        [SerializeField] private DelayTrack _delayTrack;
        [SerializeField] private float _delayTrackMoveRange = 200f;
        [SerializeField] private float _delayTrackMoveSpeed = 100f;
        private Vector2 _delayTrackTargetOrigin;

        private static Gradient BuildGradient(Color top, Color bottom)
        {
            var gradient = new Gradient();
            gradient.SetKeys(
                new[] { new GradientColorKey(top, 0f), new GradientColorKey(bottom, 1f) },
                new[] { new GradientAlphaKey(1f, 0f), new GradientAlphaKey(1f, 1f) });
            return gradient;
        }

        private static readonly Gradient WarmGradient = BuildGradient(new Color(1f, 0.75f, 0.3f), new Color(0.85f, 0.2f, 0.15f));
        private static readonly Gradient CoolGradient = BuildGradient(new Color(0.35f, 0.75f, 1f), new Color(0.25f, 0.2f, 0.7f));

        private void Start()
        {
            _gradientImage.SetGradient(WarmGradient);

            _itemsText.text = string.Join("\n", _items.Select(pair => $"{pair.Key}: {pair.Value}"));

            _delayTrackTargetOrigin = _delayTrackTarget.anchoredPosition;
        }

        private void Update()
        {
            _timeScaleText.text = $"Time.timeScale: {Time.timeScale:F2}";

            // ⑫ DelayTrackのTargetを左右に往復させる（FollowerがDelayTrackで遅延追従する）
            float offset = Mathf.PingPong(Time.time * _delayTrackMoveSpeed, _delayTrackMoveRange) - _delayTrackMoveRange / 2f;
            _delayTrackTarget.anchoredPosition = _delayTrackTargetOrigin + new Vector2(offset, 0f);
        }

        // ---- ① DelayDestroy ----
        public void OnSpawnDelayDestroy()
        {
            var instance = Instantiate(_delayDestroyTemplate, _delayDestroySpawnArea);
            var rect = instance.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(Random.Range(-120f, 120f), Random.Range(-20f, 20f));
            instance.SetActive(true);
        }

        // ---- ② TimeScaler ----
        public void OnToggleTimeScale(bool isOn) => _timeScalerObject.SetActive(isOn);

        // ---- ③ OnBecameInvisibleDestroy ----
        public void OnSpawnInvisibleDestroy()
        {
            var instance = Instantiate(_invisibleDestroyTemplate, _invisibleDestroySpawnPoint.position, Quaternion.identity);
            instance.SetActive(true);
        }

        // ---- ④ GradientImage ----
        public void OnGradientWarm() => _gradientImage.SetGradient(WarmGradient);
        public void OnGradientCool() => _gradientImage.SetGradient(CoolGradient);

        // ---- ⑪ ParticleSystemSimulator ----
        public void OnToggleParticle(bool isOn) => _particleTarget.SetActive(isOn);

        // ---- ⑫ DelayTrack ----
        public void OnToggleDelayTrackMove(bool isOn) => _delayTrack.TrackMove = isOn ? ETrackMode.Delay : ETrackMode.None;
        public void OnToggleDelayTrackLook(bool isOn) => _delayTrack.TrackLook = isOn ? ETrackMode.Delay : ETrackMode.None;
        public void OnRotateDelayTrackTarget() => _delayTrackTarget.Rotate(0f, 0f, 90f);
    }
}
