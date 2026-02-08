using MyUtils;
using MyUtils.FeatureContainer;
using UnityEngine;


namespace Samples.インスペクターからメソッドを呼び出す
{
    public class Demo : MonoBehaviour, IFeature
    {
        [SerializeField] private UnitData _testData;
        [SerializeField] private TMPro.TextMeshProUGUI _name;
        [SerializeField] private TMPro.TextMeshProUGUI _level;
        [SerializeField] private TMPro.TextMeshProUGUI _attack;
        [SerializeField] private TMPro.TextMeshProUGUI _defense;
        private UnitData _currentData;


        public void Initialize(FeatureContainer container)
        {
            _currentData = container.Get<UnitData>();
            ShowData(_currentData);
        }

        private void ShowData(UnitData data)
        {
            _name.text = $"Name: {data.Name}";
            _level.text = $"Level: {data.Level}";
            _attack.text = $"Attack: {data.AttackPower}";
            _defense.text = $"Defense: {data.DefensePower}";
        }

        /// <summary>
        /// 表示テスト用
        /// </summary>
        [InspectorButton]
        public void ShowData() => ShowData(_testData);
     
        [InspectorButton]
        public void ShowData2() => ShowData(_testData);
    }
}