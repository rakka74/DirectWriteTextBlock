using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DirectWriteTextBlockApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        class ListViewItem
        {
            public string text { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();

            var itemsSrc = new List<ListViewItem>();
            for (int ni = 0; ni < 1000; ++ni)
            {
                itemsSrc.Add(new ListViewItem() { text = ni.ToString() });
            }
            listView.DataContext = itemsSrc;
        }
    }
}
