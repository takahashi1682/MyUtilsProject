using MyUtils.FadeScreen;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Projects._19_FadeScreen
{
    /// <summary>
    /// FadeScreenManager / FadeSetting のデモ用スクリプト。
    /// FadeScreenManagerは自前でDontDestroyOnLoadなCanvas（sortingOrder 9999）を生成し、
    /// BeginFadeOut / BeginFadeInで画面全体を塗りつぶす/消すシングルトンです。
    /// </summary>
    public class FadeScreenDemo : MonoBehaviour
    {
        [Header("Fade Settings")]
        [SerializeField] private TextMeshProUGUI _durationValueText;
        [SerializeField] private TextMeshProUGUI _statusText;

        [Header("Background (擬似シーン)")]
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private TextMeshProUGUI _backgroundLabel;

        private static readonly Color[] BackgroundColors =
        {
            new(0.16f, 0.28f, 0.55f),
            new(0.55f, 0.18f, 0.24f),
            new(0.18f, 0.5f, 0.32f),
        };

        private static readonly string[] BackgroundLabels = { "SCENE A", "SCENE B", "SCENE C" };

        private float _duration = 0.5f;
        private Color _fadeColor = Color.black;
        private int _sceneIndex;

        public void OnDurationChanged(float value)
        {
            _duration = value;
            _durationValueText.text = $"Duration: {value:F2}s";
        }

        public void OnSetColorBlack() => SetFadeColor(Color.black, "Black");
        public void OnSetColorWhite() => SetFadeColor(Color.white, "White");
        public void OnSetColorRed() => SetFadeColor(new Color(0.8f, 0.1f, 0.1f), "Red");

        private void SetFadeColor(Color color, string name)
        {
            _fadeColor = color;
            _statusText.text = $"フェードカラー: {name}";
        }

        public async void OnFadeOut()
        {
            _statusText.text = "フェードアウト中...";
            await FadeScreenManager.BeginFadeOut(new FadeSetting { Duration = _duration, Color = _fadeColor });
            _statusText.text = "フェードアウト完了（画面が塗りつぶされています）";
        }

        public async void OnFadeIn()
        {
            _statusText.text = "フェードイン中...";
            await FadeScreenManager.BeginFadeIn(new FadeSetting { Duration = _duration, Color = _fadeColor });
            _statusText.text = "フェードイン完了";
        }

        public async void OnSimulateSceneChange()
        {
            _statusText.text = "シーン切替デモ：フェードアウト中...";
            await FadeScreenManager.BeginFadeOut(new FadeSetting { Duration = _duration, Color = _fadeColor });

            _sceneIndex = (_sceneIndex + 1) % BackgroundColors.Length;
            _backgroundImage.color = BackgroundColors[_sceneIndex];
            _backgroundLabel.text = BackgroundLabels[_sceneIndex];

            _statusText.text = "シーン切替デモ：フェードイン中...";
            await FadeScreenManager.BeginFadeIn(new FadeSetting { Duration = _duration, Color = _fadeColor });
            _statusText.text = $"切替完了: {BackgroundLabels[_sceneIndex]}";
        }
    }
}
