using System.Collections.Generic;
using MyUtils;
using Projects._02_アイテムデータ;
using UnityEngine;

namespace Projects._61_リスト
{
    public class DemoList : AbstractList<DemoListItem, DemoData>
    {
        public List<DemoData> ListData;

        private void Start()
        {
            RefreshList(ListData);
        }

        protected override void OnItemClicked(DemoListItem item)
        {
            Debug.Log($"Clicked Item: {item.Index}, Name: {item.Data.Name}, Age: {item.Data.Age}");
        }
    }
}