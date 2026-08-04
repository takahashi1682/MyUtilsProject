using MyUtils.SpriteAnimation;
using TMPro;
using UnityEngine;

namespace Projects._16_スプライトアニメーション
{
    /// <summary>
    /// SpriteAnimation（SpriteRenderer向け）とImageAnimation（UI Image向け）のデモ用スクリプト。
    /// 同じスプライト配列を両方に流し込み、再生モード(One/Repeat/PingPong)とFPSを
    /// 共通コントロールで切り替えて比較できるようにしている。
    /// </summary>
    public class SpriteAnimationDemo : MonoBehaviour
    {
        [SerializeField] private SpriteAnimation _spriteAnimation;
        [SerializeField] private ImageAnimation _imageAnimation;
        [SerializeField] private TextMeshProUGUI _statusText;

        public void OnSetModeOne() => SetMode(SpriteAnimation.EMode.One);
        public void OnSetModeRepeat() => SetMode(SpriteAnimation.EMode.Repeat);
        public void OnSetModePingPong() => SetMode(SpriteAnimation.EMode.PingPong);

        public void OnPlay()
        {
            _spriteAnimation.Play();
            _imageAnimation.Play();
        }

        public void OnStop()
        {
            _spriteAnimation.Stop();
            _imageAnimation.Stop();
        }

        /// <summary>FPSスライダーから呼ばれる。FPSはPlay()開始時にしか反映されないため、都度Stop→Playし直す。</summary>
        public void OnFpsSliderChanged(float value)
        {
            _spriteAnimation.FPS = value;
            _imageAnimation.FPS = value;
            Restart();
            _statusText.text = $"Mode: {_spriteAnimation.Mode} / FPS: {value:F0}";
        }

        private void SetMode(SpriteAnimation.EMode mode)
        {
            _spriteAnimation.Mode = mode;
            _imageAnimation.Mode = (ImageAnimation.EMode)(int)mode;
            Restart();
            _statusText.text = $"Mode: {mode} / FPS: {_spriteAnimation.FPS:F0}";
        }

        /// <summary>MainProcessはコルーチン開始時にMode/FPSを読み取るため、変更を反映するにはStop→Playが必要。</summary>
        private void Restart()
        {
            _spriteAnimation.Stop();
            _imageAnimation.Stop();
            _spriteAnimation.Play();
            _imageAnimation.Play();
        }
    }
}
