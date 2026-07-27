using UnityEngine;

namespace Projects._1_アイテムデータ
{
    [CreateAssetMenu(fileName = "DemoData", menuName = "MyUtilsProject/DemoData")]
    public class DemoData : ScriptableObject
    {
        public int Id;
        public string Name;
        public int Age;
    }
}