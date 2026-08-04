using System;
using MyUtils.HTTPUtils;
using MyUtils.JsonUtils;
using TMPro;
using UnityEngine;

namespace Projects._52_HTTP暗号化
{
    [Serializable]
    public class PlayerSaveData
    {
        public string playerName = "Player";
        public int saveCount;
    }

    [Serializable]
    public class TodoItem
    {
        public int userId;
        public int id;
        public string title;
        public bool completed;
    }

    /// <summary>
    /// HTTPUtils系（HTTPRequestUtils）とAESEncryption / EncryptedJsonFileHandlerのデモ用スクリプト。
    /// </summary>
    public class HttpAndEncryptionDemo : MonoBehaviour
    {
        private const string AesKey = "0123456789abcdef"; // 128bit = 16文字（デモ用の固定キー）
        private const string SaveFileName = "Sample18_SaveData";
        private const string TodoUrl = "https://jsonplaceholder.typicode.com/todos/1";

        [Header("AES Encryption")]
        [SerializeField] private TMP_InputField _plainTextInput;
        [SerializeField] private TextMeshProUGUI _cipherText;
        [SerializeField] private TextMeshProUGUI _ivText;
        [SerializeField] private TextMeshProUGUI _decryptedText;

        [Header("Encrypted JSON File")]
        [SerializeField] private TMP_InputField _playerNameInput;
        [SerializeField] private TextMeshProUGUI _fileStatusText;

        [Header("HTTP Request")]
        [SerializeField] private TextMeshProUGUI _httpStatusText;

        private byte[] _lastIv;
        private string _lastCipher;

        public void OnEncrypt()
        {
            _lastIv = AESEncryption.GenerateRandomIV();
            _lastCipher = AESEncryption.Encrypt(_plainTextInput.text, _lastIv, AesKey);
            _cipherText.text = _lastCipher;
            _ivText.text = AESEncryption.BytesToHex(_lastIv);
            _decryptedText.text = "-";
        }

        public void OnDecrypt()
        {
            if (_lastIv == null || string.IsNullOrEmpty(_lastCipher))
            {
                _decryptedText.text = "先に「暗号化」を実行してください";
                return;
            }

            _decryptedText.text = AESEncryption.Decrypt(_lastCipher, _lastIv, AesKey);
        }

        public void OnSaveEncryptedFile()
        {
            EncryptedJsonFileHandler<PlayerSaveData>.LoadData(out PlayerSaveData existing, SaveFileName, true, AesKey);

            var data = new PlayerSaveData
            {
                playerName = _playerNameInput.text,
                saveCount = (existing?.saveCount ?? 0) + 1
            };

            EncryptedJsonFileHandler<PlayerSaveData>.SaveData(data, SaveFileName, true, AesKey);
            _fileStatusText.text = $"暗号化して保存しました: {data.playerName} / saveCount={data.saveCount}";
        }

        public void OnLoadEncryptedFile()
        {
            bool success = EncryptedJsonFileHandler<PlayerSaveData>.LoadData(
                out PlayerSaveData data, SaveFileName, true, AesKey);

            if (success)
            {
                _playerNameInput.text = data.playerName;
                _fileStatusText.text = $"読み込み成功: {data.playerName} / saveCount={data.saveCount}";
            }
            else
            {
                _fileStatusText.text = "保存データが見つかりません（先に保存してください）";
            }
        }

        public async void OnSendGetRequest()
        {
            _httpStatusText.text = "送信中...";

            try
            {
                TodoItem result = await HTTPRequestUtils.GetAsync<TodoItem>(TodoUrl, destroyCancellationToken);
                _httpStatusText.text =
                    $"取得成功: title=\"{result.title}\" completed={result.completed} (userId={result.userId}, id={result.id})";
            }
            catch (Exception e)
            {
                _httpStatusText.text = $"エラー: {e.Message}";
            }
        }
    }
}
