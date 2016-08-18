using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace ListViewSample.Droid
{
    [Activity(Label = "ListViewSample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ListView listView;
        ArrayAdapter simpleAdapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            listView = FindViewById<ListView>(Resource.Id.simpleListView);

            simpleAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1);
            for (var i = 0; i < 5; i++)
            {
                simpleAdapter.Add("item_" + i);
            }

            listView.Adapter = simpleAdapter;

            listView.ItemClick += OnListItemClick;

            var addButton = FindViewById<Button>(Resource.Id.mainAddButton);
            addButton.Click += (sender, e) =>
            {
                var rdm = new Random();

                simpleAdapter.Add("item_" + rdm.Next());
            };

            var deleteButton = FindViewById<Button>(Resource.Id.mainDeleteButton);
            deleteButton.Click += (sender, e) =>
            {
                if(simpleAdapter.Count > 0)
                {
                    var item = simpleAdapter.GetItem(simpleAdapter.Count - 1);
                    simpleAdapter.Remove(item);
                }
            };
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = simpleAdapter.GetItem(e.Position).ToString();
            Toast.MakeText(this, t, ToastLength.Short).Show();
            Console.WriteLine("Clicked on " + t);
        }
    }
}


