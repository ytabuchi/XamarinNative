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
    [Activity(Label = "CustomViewActivity")]
    public class CustomListViewActivity : Activity
    {
        List<PersonTableItem> tableItem = new List<PersonTableItem>();
        ListView listView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CustomListView);

            listView = FindViewById<ListView>(Resource.Id.customListView);

            tableItem.Add(new PersonTableItem() { Name = "Yoshito Tabuchi", Age = 41, ImageResourceId = Resource.Drawable.ramen1 });

            listView.Adapter = new PersonListAdapter(this, tableItem);

            listView.ItemClick += OnListItemClick;

            var addButton = FindViewById<Button>(Resource.Id.customListViewAddButton);
            addButton.Click += (sender, e) =>
            {
                var rdm = new Random();
                tableItem.Add(new PersonTableItem() { Name = "Mr. sample", Age = 20 + rdm.Next(50), ImageResourceId = Resource.Drawable.ramen5 });

            };

            var deleteButton = FindViewById<Button>(Resource.Id.customListViewDeleteButton);
            deleteButton.Click += (sender, e) =>
            {

            };
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = tableItem[e.Position];
            Android.Widget.Toast.MakeText(this, t.Name, Android.Widget.ToastLength.Short).Show();
            Console.WriteLine("Clicked on " + t.Name);
        }
    }
}