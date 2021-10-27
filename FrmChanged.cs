using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Publisher
{
    public partial class FrmChanged : Form
    {

        public string SearchPath { get { return lblLocation.Text; } set { lblLocation.Text = value; if (lblLocation.Text.Length > 0) btnOk.Enabled = true; } }
        private List<FileInfo> foundFiles;
        FolderBrowserDialog fld = new FolderBrowserDialog();
        public List<FileInfo> Files { get { return foundFiles; } }

        public FrmChanged(string searchPath)
        {
            InitializeComponent();
            if (searchPath != null)
            {
                fld.SelectedPath = searchPath;
                SearchPath = searchPath;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtFilter.Text.Trim().Length==0)
                findFiles("*.*");
            else if(txtFilter.Text.Contains("|"))
            {
                string[] filters = txtFilter.Text.Split('|');
                foreach(string f in filters)
                    findFiles(f);           
            }
            else
            {
                findFiles(txtFilter.Text.Trim());
            }
        }

        private void findFiles(string filter)
        {
            if (lblLocation.Text.Length > 0)
            {
                DirectoryInfo dinfo = new DirectoryInfo(SearchPath);
                FileInfo[] files = dinfo.GetFiles(filter, SearchOption.AllDirectories);

                DateTime start = new DateTime(dtStart.Value.Year, dtStart.Value.Month, dtStart.Value.Day, 0, 0, 0, 0, DateTimeKind.Local);
                DateTime end = new DateTime(dtEnd.Value.Year, dtEnd.Value.Month, dtEnd.Value.Day, 23, 59, 59, 0, DateTimeKind.Local); 

                foundFiles = files.Where(f => (f.LastWriteTime >= start && f.LastWriteTime <= end)).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectSource();
        }

        private void selectSource()
        {            
            if (fld.ShowDialog() == DialogResult.OK)
            {
                SearchPath = fld.SelectedPath;
            }
        }

        private void FrmChanged_Load(object sender, EventArgs e)
        {
            dtStart.Value = DateTime.Now.AddDays(-7);
        }
    }
}
