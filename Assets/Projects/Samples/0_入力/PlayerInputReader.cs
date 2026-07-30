using R3;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Projects._0_入力
{
    /// <summary>
    ///  Input System の入力を受け取る ScriptableObject
    ///  ScriptableObjectなので、一度ロードされるとアプリ終了まで存在し続けます
    /// </summary>
    [CreateAssetMenu(fileName = "InputReader", menuName = "Input System/Input Reader")]
    public class PlayerInputReader : AbstractInputReader
    {
        [SerializeField] private InputActionReference _moveAction;
        [SerializeField] private InputActionReference _lookAction;
        [SerializeField] private InputActionReference _fireAction;
        [SerializeField] private InputActionReference _mousePositionAction;

        public ReadOnlyReactiveProperty<Vector2> Move => _move;
        private readonly ReactiveProperty<Vector2> _move = new();

        public ReadOnlyReactiveProperty<Vector2> Look => _look;
        private readonly ReactiveProperty<Vector2> _look = new();

        public ReadOnlyReactiveProperty<bool> Fire => _fire;
        private readonly ReactiveProperty<bool> _fire = new();

        public ReadOnlyReactiveProperty<Vector2> MousePosition => _mousePosition;
        private readonly ReactiveProperty<Vector2> _mousePosition = new();

        protected override void OnEnable()
        {
            base.OnEnable();

            RegisterValueAction(_moveAction, OnMove);
            RegisterValueAction(_lookAction, OnLook);
            RegisterValueAction(_mousePositionAction, OnMousePosition);
            RegisterButtonAction(_fireAction, OnFire);
        }

        protected override void OnDisable()
        {
            UnregisterValueAction(_moveAction, OnMove);
            UnregisterValueAction(_lookAction, OnLook);
            UnregisterValueAction(_mousePositionAction, OnMousePosition);
            UnregisterButtonAction(_fireAction, OnFire);

            base.OnDisable();
        }

        private void OnMove(InputAction.CallbackContext context)
            => _move.Value = context.ReadValue<Vector2>();

        private void OnLook(InputAction.CallbackContext context)
            => _look.Value = context.ReadValue<Vector2>();

        private void OnFire(InputAction.CallbackContext context)
            => _fire.Value = context.ReadValueAsButton();

        private void OnMousePosition(InputAction.CallbackContext context)
            => _mousePosition.Value = context.ReadValue<Vector2>();
    }
}