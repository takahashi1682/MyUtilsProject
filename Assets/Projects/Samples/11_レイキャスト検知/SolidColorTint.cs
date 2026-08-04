using UnityEngine;

namespace Projects._15_レイキャスト検知
{
    /// <summary>
    /// 画像(Sprite)を使わずに、MeshRendererのマテリアルを単色に着色するデモ用の補助スクリプト。
    /// UISprite等をXY非等倍スケールで引き伸ばすと角が潰れて見えるため、
    /// 代わりにCubeメッシュ＋単色マテリアルで矩形を表現する。
    /// </summary>
    [RequireComponent(typeof(MeshRenderer))]
    public class SolidColorTint : MonoBehaviour
    {
        [SerializeField] private Color _color = Color.white;

        private void Awake()
        {
            var renderer = GetComponent<MeshRenderer>();
            renderer.material.color = _color;
        }
    }
}
