using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        ObservableCollection<MyObject> dataSource;

        public MainPage()
        {
            InitializeComponent();
            dataSource = new ObservableCollection<MyObject>();
            dataSource.Add(new MyObject("cut"));
            dataSource.Add(new MyObject("copy"));
            dataSource.Add(new MyObject("paste"));
            dataSource.Add(new MyObject("delete"));
            gridControl1.ItemsSource = dataSource;
        }

        private void gridControl1_CustomUnboundColumnData(object sender, DevExpress.Xpf.Grid.GridColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "IconUnbound")
            {
                if (e.IsGetData)
                {
                    MyObject row = dataSource[e.ListSourceRowIndex];
                    string resourceName = GetResourceName(row.Action);
                    e.Value = GetImage(resourceName);
                }
            }
        }
        BitmapImage GetImage(string resourceName)
        {
            Uri uri = //new Uri("pack://application:,,,/Icons/" + resourceName, UriKind.Absolute);
            new Uri(App.Current.Host.Source, "Icons/" + resourceName);
            return new BitmapImage(uri);
        }
        string GetResourceName(string action)
        {
            switch (action)
            {
                case "copy":
                    return "copy32x32.png";
                case "cut":
                    return "cut32x32.png";
                case "delete":
                    return "delete32x32.png";
                case "paste":
                    return "paste32x32.png";
            }
            return string.Empty;
        }


    }
    public class MyObject
    {
        public MyObject() { }
        public MyObject(string action)
        {
            Action = action;
        }
        public string Action { get; set; }
    }

}
