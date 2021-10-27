using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Publisher
{
    public partial class FrmCompare : Form
    {
        public List<string> Files { get; set; }
        public List<string> FileInfos;
        public string Source { get; set; }

        public string Target { get; set; }
        public FrmCompare()
        {
            InitializeComponent();
            Files = new FileCollection();
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            var opd = new OpenFileDialog();
            opd.Title = "Please select source path";
            opd.CheckFileExists = false;
            opd.FileName = "(Select Folder)";
            if (opd.ShowDialog() != DialogResult.OK) return;
            txtSource.Text = Path.GetDirectoryName(opd.FileName);
        }

        private void btnTarget_Click(object sender, EventArgs e)
        {
            var opd = new OpenFileDialog();
            opd.Title = "Please select target path";
            opd.CheckFileExists = false;
            opd.FileName = "(Select Folder)";

            if (opd.ShowDialog() != DialogResult.OK) return;
            txtTarget.Text = Path.GetDirectoryName(opd.FileName);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Target = txtTarget.Text;
            Source = txtSource.Text;
            FileInfos = new DirectoryInfo(Source).GetFiles("*.*", SearchOption.AllDirectories).Select(s => s.FullName.Replace(Source, "")).ToList();
        }
    }
}
