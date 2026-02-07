using MyUtils.FeatureContainer;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Samples.画面分割_Lobby_
{
    public interface IPlayerInstance : IFeature
    {
    }

    public class PlayerInstance : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Camera _camera;
        private FeatureContainer _featureContainer;

        private void Start()
        {
            // 必要なコンポーネントを一つのコンテナにまとめる
            _featureContainer = new FeatureContainer();
            _featureContainer.TryAdd(this);
            _featureContainer.TryAdd(_playerInput);
            _featureContainer.TryAdd(transform);
            _featureContainer.TryAdd(_camera);

            // 自身にアタッチされている IPlayerInstance を実装しているコンポーネントを全て取得する
            var features = GetComponentsInChildren<IPlayerInstance>();
            // 取得した機能をコンテナに追加する
            foreach (var feature in features) _featureContainer.TryAdd(feature);

            // 取得したコンポーネントを初期化する（IPlayerInstanceのみ）
            foreach (var feature in features) feature.Initialize(_featureContainer);
        }
    }
}