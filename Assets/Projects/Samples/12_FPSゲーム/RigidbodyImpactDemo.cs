using MyUtils;
using UnityEngine;

namespace Projects._12_FPSゲーム
{
    /// <summary>
    /// MyUtils.RigidbodyImpact のデモ用スクリプト。
    /// ボタンから呼び出すとRigidbodyを持つボールを生成し、RigidbodyImpactが
    /// Startのタイミングで指定したForceをそのままlinearVelocityとして与える。
    /// </summary>
    public class RigidbodyImpactDemo : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Material _ballMaterial;
        [SerializeField] private float _lifeTime = 4f;
        [SerializeField] private Vector3 _force = new(0f, 6f, 6f);
        [SerializeField] private bool _isGlobal = true;

        public void OnLaunchBall()
        {
            var ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            ball.name = "RigidbodyImpactBall";
            ball.transform.SetPositionAndRotation(_spawnPoint.position, _spawnPoint.rotation);
            ball.transform.localScale = Vector3.one * 0.5f;

            if (_ballMaterial != null)
            {
                ball.GetComponent<Renderer>().material = _ballMaterial;
            }

            ball.AddComponent<Rigidbody>();

            var impact = ball.AddComponent<RigidbodyImpact>();
            impact.Force = _force;
            impact.IsGlobal = _isGlobal;

            Destroy(ball, _lifeTime);
        }
    }
}
