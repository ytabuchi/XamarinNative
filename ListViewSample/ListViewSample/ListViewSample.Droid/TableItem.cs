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
    /// BaseAdapter<T>ÇÃå^Ç≈Ç∑ÅB
    /// </summary>
    public class TableItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ImageResourceId { get; set; }
    }
}