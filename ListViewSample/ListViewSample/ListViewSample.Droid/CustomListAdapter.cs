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
    public class CustomListAdapter : BaseAdapter<TableItem>
    {
        List<TableItem> items;
        Activity context;
        
        public CustomListAdapter(Activity context, List<TableItem> items)
        {
            this.context = context;
            this.items = items;
        }        

        public override long GetItemId(int position)
        {
            return position;
        }
        public override TableItem this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomView, null);

            // BaseAdapter<T>の対応するプロパティを割り当て
            view.FindViewById<TextView>(Resource.Id.MainText).Text = item.Main;
            view.FindViewById<TextView>(Resource.Id.SubText).Text = item.Sub;
            view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);

            return view;
        }
    }
}