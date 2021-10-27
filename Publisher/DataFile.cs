using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Publisher
{
    public class DataFile : INotifyPropertyChanged
    {
        private IList<FileInfo> _listOfItems;
        public FileInfo selectedFile;

        public DataFile()
        {
            ListOfItems = new List<FileInfo>();
        }

        public IList<FileInfo> ListOfItems
        {
            get { return _listOfItems; }
            set
            {
                _listOfItems = value;
                NotifyPropertyChanged("ListOfItems");
            }
        }

        public FileInfo SelectedFile
        {
            get
            {
                return selectedFile;
            }
            set
            {
                selectedFile = value;
                NotifyPropertyChanged(nameof(SelectedFile));
            }
        }

        public void SetFiles(List<FileInfo> files)
        {
            files.ForEach(f => ListOfItems.Add(f));

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
