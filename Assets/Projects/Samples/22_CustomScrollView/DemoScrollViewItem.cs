using MyUtils.CustomScrollView;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Projects._20_CustomScrollView
{
    public class DemoScrollViewItem : CustomScrollViewItem
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private Image _background;

        private static readonly Color NormalColor = new(0.25f, 0.27f, 0.32f, 1f);
        private static readonly Color SelectedColor = new(0.95f, 0.75f, 0.3f, 1f);

        public void Setup(string label)
        {
            if (_label != null) _label.text = label;
        }

        public void SetSelected(bool selected)
        {
            if (_background != null) _background.color = selected ? SelectedColor : NormalColor;
        }
    }
}
