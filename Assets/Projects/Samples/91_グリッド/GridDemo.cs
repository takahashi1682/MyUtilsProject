using System;
using MyUtils.Abstract;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Projects._91_グリッド
{
    /// <summary>
    /// MyUtils.Abstract.AbstractGrid&lt;TCell&gt; のデモ用スクリプト。
    /// Width×Heightのセルを、座標(x, -y)でインデックスされた1次元配列として生成・管理する
    /// 汎用グリッドの共通実装を、クリックでON/OFFを切り替えるセル一覧に応用した例。
    /// </summary>
    public class GridDemo : MonoBehaviour
    {
        private class CellData
        {
            public Button Button;
            public Image Image;
            public bool IsOn;
        }

        private class CellGrid : AbstractGrid<CellData>
        {
            public CellGrid(int width, int height, Func<Vector2Int, CellData> createCell)
                : base(width, height, createCell)
            {
            }
        }

        [SerializeField] private int _width = 4;
        [SerializeField] private int _height = 4;
        [SerializeField] private Button _cellTemplate;
        [SerializeField] private RectTransform _cellParent;
        [SerializeField] private TextMeshProUGUI _statusText;
        [SerializeField] private float _cellSpacing = 110f;

        private static readonly Color OnColor = new(0.95f, 0.75f, 0.3f, 1f);
        private static readonly Color OffColor = new(0.22f, 0.24f, 0.28f, 1f);

        private CellGrid _grid;

        private void Start()
        {
            _cellTemplate.gameObject.SetActive(false);
            _grid = new CellGrid(_width, _height, CreateCell);
            _statusText.text = "セルをクリックしてください";
        }

        private CellData CreateCell(Vector2Int pos)
        {
            var button = Instantiate(_cellTemplate, _cellParent);
            button.gameObject.SetActive(true);

            var rect = button.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(pos.x * _cellSpacing, pos.y * _cellSpacing);

            var label = button.GetComponentInChildren<TextMeshProUGUI>();
            if (label != null)
            {
                label.text = $"{pos.x},{-pos.y}";
            }

            var cell = new CellData
            {
                Button = button,
                Image = button.GetComponent<Image>(),
            };
            cell.Image.color = OffColor;

            button.onClick.AddListener(() => OnCellClicked(pos));
            return cell;
        }

        private void OnCellClicked(Vector2Int pos)
        {
            var cell = _grid.GetCell(pos);
            cell.IsOn = !cell.IsOn;
            cell.Image.color = cell.IsOn ? OnColor : OffColor;
            _statusText.text = $"Selected: ({pos.x}, {-pos.y}) -> {(cell.IsOn ? "ON" : "OFF")}";
        }

        public void OnClearAll()
        {
            foreach (var cell in _grid.Cells)
            {
                cell.IsOn = false;
                cell.Image.color = OffColor;
            }
            _statusText.text = "クリアしました";
        }
    }
}
