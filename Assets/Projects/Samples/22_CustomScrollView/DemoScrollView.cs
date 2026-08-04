using System.Collections.Generic;
using MyUtils.CustomScrollView;
using TMPro;
using UnityEngine;

namespace Projects._20_CustomScrollView
{
    /// <summary>
    /// CustomScrollView / CustomScrollViewItem のデモ用スクリプト。
    /// アイテムはID差分に応じてSpacingで斜めに展開し、MoveSpeedでゆっくり追従します（R3のSelectIdをSubscribe）。
    /// クリックで選択(Select)、選択中のアイテムを再クリックで決定(Submit)されます。
    /// </summary>
    public class DemoScrollView : CustomScrollView<DemoScrollViewItem>
    {
        [SerializeField] private List<DemoScrollViewItem> _items;
        [SerializeField] private List<string> _labels;
        [SerializeField] private TextMeshProUGUI _statusText;

        protected override List<DemoScrollViewItem> CreateAndInitializeList()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].Initialize(this, i);
                _items[i].Setup(i < _labels.Count ? _labels[i] : $"Item {i}");
            }

            return _items;
        }

        protected override void Start()
        {
            base.Start();
            HighlightSelected(_selectId.CurrentValue);
            _statusText.text = $"Select: {LabelOf(_selectId.CurrentValue)} (id={_selectId.CurrentValue})";
        }

        protected override void Select(int id)
        {
            base.Select(id);
            HighlightSelected(id);
            _statusText.text = $"Select: {LabelOf(id)} (id={id})";
        }

        protected override void Submit(int id)
        {
            base.Submit(id);
            HighlightSelected(id);
            _statusText.text = $"Submit！: 「{LabelOf(id)}」(id={id}) が決定されました";
        }

        private void HighlightSelected(int id)
        {
            foreach (var item in _items)
                item.SetSelected(item.Id == id);
        }

        private string LabelOf(int id) => id >= 0 && id < _labels.Count ? _labels[id] : id.ToString();
    }
}
