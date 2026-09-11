using MyUtils.UI;
using TMPro;
using UnityEngine;

namespace Projects._28_UIViewToggler
{
    /// <summary>
    /// UIViewToggler / UISelectedOnEnable のデモ用スクリプト。
    /// UIViewTogglerで複数のGameObjectを一括で表示/非表示に切り替える。
    /// 切り替え対象のパネルにはUISelectedOnEnableもアタッチされており、
    /// パネルが有効化されるたびに指定したボタンが自動選択される。
    /// </summary>
    public class UIViewTogglerDemo : MonoBehaviour
    {
        [SerializeField] private UIViewToggler _viewToggler;
        [SerializeField] private TextMeshProUGUI _statusText;

        public void OnShowPanel()
        {
            _viewToggler.ToggleView(true);
            _statusText.text = "Panel: ON（ButtonBが自動選択されます）";
        }

        public void OnHidePanel()
        {
            _viewToggler.ToggleView(false);
            _statusText.text = "Panel: OFF";
        }
    }
}
