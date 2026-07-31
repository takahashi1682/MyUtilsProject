using R3;
using UnityEngine;

namespace Projects._01_入力
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerInputReader _inputReader;

        private void Start()
        {
            _inputReader.Fire
                .Where(x => x) // ボタンが押されたときだけ実行
                .Subscribe(value =>
                {
                    Debug.Log("Fire!");
                }).AddTo(this);
        }

        private void FixedUpdate()
        {
            var moveDirection = _inputReader.Move.CurrentValue;
            var moveValue = moveDirection * Time.fixedDeltaTime;
            transform.position += new Vector3(moveValue.x, moveValue.y);
        }
    }
}