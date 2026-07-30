using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Projects._0_入力
{
    public abstract class AbstractInputReader : ScriptableObject
    {
        [SerializeField] private InputActionAsset _inputActions;
        [SerializeField] private string[] _actionMapNames = { "Player", "UI" };

        protected InputActionAsset InputActions => _inputActions;
        public IReadOnlyList<string> ActionMapNames => _actionMapNames;

        public void EnableInput(int actionIndex)
            => SetMapEnabled(actionIndex, true);

        public void DisableInput(int actionIndex)
            => SetMapEnabled(actionIndex, false);

        public void EnableInput(string actionMapName)
            => SetMapEnabled(actionMapName, true);

        public void DisableInput(string actionMapName)
            => SetMapEnabled(actionMapName, false);

        protected virtual void OnEnable()
        {
            if (_inputActions == null) return;

            foreach (var actionName in _actionMapNames)
            {
                SetMapEnabled(actionName, true);
            }
        }

        protected virtual void OnDisable()
        {
            if (_inputActions == null) return;

            foreach (var actionName in _actionMapNames)
            {
                SetMapEnabled(actionName, false);
            }
        }

        protected virtual void OnDestroy()
        {
            if (_inputActions == null) return;

            foreach (var actionName in _actionMapNames)
            {
                SetMapEnabled(actionName, false);
            }
        }

        private void SetMapEnabled(int actionIndex, bool isEnabled)
        {
            if (_actionMapNames == null || actionIndex < 0 || actionIndex >= _actionMapNames.Length)
            {
                Debug.LogWarning($"{nameof(AbstractInputReader)}: Invalid action map index {actionIndex}.", this);
                return;
            }

            SetMapEnabled(_actionMapNames[actionIndex], isEnabled);
        }

        private void SetMapEnabled(string actionMapName, bool isEnabled)
        {
            if (_inputActions == null || string.IsNullOrWhiteSpace(actionMapName)) return;

            var actionMap = _inputActions.FindActionMap(actionMapName);
            if (actionMap == null)
            {
                Debug.LogWarning($"{nameof(AbstractInputReader)}: Action map '{actionMapName}' was not found.", this);
                return;
            }

            if (isEnabled)
                actionMap.Enable();
            else
                actionMap.Disable();
        }

        protected static void RegisterValueAction(InputActionReference actionReference,
            Action<InputAction.CallbackContext> callback)
        {
            var action = actionReference?.action;
            if (action == null) return;

            action.performed += callback;
            action.canceled += callback;
        }

        protected static void UnregisterValueAction(InputActionReference actionReference,
            Action<InputAction.CallbackContext> callback)
        {
            var action = actionReference?.action;
            if (action == null) return;

            action.performed -= callback;
            action.canceled -= callback;
        }

        protected static void RegisterButtonAction(InputActionReference actionReference,
            Action<InputAction.CallbackContext> callback)
        {
            var action = actionReference?.action;
            if (action == null) return;

            action.started += callback;
            action.performed += callback;
            action.canceled += callback;
        }

        protected static void UnregisterButtonAction(InputActionReference actionReference,
            Action<InputAction.CallbackContext> callback)
        {
            var action = actionReference?.action;
            if (action == null) return;

            action.started -= callback;
            action.performed -= callback;
            action.canceled -= callback;
        }
    }
}