using R3;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Projects._01_入力
{
    public class PlayerInputReader : MonoBehaviour, InputSystem_Actions.IPlayerActions
    {
        [Header("Reactive Properties")]
        [SerializeField] private SerializableReactiveProperty<Vector2> _move = new();
        public ReadOnlyReactiveProperty<Vector2> Move => _move;

        [SerializeField] private SerializableReactiveProperty<Vector2> _look = new();
        public ReadOnlyReactiveProperty<Vector2> Look => _look;

        [SerializeField] private SerializableReactiveProperty<bool> _fire = new();
        public ReadOnlyReactiveProperty<bool> Fire => _fire;

        [SerializeField] private SerializableReactiveProperty<Vector2> _mousePosition = new();
        public ReadOnlyReactiveProperty<Vector2> MousePosition => _mousePosition;

        private InputSystem_Actions _actions;
        public InputSystem_Actions.PlayerActions Player { get; private set; }

        private void Awake()
        {
            _actions = new InputSystem_Actions();
            Player = _actions.Player;
            Player.AddCallbacks(this);
        }

        private void OnEnable() => Player.Enable();
        private void OnDisable() => Player.Disable();
        private void OnDestroy() => Player.Disable();

        public void OnMove(InputAction.CallbackContext context) => _move.Value = context.ReadValue<Vector2>();
        public void OnLook(InputAction.CallbackContext context) => _look.Value = context.ReadValue<Vector2>();
        public void OnFire(InputAction.CallbackContext context) => _fire.Value = context.ReadValueAsButton();

        public void OnMousePosition(InputAction.CallbackContext context)
            => _mousePosition.Value = context.ReadValue<Vector2>();
    }
}