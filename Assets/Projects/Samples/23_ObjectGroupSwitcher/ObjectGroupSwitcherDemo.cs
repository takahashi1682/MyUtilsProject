using MyUtils.ObjectGroup;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Projects._23_ObjectGroupSwitcher
{
    /// <summary>
    /// ObjectGroupSwitcher / ObjectGroup のデモ用スクリプト。
    /// ObjectGroupSwitcherはIndexで指定した1つのObjectGroupだけをSetAllActive(true)、
    /// 他をfalseにする「タブ切替UI」の典型パターンです。
    /// SetActiveObject/NextObject/PreviousObjectはIndexを変更するだけで通知を発行しないため、
    /// 呼び出し側で戻り値のIndexを見て表示を更新します。
    /// </summary>
    public class ObjectGroupSwitcherDemo : MonoBehaviour
    {
        [SerializeField] private ObjectGroupSwitcher _switcher;
        [SerializeField] private TextMeshProUGUI _statusText;
        [SerializeField] private Image[] _tabButtonImages;
        [SerializeField] private string[] _tabNames;

        private static readonly Color ActiveColor = new(0.95f, 0.75f, 0.3f, 1f);
        private static readonly Color InactiveColor = new(0.25f, 0.27f, 0.32f, 1f);

        private void Start()
        {
            UpdateDisplay(_switcher.Index);
        }

        private void UpdateDisplay(int index)
        {
            string name = index >= 0 && index < _tabNames.Length ? _tabNames[index] : index.ToString();
            _statusText.text = $"CurrentObjectIndex: {index} ({name})";

            for (int i = 0; i < _tabButtonImages.Length; i++)
            {
                if (_tabButtonImages[i] != null)
                    _tabButtonImages[i].color = i == index ? ActiveColor : InactiveColor;
            }
        }

        public void OnSelectTab0()
        {
            _switcher.SetActiveObject(0);
            UpdateDisplay(_switcher.Index);
        }

        public void OnSelectTab1()
        {
            _switcher.SetActiveObject(1);
            UpdateDisplay(_switcher.Index);
        }

        public void OnSelectTab2()
        {
            _switcher.SetActiveObject(2);
            UpdateDisplay(_switcher.Index);
        }

        public void OnNext()
        {
            _switcher.NextObject();
            UpdateDisplay(_switcher.Index);
        }

        public void OnPrevious()
        {
            _switcher.PreviousObject();
            UpdateDisplay(_switcher.Index);
        }
    }
}
