using MyUtils.AnimatorUtils;
using R3;
using UnityEngine;

namespace Projects._31_Animatorの購読
{
    public enum EAnimatorLayer
    {
        BaseLayer = 0,
        UpperBody = 1,
    }

    public class Demo : MonoBehaviour
    {
        public AnimatorStateObserver StateObserver;
        [SerializeField] private TMPro.TextMeshProUGUI _text;

        public string IdleStateName = "Idle";
        public string LeftRotStateName = "Left Rotation";
        public string RightRotStateName = "Right Rotation";

        private void Start()
        {
            // 1. シンプルな状態監視 (Idle)
            StateObserver.IsState(IdleStateName)
                .Subscribe(isCurrent =>
                {
                    Debug.Log($"{IdleStateName} Current: {isCurrent}");
                })
                .AddTo(this);

            // 右回転の監視（レイヤー指定なし版）
            StateObserver.OnEnterState(RightRotStateName)
                .Subscribe(_ => UpdateUI($"{RightRotStateName} Entered"))
                .AddTo(this);

            StateObserver.OnExitState(RightRotStateName)
                .Subscribe(_ => UpdateUI($"{RightRotStateName} Exited"))
                .AddTo(this);

            // 左回転の監視（レイヤー指定なし版）
            StateObserver.OnEnterState(LeftRotStateName)
                .Subscribe(_ => UpdateUI($"{LeftRotStateName} Entered"))
                .AddTo(this);

            StateObserver.OnExitState(LeftRotStateName)
                .Subscribe(_ => UpdateUI($"{LeftRotStateName} Exited"))
                .AddTo(this);
            
            // 左回転の監視（UpperBody 指定版）
            // StateObserver.OnEnterState(LeftRotStateName, (int)EAnimatorLayer.UpperBody)
            //     .Subscribe(info => UpdateUI($"{LeftRotStateName} Entered, Speed:{info.StateInfo.speed}"))
            //     .AddTo(this);
            //
            // StateObserver.OnExitState(LeftRotStateName, (int)EAnimatorLayer.UpperBody)
            //     .Subscribe(info => UpdateUI($"{LeftRotStateName} Exited, Speed:{info.StateInfo.speed}"))
            //     .AddTo(this);
        }

        private void UpdateUI(string message)
        {
            if (_text != null) _text.text = message;
            Debug.Log(message);
        }
    }
}