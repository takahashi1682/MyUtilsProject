using MyUtils.AudioManager.Core;
using MyUtils.AudioManager.Manager;
using UnityEngine;

namespace Projects._43_オーディオ
{
    /// <summary>
    /// AudioManager系（BGMManager / SEManager / VoiceManager）のデモ用スクリプト
    /// BGMの再生・クロスフェード・フェードアウトと、SE / Voiceの再生、全停止をボタンから実行する
    /// </summary>
    public class AudioDemo : MonoBehaviour
    {
        [SerializeField] private AudioSetting _bgm1;
        [SerializeField] private AudioSetting _bgm2;
        [SerializeField] private AudioSetting _se;
        [SerializeField] private AudioSetting _voice;

        private AudioPlayer _currentBgmPlayer;
        private AudioSetting _currentBgmSetting;

        public void OnPlayBgm1()
        {
            _currentBgmPlayer = BGMManager.Play(_bgm1);
            _currentBgmSetting = _bgm1;
        }

        public async void OnCrossFadeToBgm2()
        {
            if (_currentBgmPlayer == null) return;

            await BGMManager.CrossFadeAsync(_currentBgmPlayer, _bgm2);
            _currentBgmSetting = _bgm2;
        }

        public async void OnFadeOutBgm()
        {
            if (_currentBgmSetting?.Clip == null) return;
            await BGMManager.FadeOutAsync(_currentBgmSetting.Clip);
        }

        public void OnPlaySE() => SEManager.Play(_se);

        public void OnPlayVoice() => VoiceManager.Play(_voice);

        public void OnStopAll()
        {
            BGMManager.StopAll();
            SEManager.StopAll();
            VoiceManager.StopAll();
        }
    }
}
