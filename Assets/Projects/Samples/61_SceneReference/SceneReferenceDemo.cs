using MyUtils.SceneReference;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Projects._21_SceneReference
{
    /// <summary>
    /// MyUtils.SceneReference.SceneReference のデモ用スクリプト。
    /// エディタ上ではSceneAssetをドラッグ&ドロップで割り当て、実行時は内部で保持される
    /// _sceneName(文字列)だけを使ってSceneManager.LoadSceneを呼び出す、という使い方を示します。
    /// SceneAssetフィールドは#if UNITY_EDITORでのみ存在するため、ビルド後も安全に動作します。
    /// </summary>
    public class SceneReferenceDemo : MonoBehaviour
    {
        [Header("あらかじめSceneAssetを割り当て済みのSceneReference")]
        [SerializeField] private SceneReference _sceneA;
        [SerializeField] private SceneReference _sceneB;
        [SerializeField] private SceneReference _sceneC;

        [Header("SceneName表示")]
        [SerializeField] private TextMeshProUGUI _sceneAText;
        [SerializeField] private TextMeshProUGUI _sceneBText;
        [SerializeField] private TextMeshProUGUI _sceneCText;

        [Header("実行時にSetSceneNameするデモ")]
        [SerializeField] private TMP_InputField _customNameInput;
        [SerializeField] private TextMeshProUGUI _customNameResultText;

        [Header("ステータス")]
        [SerializeField] private TextMeshProUGUI _statusText;

        private readonly SceneReference _runtimeRef = new();

        private void Start()
        {
            _sceneAText.text = $"SceneName: \"{_sceneA.SceneName}\"";
            _sceneBText.text = $"SceneName: \"{_sceneB.SceneName}\"";
            _sceneCText.text = $"SceneName: \"{_sceneC.SceneName}\"";
        }

        public void OnLoadSceneA() => LoadScene(_sceneA);
        public void OnLoadSceneB() => LoadScene(_sceneB);
        public void OnLoadSceneC() => LoadScene(_sceneC);

        private void LoadScene(SceneReference sceneRef)
        {
            if (string.IsNullOrEmpty(sceneRef.SceneName))
            {
                _statusText.text = "SceneNameが未設定です";
                return;
            }

            _statusText.text = $"読込中: {sceneRef.SceneName}";
            SceneManager.LoadScene(sceneRef.SceneName);
        }

        public void OnSetCustomName()
        {
            _runtimeRef.SetSceneName(_customNameInput.text);
            _customNameResultText.text = $"SetSceneName実行後の SceneName: \"{_runtimeRef.SceneName}\"";
        }
    }
}
