using MyUtils.Misc;
using TMPro;
using UnityEngine;

namespace Projects._92_デバッグフラグ
{
    /// <summary>
    /// DebugFlag のデモ用スクリプト。
    /// メニューの Window > MyUtils > Debug Flag Window でフラグを切り替える。
    /// Flag 1 をオンにするとダメージを受けなくなり、Flag 2 をオンにするとデバッグ用パネルが表示される。
    /// </summary>
    public class DebugFlagDemo : MonoBehaviour
    {
        // フラグの番号に名前を付けておくと、何のフラグか分かりやすい
        private const int InvincibleFlag = 1;
        private const int PanelFlag = 2;

        [SerializeField] private int _maxHp = 100;
        [SerializeField] private int _damage = 10;
        [SerializeField] private TextMeshProUGUI _statusText;
        [SerializeField] private TextMeshProUGUI _hpText;
        [SerializeField] private GameObject _debugPanel;

        private int _hp;

        private void Start() => SetHp(_maxHp);

        private void Update()
        {
            // 再生中でもウィンドウから切り替えられるので、毎フレーム確認する
            _statusText.text = DebugFlag.IsOn(InvincibleFlag) ? "Flag 1 無敵: オン" : "Flag 1 無敵: オフ";
            _debugPanel.SetActive(DebugFlag.IsOn(PanelFlag));
        }

        /// <summary>「ダメージを受ける」ボタン</summary>
        public void OnDamage()
        {
            // 無敵のフラグがオンの間は、ダメージを受けない
            if (DebugFlag.IsOn(InvincibleFlag)) return;

            SetHp(Mathf.Max(_hp - _damage, 0));
        }

        /// <summary>「HPを戻す」ボタン</summary>
        public void OnReset() => SetHp(_maxHp);

        private void SetHp(int hp)
        {
            _hp = hp;
            _hpText.text = $"HP: {_hp}";
        }
    }
}
