using Cysharp.Threading.Tasks;
using MyUtils.TalkUtils;
using UnityEngine;

namespace Projects._42_会話システム
{
    /// <summary>
    /// TalkUtils（TalkManager / TalkLineViewer）のデモ用スクリプト
    /// CSVからセリフデータを読み込み、ボタン押下で会話を開始する
    /// </summary>
    public class TalkDemo : MonoBehaviour
    {
        [SerializeField] private TextAsset _csvFile;
        [SerializeField] private TalkManager _talkManager;

        private void Awake()
        {
            // CSVファイルからセリフデータを読み込む
            _talkManager.LoadCsv(_csvFile);
        }

        /// <summary>
        /// 会話を開始する
        /// </summary>
        /// <param name="key">会話のキー</param>
        public void OnStartTalk(string key) => _talkManager.TalkAsync(key).Forget();
    }
}