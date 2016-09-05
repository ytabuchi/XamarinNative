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
    /// �Z����View��CustomView���g�p����ListView�̃T���v���ł��B
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

            // Random�ŎQ�Ƃ��邽�߁AResourceId�̔z���p��
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

            // �\�[�X��List�ɃA�C�e����ǉ�
            tableItem.Insert(0, new TableItem()
            {
                Main = "Item_1",
                Sub = "Description_1",
                ImageResourceId = images[4]
            });

            // CustomAdapter���쐬���ēK�p
            var customAdapter = new CustomListAdapter(this, tableItem);
            listView.Adapter = customAdapter;

            listView.ItemClick += OnListItemClick;

            var addButton = FindViewById<Button>(Resource.Id.customListViewAddButton);
            addButton.Click += (sender, e) =>
            {
                var rdm = new Random();
                // �\�[�X��List�ɃA�C�e����ǉ����AAdapter�ɕύX��ʒm���ĉ�ʂ��X�V������
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
                    // �\�[�X��List����A�C�e�����폜���AAdapter�ɕύX��ʒm���ĉ�ʂ��X�V������
                    tableItem.Remove(tableItem[tableItem.Count - 1]);
                    customAdapter.NotifyDataSetChanged();
                }
            };
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            // �\�[�X�̃A�C�e�����Q�Ƃ��邾����OK
            var t = tableItem[e.Position];
            Android.Widget.Toast.MakeText(this, t.Main, Android.Widget.ToastLength.Short).Show();
            Console.WriteLine("Clicked on " + t.Main);
        }
    }
}