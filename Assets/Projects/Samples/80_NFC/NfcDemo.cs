using System;
using MyUtils.NfcUtils;
using R3;
using TMPro;
using UnityEngine;

namespace Projects._80_NFC
{
    /// <summary>
    /// NFCタグへのテキスト書き込み・読み込みサンプル。
    /// Windows + NFCリーダー(Sony PaSoRi RC-S380 など)が必要。
    ///
    /// 使い方:
    /// 1. NFCリーダーをPCに接続する
    /// 2. タグをリーダーに置くと、書かれている文字が自動で表示される
    /// 3. 文字を入力して「書き込み」を押すと、タグに書き込める
    /// 4. パスワードを入力して書き込むと、文字が暗号化される(読むときも同じパスワードが必要)
    /// </summary>
    public class NfcDemo : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField; // 書き込む文字を入力する欄
        [SerializeField] private TMP_InputField _passwordField; // パスワードを入力する欄(空なら暗号化しない)
        [SerializeField] private TMP_Text _displayText; // タグの文字や、エラーを表示

        private NfcWatcher _watcher;

        private void Start()
        {
            _watcher = new NfcWatcher();
            _watcher.AddTo(this);

            // 0.5秒ごとに、タグが置かれているかを調べる
            Observable.Interval(TimeSpan.FromSeconds(0.5))
                .Subscribe(_ => _watcher.CheckCard())
                .AddTo(this);

            // 入力されたパスワードを、読み書きに使う
            _passwordField.OnValueChangedAsObservable()
                .Subscribe(password => _watcher.Password = password)
                .AddTo(this);

            // できごとを受け取って、画面に表示する
            _watcher.OnCardRead.Subscribe(text => _displayText.text = "タグの文字: " + text).AddTo(this);
            _watcher.OnNoCard.Subscribe(_ => _displayText.text = "タグをリーダーに置いてください").AddTo(this);
            _watcher.OnWritten.Subscribe(text => _displayText.text = "書き込みました: " + text).AddTo(this);
            _watcher.OnError.Subscribe(message => _displayText.text = message).AddTo(this);
        }

        /// <summary>
        /// 「書き込み」ボタン:入力した文字をタグに書き込む
        /// </summary>
        public void OnClickWrite()
        {
            _watcher.Write(_inputField.text);
        }
    }
}
