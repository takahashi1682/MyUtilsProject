using R3;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
///  Input System の入力を受け取る ScriptableObject
///  ScriptableObjectなので、一度ロードされるとアプリ終了まで存在し続けます
/// </summary>
[CreateAssetMenu(fileName = "InputReader", menuName = "Input/Input Reader")]
public class InputPlayerReader : ScriptableObject, InputSystem_Actions.IPlayerActions
{
    public ReadOnlyReactiveProperty<Vector2> Move => _move;
    private readonly ReactiveProperty<Vector2> _move = new();

    public ReadOnlyReactiveProperty<Vector2> Look => _look;
    private readonly ReactiveProperty<Vector2> _look = new();

    public ReadOnlyReactiveProperty<bool> Fire => _fire;
    private readonly ReactiveProperty<bool> _fire = new();

    public ReadOnlyReactiveProperty<Vector2> MousePosition => _mousePosition;
    private readonly ReactiveProperty<Vector2> _mousePosition = new();

    private InputSystem_Actions _instance;

    private void OnEnable()
    {
        if (_instance == null)
        {
            _instance = new InputSystem_Actions();
            _instance.Player.SetCallbacks(this);
        }

        EnablePlayerInput();
    }

    // プレイヤー入力とUI入力の切り替え
    public void EnablePlayerInput() => _instance?.Player.Enable();
    public void DisablePlayerInput() => _instance?.Player.Disable();
    public void EnableUIInput() => _instance?.UI.Enable();
    public void DisableUIInput() => _instance?.UI.Disable();

    public void OnMove(InputAction.CallbackContext context)
        => _move.Value = context.ReadValue<Vector2>();

    public void OnLook(InputAction.CallbackContext context)
        => _look.Value = context.ReadValue<Vector2>();

    public void OnFire(InputAction.CallbackContext context)
        => _fire.Value = context.ReadValueAsButton();

    public void OnMousePosition(InputAction.CallbackContext context)
        => _mousePosition.Value = context.ReadValue<Vector2>();
}