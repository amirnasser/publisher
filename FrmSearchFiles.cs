namespace Publisher
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    //using Framework;

    public partial class FrmSearchFiles : Form
    {
        #region Fields

        public readonly string ProjectFilename = Path.Combine(Application.StartupPath, "Projects.xml");

        public List<FileInfo> SelectedFiles = new List<FileInfo>();

        #endregion Fields

        #region Constructors

        public FrmSearchFiles()
        {
            InitializeComponent();
            Projects = new ProjectCollection();
        }

        #endregion Constructors

        #region Properties

        private List<DateFiles> FilesInDate
        {
            get; set;
        }

        private Projects Project
        {
            get; set;
        }

        private ProjectCollection Projects
        {
            get; set;
        }

        private List<DateTime> SelectedDates
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtPath.Text))
            {
                lstProjects.SelectedItems[0].SubItems[0].Text = txtName.Text;
                lstProjects.SelectedItems[0].SubItems[1].Text = txtPath.Text;
                SaveProjects();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Project = Projects[lstProjects.SelectedIndices[0]];
        }

        private void FrmSearchFiles_Load(object sender, EventArgs e)
        {
            LoadProject();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedFiles = new List<FileInfo>();
            foreach (var item in lstDates.SelectedItems)
            {
                DateTime dt = ((DateFiles)item).Date;
                var files = FilesInDate.FirstOrDefault(d => d.Date == dt);
                SelectedFiles.AddRange(files.Files);
            }
            if (SelectedFiles != null)
            {
                lstFiles.DataSource = SelectedFiles.Select(f => f.FullName).ToList();
            }
        }

        private void LoadProject()
        {            
            Projects = Framework.Serializer.XmlDerserialize<ProjectCollection>(ProjectFilename);
            foreach (var p in Projects)
            {
                lstProjects.Items.Add(new ListViewItem(new string[] { p.Name, p.Path }));
            }
        }

        private void lstProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProjects.SelectedItems.Count > 0 && lstProjects.SelectedItems[0].SubItems[0] != null)
            {
                txtName.Text = lstProjects.SelectedItems[0].SubItems[0].Text;
                txtPath.Text = lstProjects.SelectedItems[0].SubItems[1].Text;
                PopulateDates(lstProjects.SelectedItems[0].SubItems[1].Text);
            }
        }

        private void PopulateDates(string path)
        {
            lstDates.DataSource = null;
            if (Directory.Exists(path))
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                var files = dir.GetFiles("*.*", SearchOption.AllDirectories);
                FilesInDate = files.GroupBy(g => g.LastWriteTime.Date,
                    (g, f) => new DateFiles { Date = g, Files = f.ToList() }).OrderByDescending(o => o.Date).ToList();

                lstDates.DisplayMember = "DateString";
                lstDates.DataSource = FilesInDate;
            }
        }

        private void SaveProjects()
        {
            ProjectCollection projects = new ProjectCollection();
            foreach (ListViewItem item in lstProjects.Items)
            {
                projects.Add(new Projects { Name = item.SubItems[0].Text, Path = item.SubItems[1].Text });
            }
            Framework.Serializer.XmlSerialize<ProjectCollection>(projects, ProjectFilename);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.FileName = "Select Path.";
            opd.CheckFileExists = false;

            if (opd.ShowDialog() == DialogResult.OK)
            {
                string path = Path.GetDirectoryName(opd.FileName);
                PopulateDates(path);
            }
        }

        private void txtPath_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.FileName = "Select Path.";
            opd.CheckFileExists = false;

            if (opd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = Path.GetDirectoryName(opd.FileName);
            }
        }

        #endregion Methods

        #region Nested Types

        public class DateFiles
        {
            #region Constructors

            public DateFiles()
            {
                Files = new List<FileInfo>();
            }

            #endregion Constructors

            #region Properties

            public DateTime Date
            {
                get; set;
            }

            public List<FileInfo> Files
            {
                get; set;
            }

            #endregion Properties

            #region Methods

            public override string ToString()
            {
                return Date.ToString("yyyy-MM-dd dddd");
            }

            #endregion Methods
        }

        #endregion Nested Types
    }
}