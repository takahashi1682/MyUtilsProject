using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Projects._21_UIPrefsBinder
{
    /// <summary>
    /// UIPrefsBinder系（Slider/Toggle/Dropdown/InputField）のデモ用スクリプト。
    /// 各Binderは自身のStart()でPlayerPrefsから値を読み込み、
    /// 値変更時に自動保存まで行うため、このスクリプトが行うのは
    /// 「デフォルトに戻す」ボタンの処理のみ。
    /// </summary>
    public class UIPrefsBinderDemo : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Toggle _toggle;
        [SerializeField] private TMP_Dropdown _dropdown;
        [SerializeField] private TMP_InputField _inputField;

        [SerializeField] private float _sliderDefault = 50f;
        [SerializeField] private bool _toggleDefault;
        [SerializeField] private int _dropdownDefault;
        [SerializeField] private string _inputFieldDefault = "";

        /// <summary>
        /// 各コントロールをデフォルト値に戻す。
        /// onValueChangedが発火するため、各PrefsBinderによってPlayerPrefsにも上書き保存される。
        /// </summary>
        public void OnResetToDefaults()
        {
            _slider.value = _sliderDefault;
            _toggle.isOn = _toggleDefault;
            _dropdown.value = _dropdownDefault;
            _inputField.text = _inputFieldDefault;
        }
    }
}
