using UnityEngine;

namespace Projects._02_キー入力でオブジェクトの表示を切り替える
{
    /// <summary>
    /// UnityEventOnKeyTriggerのOnTriggerから呼び出し、対象オブジェクトの表示/非表示を切り替えるデモ用スクリプト
    /// </summary>
    public class ToggleObjectDemo : MonoBehaviour
    {
        [SerializeField] private GameObject _target;

        public void Toggle()
        {
            if (_target == null) return;
            _target.SetActive(!_target.activeSelf);
        }
    }
}
