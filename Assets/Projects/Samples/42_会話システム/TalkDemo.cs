using MyUtils.Csv;
using MyUtils.TalkUtils;
using UnityEngine;

namespace Projects._42_会話システム
{
    /// <summary>
    /// TalkUtils（TalkManager / LineViewer）のデモ用スクリプト
    /// CSVからセリフデータを読み込み、ボタン押下で会話を開始する
    /// </summary>
    public class TalkDemo : MonoBehaviour
    {
        [SerializeField] private TextAsset _csvFile;

        private TalkData _talkData;

        private void Awake()
        {
            _talkData = new TalkData();
            _talkData.AddRange(CsvUtils<LineData>.Parse(_csvFile));
        }

        /// <summary>
        /// 一人語りの会話を開始（Key: greeting）
        /// </summary>
        public async void OnStartGreeting()
        {
            var talkManager = await TalkManager.WaitInstanceAsync;
            await talkManager.TalkAsync(_talkData.GetLines("greeting"));
        }

        /// <summary>
        /// 掛け合いの会話を開始（Key: dialogue）
        /// </summary>
        public async void OnStartDialogue()
        {
            var talkManager = await TalkManager.WaitInstanceAsync;
            await talkManager.TalkAsync(_talkData.GetLines("dialogue"));
        }
    }
}
