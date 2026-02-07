using MyUtils;
using MyUtils.FeatureContainer;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Lobby
{
    /// <summary>
    /// プレイヤーの開始位置を設定するクラス
    /// </summary>
    public class PlayerPosition : MonoBehaviour, IPlayerInstance
    {
        public Vector3[] StartPositions;

        public void Initialize(FeatureContainer container)
        {
            var playerTrans = container.Get<Transform>();
            var playerInput = container.Get<PlayerInput>();

            playerTrans.position = StartPositions[playerInput.playerIndex];
        }
    }
}