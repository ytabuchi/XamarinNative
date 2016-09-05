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
    /// セルのViewにCustomViewを使用するListViewのサンプルです。
    /// </summary>
    [Activity(Label = "CustomView")]
    public class CustomListViewActivity : Activity
    {
        List<TableItem> tableItem = new List<TableItem>();
        ListView listView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CustomListView);

            listView = FindViewById<ListView>(Resource.Id.customListView);

            // Randomで参照するため、ResourceIdの配列を用意
            int[] images = 
            {
                Resource.Drawable.ramen1,
                Resource.Drawable.ramen2,
                Resource.Drawable.ramen3,
                Resource.Drawable.ramen4,
                Resource.Drawable.ramen5,
                Resource.Drawable.ramen6,
                Resource.Drawable.ramen7,
                Resource.Drawable.ramen8,
                Resource.Drawable.ramen9
            };

            // ソースのListにアイテムを追加
            tableItem.Insert(0, new TableItem()
            {
                Main = "Item_1",
                Sub = "Description_1",
                ImageResourceId = images[4]
            });

            // CustomAdapterを作成して適用
            var customAdapter = new CustomListAdapter(this, tableItem);
            listView.Adapter = customAdapter;

            listView.ItemClick += OnListItemClick;

            var addButton = FindViewById<Button>(Resource.Id.customListViewAddButton);
            addButton.Click += (sender, e) =>
            {
                var rdm = new Random();
                // ソースのListにアイテムを追加し、Adapterに変更を通知して画面を更新させる
                tableItem.Insert(0, new TableItem()
                {
                    Main = "Item_" + rdm.Next(),
                    Sub = "Description_" + rdm.Next(),
                    ImageResourceId = images[rdm.Next(0, 8)]
                });
                customAdapter.NotifyDataSetChanged();
            };

            var deleteButton = FindViewById<Button>(Resource.Id.customListViewDeleteButton);
            deleteButton.Click += (sender, e) =>
            {
                if (tableItem.Count > 0)
                {
                    // ソースのListからアイテムを削除し、Adapterに変更を通知して画面を更新させる
                    tableItem.Remove(tableItem[tableItem.Count - 1]);
                    customAdapter.NotifyDataSetChanged();
                }
            };
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            // ソースのアイテムを参照するだけでOK
            var t = tableItem[e.Position];
            Android.Widget.Toast.MakeText(this, t.Main, Android.Widget.ToastLength.Short).Show();
            Console.WriteLine("Clicked on " + t.Main);
        }
    }
}