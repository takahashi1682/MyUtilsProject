using MyUtils;
using MyUtils.FeatureContainer;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Lobby
{
    /// <summary>
    /// プレイヤーのカメラ設定
    /// </summary>
    public class PlayerCameraSetting : MonoBehaviour, IPlayerInstance
    {
        public Rect[] ViewPorts =
        {
            new(0f, 0.5f, 0.5f, 0.5f), // 1 Player - Left Top
            new(0.5f, 0.5f, 0.5f, 0.5f), // 2 Players - Right Top
            new(0f, 0f, 0.5f, 0.5f), // 2 Players - Left Bottom
            new(0.5f, 0f, 0.5f, 0.5f), // 3 Players - Right Top
        };

        public Color32[] BackgroundColors =
        {
            new(190, 100, 125, 255),
            new(100, 125, 190, 255),
            new(190, 125, 100, 255),
            new(125, 190, 100, 255),
        };

        public void Initialize(FeatureContainer container)
        {
            var playerInput = container.Get<PlayerInput>();
            var currentCamera = container.Get<Camera>();

            currentCamera.rect = ViewPorts[playerInput.playerIndex];
            currentCamera.backgroundColor = BackgroundColors[playerInput.playerIndex];
        }
    }
}