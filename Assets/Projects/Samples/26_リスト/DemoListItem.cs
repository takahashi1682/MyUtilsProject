using MyUtils.AbstractList;
using Projects._02_アイテムデータ;
using UnityEngine;

namespace Projects._61_リスト
{
    public class DemoListItem : AbstractListItem<DemoData>
    {
        [SerializeField] private TMPro.TMP_Text _indexText;
        [SerializeField] private TMPro.TMP_Text _nameText;
        [SerializeField] private TMPro.TMP_Text _ageText;

        protected override void Bind(int index, DemoData data)
        {
            _indexText.text = index.ToString();
            _nameText.text = data.Name;
            _ageText.text = data.Age.ToString();
        }
    }
}