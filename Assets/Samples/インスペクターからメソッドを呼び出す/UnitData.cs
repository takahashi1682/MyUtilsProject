using UnityEngine;

namespace Samples.インスペクターからメソッドを呼び出す
{
    [CreateAssetMenu(fileName = "TestData", menuName = "Samples/TestData")]
    public class UnitData : ScriptableObject
    {
        public string Name = "Test";
        public int Level = 1;
        public int AttackPower = 10;
        public int DefensePower = 10;
    }
}