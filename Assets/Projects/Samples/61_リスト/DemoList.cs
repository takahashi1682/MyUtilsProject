using System.Collections.Generic;
using MyUtils;
using Projects._1_アイテムデータ;
using UnityEngine;

namespace Projects._61_リスト
{
    public class DemoList : AbstractList<DemoData>
    {
        public List<DemoData> ListData;

        private void Start()
        {
            CreateListItems(ListData);
        }

        protected override void OnClickItem(DemoData data)
        {
            Debug.Log($"Clicked on item: {data.Name}, Age: {data.Age}");
        }
    }
}