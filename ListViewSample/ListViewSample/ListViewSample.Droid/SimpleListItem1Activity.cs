using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ListViewSample.Droid
{
    /// <summary>
    /// セルのViewにSimpleListItem1を使用するListViewのサンプルです。
    /// </summary>
    [Activity(Label = "SimpleListItem1")]
    public class SimpleListItem1Activity : Activity
    {
        ListView listView;
        ArrayAdapter simpleAdapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SimpleListItem1);

            listView = FindViewById<ListView>(Resource.Id.simpleListView);

            // ListViewのAdapterを用意
            simpleAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1);
            simpleAdapter.Add("Item_1");
            // Adapterを適用
            listView.Adapter = simpleAdapter;

            listView.ItemClick += OnListItemClick;

            var addButton = FindViewById<Button>(Resource.Id.mainAddButton);
            addButton.Click += (sender, e) =>
            {
                var rdm = new Random();
                // Adapterに対してstringを追加
                simpleAdapter.Insert("Item_" + rdm.Next(), 0);
            };

            var deleteButton = FindViewById<Button>(Resource.Id.mainDeleteButton);
            deleteButton.Click += (sender, e) =>
            {
                if (simpleAdapter.Count > 0)
                {
                    // Adapterの最後のアイテムをRemove
                    var item = simpleAdapter.GetItem(simpleAdapter.Count - 1);
                    simpleAdapter.Remove(item);
                }
            };
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            // Adapter内にデータがあるので、タップ行のデータをGetItemで取得
            var t = simpleAdapter.GetItem(e.Position).ToString();
            Toast.MakeText(this, t, ToastLength.Short).Show();
            Console.WriteLine("Clicked on " + t);
        }
    }
}