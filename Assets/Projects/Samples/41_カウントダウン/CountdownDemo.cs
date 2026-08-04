using MyUtils.Countdown;
using R3;
using UnityEngine;

namespace Projects._41_カウントダウン
{
    /// <summary>
    /// Countdown系（BasicTimer / StartTimer / GameTimer）のデモ用スクリプト
    /// StartTimerで開始前カウントダウンを行い、終了したら自動でGameTimerの本編カウントダウンを開始する
    /// </summary>
    public class CountdownDemo : MonoBehaviour
    {
        [SerializeField] private StartTimer _startTimer;
        [SerializeField] private GameTimer _gameTimer;

        private void Awake()
        {
            // 開始前カウントダウン（StartTimer）が終わったら、本編カウントダウン（GameTimer）を開始する
            _startTimer.OnFinish.Subscribe(_ =>
            {
                _gameTimer.ResetCountdown();
                _gameTimer.StartCountdown();
            }).AddTo(this);
        }

        public void OnStartButtonClicked()
        {
            _gameTimer.StopCountdown();
            _gameTimer.ResetCountdown();
            _startTimer.ResetCountdown();
            _startTimer.StartCountdown();
        }

        public void OnPauseButtonClicked()
        {
            _startTimer.StopCountdown();
            _gameTimer.StopCountdown();
        }

        public void OnResetButtonClicked()
        {
            _startTimer.StopCountdown();
            _startTimer.ResetCountdown();
            _gameTimer.StopCountdown();
            _gameTimer.ResetCountdown();
        }
    }
}
