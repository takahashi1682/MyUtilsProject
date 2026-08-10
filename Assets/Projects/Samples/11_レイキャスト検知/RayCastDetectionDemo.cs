using MyUtils.Detection;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Projects._11_レイキャスト検知
{
    /// <summary>
    /// RayCastDetection系（RayCastDetection / LineCastDetection / BoxCastDetection / SphereCastDetection / CapsuleCastDetection）のデモ用スクリプト
    /// WASDでプレイヤー（青い四角）を自由に動かし、各センサーのON/OFFをリアルタイムに確認できる。
    /// </summary>
    public class RayCastDetectionDemo : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private Transform _player;
        [SerializeField] private float _moveSpeed = 4f;
        [SerializeField] private Vector2 _moveLimitMin = new(-6.3f, -3f);
        [SerializeField] private Vector2 _moveLimitMax = new(7.5f, 1.5f);

        [Header("Sensors")]
        [SerializeField] private RayCastDetection _groundDetection;
        [SerializeField] private LineCastDetection _wallDetection;
        [SerializeField] private BoxCastDetection _holeDetection;
        [SerializeField] private SphereCastDetection _sphereDetection;
        [SerializeField] private CapsuleCastDetection _capsuleDetection;

        [Header("Status UI")]
        [SerializeField] private TextMeshProUGUI _groundStatusText;
        [SerializeField] private TextMeshProUGUI _wallStatusText;
        [SerializeField] private TextMeshProUGUI _holeStatusText;
        [SerializeField] private TextMeshProUGUI _sphereStatusText;
        [SerializeField] private TextMeshProUGUI _capsuleStatusText;

        private void Awake()
        {
            _groundDetection.IsHit.Subscribe(v => SetStatus(_groundStatusText, "IsGround", v)).AddTo(this);
            _wallDetection.IsHit.Subscribe(v => SetStatus(_wallStatusText, "IsWall", v)).AddTo(this);

            // HoleDetectionはBoxCastが「何かに当たった」= 足場がある状態を表すため、
            // 「穴（足場が無い）」を意味するIsHoleは当たり判定を反転させたもの。
            _holeDetection.IsHit.Subscribe(v => SetStatus(_holeStatusText, "IsHole", !v)).AddTo(this);

            // SphereCastDetectionで足元の地面を丸い形状で検知するデモ（GroundA/Bと同じ対象）。
            _sphereDetection.IsHit.Subscribe(v => SetStatus(_sphereStatusText, "IsSphereHit", v)).AddTo(this);

            // CapsuleCastDetectionで進行方向の壁をカプセル形状で検知するデモ（Wallと同じ対象）。
            _capsuleDetection.IsHit.Subscribe(v => SetStatus(_capsuleStatusText, "IsCapsuleHit", v)).AddTo(this);
        }

        private void Update()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            var keyboard = Keyboard.current;
            if (keyboard == null) return;

            Vector2 input = Vector2.zero;
            if (keyboard.aKey.isPressed) input.x -= 1;
            if (keyboard.dKey.isPressed) input.x += 1;
            if (keyboard.wKey.isPressed) input.y += 1;
            if (keyboard.sKey.isPressed) input.y -= 1;

            if (input.sqrMagnitude <= 0f) return;

            Vector3 next = _player.position + (Vector3)(input.normalized * (_moveSpeed * Time.deltaTime));
            next.x = Mathf.Clamp(next.x, _moveLimitMin.x, _moveLimitMax.x);
            next.y = Mathf.Clamp(next.y, _moveLimitMin.y, _moveLimitMax.y);
            _player.position = next;
        }

        private static void SetStatus(TextMeshProUGUI text, string label, bool value)
        {
            text.text = $"{label}: {(value ? "TRUE" : "FALSE")}";
            text.color = value ? new Color(0.4f, 1f, 0.5f) : new Color(1f, 0.4f, 0.4f);
        }
    }
}
