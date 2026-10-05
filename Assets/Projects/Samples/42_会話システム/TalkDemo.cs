using MyUtils.TalkUtils;
using R3;
using UnityEngine;

namespace Projects._42_会話システム
{
    /// <summary>
    /// TalkUtils（TalkManager / TalkLineViewer）のデモ用スクリプト
    /// CSVからセリフデータを読み込み、ボタン押下で会話を開始する
    /// </summary>
    public class TalkDemo : MonoBehaviour
    {
        [SerializeField] private TalkManager _talkManager;

        private void Start()
        {
            // 会話の終了はイベントで受け取る
            _talkManager.OnTalkEnd.Subscribe(_ => Debug.Log("終了")).AddTo(this);
        }

        /// <summary>
        /// 会話を開始する。会話中に押された場合の動作は TalkManager の Overlap Mode で決まる
        /// </summary>
        /// <param name="key">会話のキー</param>
        public void OnStartTalk(string key)
        {
            _talkManager.Talk(key);
        }
    }
}