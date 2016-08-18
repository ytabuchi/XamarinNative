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
    public class PersonTableItem
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

    }
}