using MyUtils;
using R3;
using UnityEngine;

namespace Projects._41_カウントダウン
{
    /// <summary>
    /// BasicTimer(ETimerType.Countdown)のデモ用スクリプト
    /// _startTimerで開始前カウントダウンを行い、終了したら自動で_gameTimerの本編カウントダウンを開始する
    /// </summary>
    public class CountdownDemo : MonoBehaviour
    {
        [SerializeField] private BasicTimer _startTimer;
        [SerializeField] private BasicTimer _gameTimer;

        private void Awake()
        {
            // 開始前カウントダウン(_startTimer)が終わったら、本編カウントダウン(_gameTimer)を開始する
            _startTimer.OnFinish.Subscribe(_ =>
            {
                _gameTimer.ResetTimer();
                _gameTimer.StartTimer();
            }).AddTo(this);
        }

        public void OnStartButtonClicked()
        {
            _gameTimer.StopTimer();
            _gameTimer.ResetTimer();
            _startTimer.ResetTimer();
            _startTimer.StartTimer();
        }

        public void OnPauseButtonClicked()
        {
            _startTimer.StopTimer();
            _gameTimer.StopTimer();
        }

        public void OnResetButtonClicked()
        {
            _startTimer.StopTimer();
            _startTimer.ResetTimer();
            _gameTimer.StopTimer();
            _gameTimer.ResetTimer();
        }
    }
}
