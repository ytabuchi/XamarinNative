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
    [Activity(Label = "ListView Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(SimpleListItem1Activity));
                StartActivity(intent);
            };

            var button2 = FindViewById<Button>(Resource.Id.button2);
            button2.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(CustomListViewActivity));
                StartActivity(intent);
            };
        }
    }
}


