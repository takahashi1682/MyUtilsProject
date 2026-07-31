using MyUtils;
using R3;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Projects._01_入力
{
    /// <summary>
    ///  Input System の入力を受け取る ScriptableObject
    ///  ScriptableObjectなので、一度ロードされるとアプリ終了まで存在し続けます
    /// </summary>
    [CreateAssetMenu(fileName = "InputReader", menuName = "MyUtilsProject/Input Reader")]
    public class PlayerInputReader : AbstractInputReader
    {
        [Header("Input Actions")]
        [SerializeField] private InputActionReference _moveAction;
        [SerializeField] private InputActionReference _lookAction;
        [SerializeField] private InputActionReference _fireAction;
        [SerializeField] private InputActionReference _mousePositionAction;

        [Header("Reactive Properties")]
        [SerializeField] private SerializableReactiveProperty<Vector2> _move = new();
        public ReadOnlyReactiveProperty<Vector2> Move => _move;

        [SerializeField] private SerializableReactiveProperty<Vector2> _look = new();
        public ReadOnlyReactiveProperty<Vector2> Look => _look;

        [SerializeField] private SerializableReactiveProperty<bool> _fire = new();
        public ReadOnlyReactiveProperty<bool> Fire => _fire;

        [SerializeField] private SerializableReactiveProperty<Vector2> _mousePosition = new();
        public ReadOnlyReactiveProperty<Vector2> MousePosition => _mousePosition;

        protected override void OnEnable()
        {
            base.OnEnable();

            RegisterVector2Action(_moveAction, _move);
            RegisterVector2Action(_lookAction, _look);
            RegisterVector2Action(_mousePositionAction, _mousePosition);
            RegisterButtonAction(_fireAction, _fire);
        }

        protected override void OnDisable()
        {
            UnregisterVector2Action(_moveAction, _move);
            UnregisterVector2Action(_lookAction, _look);
            UnregisterVector2Action(_mousePositionAction, _mousePosition);
            UnregisterButtonAction(_fireAction, _fire);

            base.OnDisable();
        }
    }
}