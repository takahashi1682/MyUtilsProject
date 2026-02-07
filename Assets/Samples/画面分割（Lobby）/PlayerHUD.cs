using MyUtils;
using MyUtils.FeatureContainer;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Lobby
{
    /// <summary>
    /// プレイヤーのHUD処理
    /// </summary>
    public class PlayerHUD : MonoBehaviour, IPlayerInstance
    {
        [SerializeField] private TMPro.TextMeshProUGUI _playerIdText;

        public void Initialize(FeatureContainer container)
        {
            var playerInput = container.Get<PlayerInput>();
            int viewPlayerId = playerInput.playerIndex + 1;
            
            _playerIdText.text = viewPlayerId.ToString();
        }
    }
}