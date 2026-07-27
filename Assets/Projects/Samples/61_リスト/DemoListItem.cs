using MyUtils;
using Projects._1_アイテムデータ;
using UnityEngine;

namespace Projects._61_リスト
{
    public class DemoListItem : AbstractListItem<DemoData>
    {
        [SerializeField] private TMPro.TMP_Text _name;
        [SerializeField] private TMPro.TMP_Text _age;

        public override void Initialize(DemoData data)
        {
            _name.text = data.Name;
            _age.text = data.Age.ToString();
        }
    }
}