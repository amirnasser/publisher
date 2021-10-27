using System;
using System.Collections.Generic;
using System.IO;
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

namespace Publisher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DataFile Files = new DataFile();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Files;            
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hi", "Hellow window",MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void lstFiles_Drop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            var f = files.Select(f => new FileInfo(f)).ToList();
            Files.ListOfItems = f;
        }

        private void lstFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var f = ((FileInfo)lstFiles.SelectedItem);
            txtInfo.Text = $"Filename : {f.FullName}{Environment.NewLine}Last Modified: {f.LastWriteTime}{Environment.NewLine}Created: {f.CreationTime}";
        }
    }
}
