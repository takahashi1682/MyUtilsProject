using MyUtils.TalkUtils;
using UnityEngine;
using VContainer;

namespace Projects._42_会話システム
{
    public class GameTalk : MonoBehaviour
    {
        [Inject] private TalkManager _talkManager;

        private void Awake()
        {
        }
    }
}