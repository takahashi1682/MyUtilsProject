using MyUtils.PopupWindow;
using UnityEngine;

namespace Projects._25_ポップアップ
{
    public class PopupDemo : MonoBehaviour
    {
        public async void OnShowPopup()
        {
            var popup = await PopupPanel.WaitInstanceAsync;
            int answer = await popup.ShowPopupPanel("Do you Playing Game?");
            Debug.Log(answer);
        }
    }
}