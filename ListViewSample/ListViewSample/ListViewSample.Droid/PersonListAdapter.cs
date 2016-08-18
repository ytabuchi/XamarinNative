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
    public class PersonListAdapter : BaseAdapter<PersonTableItem>
    {
        List<PersonTableItem> items;
        Activity context;
        
        public PersonListAdapter(Activity context, List<PersonTableItem> items)
        {
            this.context = context;
            this.items = items;
        }        

        public override long GetItemId(int position)
        {
            return position;
        }
        public override PersonTableItem this[int position]
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
            view.FindViewById<TextView>(Resource.Id.NameText).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.AgeText).Text = item.Age.ToString();
            view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);

            return view;
        }
    }
}