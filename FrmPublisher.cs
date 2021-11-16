

namespace Publisher
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Windows.Forms;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using ICSharpCode.SharpZipLib.Zip;
    using System.Net;

    public partial class FrmPublisher : Form
    {

        #region Fields
        List<DeploymentFile> Deployments = new List<DeploymentFile>();
        DeploymentFile Deployment;
        List<string> files;
        List<string> FoundFiles = null;
        List<string> selectedFiles = new List<string>();
        string selectedPath = null;
        string searchPath = null;

        #endregion Fields

        #region Constructors

        public FrmPublisher()
        {
            InitializeComponent();
        }

        public FrmPublisher(string path)
        {
            InitializeComponent();
            if (File.Exists(path))
                using (StreamReader sr = new StreamReader(path))
                {
                    string tmp = null;
                    while ((tmp = sr.ReadLine()) != null)
                    {
                        lstFiles.Items.Add(tmp);
                    }
                }
            fillFilesList();
        }

        #endregion Constructors

        #region Properties

        public string SearchFileName
        {
            get; set;
        }

        FileCollection FileCollection = new FileCollection();

        List<string> Files
        {
            get { return files; }
            set
            {
                files = value;
                foreach (string s in value)
                {
                    lstFiles.Items.Add(s);
                }
            }
        }

        #endregion Properties

        #region Methods

        public static IEnumerable<FileInfo> GetFilesRecursive(DirectoryInfo dirInfo)
        {
            return GetFilesRecursive(dirInfo, "*.*");
        }

        public static IEnumerable<FileInfo> GetFilesRecursive(DirectoryInfo dirInfo, string searchPattern)
        {
            foreach (DirectoryInfo di in dirInfo.GetDirectories())
                foreach (FileInfo fi in GetFilesRecursive(di, searchPattern))
                    yield return fi;

            foreach (FileInfo fi in dirInfo.GetFiles(searchPattern))
                yield return fi;
        }

        public void PopulateTree(string dir, TreeNode node)
        {
            DirectoryInfo directory = new DirectoryInfo(dir);
            foreach (DirectoryInfo d in directory.GetDirectories())
            {
                TreeNodeFile t = new TreeNodeFile(d.Name, 1, 1, d.FullName, TreeNodeFile.FileType.Directroy);
                PopulateTree(d.FullName, t);
                node.Nodes.Add(t);
            }
            foreach (FileInfo f in directory.GetFiles())
            {
                TreeNodeFile t = new TreeNodeFile(f.Name, 0, 0, f.FullName, TreeNodeFile.FileType.File);
                node.Nodes.Add(t);
            }
        }

        private void addNodeToTree(string filename)
        {
            try
            {
                treeView1.Nodes.Clear();
                FileInfo fi = new FileInfo(filename.EndsWith("\\") ? filename : filename + "\\");
                treeView1.Nodes.Add(filename, filename, 2);
                PopulateTree(fi.DirectoryName, treeView1.Nodes[0]);
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void bg1_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var item in selectedFiles)
            {
                string drive = item.ToString().Substring(0, 1) + ":\\";
                string publish = selectedPath + "\\";
                string newpath = item.ToString().Replace(drive, publish);
                try
                {
                    FileInfo fi = new FileInfo(newpath);
                    Directory.CreateDirectory(fi.DirectoryName);
                    File.Copy(item.ToString(), newpath, true);
                    bg1.ReportProgress(1, "0|" + item);
                }
                catch (UnauthorizedAccessException exp)
                {
                    try
                    {
                        File.SetAttributes(newpath, File.GetAttributes(newpath) & ~(FileAttributes.Archive | FileAttributes.ReadOnly));
                        File.Delete(newpath);
                        File.Copy(item.ToString(), newpath, true);
                        bg1.ReportProgress(1, "0|" + item);

                    }
                    catch (Exception)
                    {
                        bg1.ReportProgress(1, "1|" + string.Format("Can not copy {0}, {1}", item, exp.Message));
                    }
                }
                catch (Exception exp)
                {
                    bg1.ReportProgress(1, "1|" + string.Format("Can not copy {0}, {1}", item, exp.Message));
                }

            }
        }

        private void bg1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string[] result = e.UserState.ToString().Split('|');

            listView1.Items.Insert(0, result[1], int.Parse(result[0]));
            pgbar1.Value++;
        }

        private void bg1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                pgbar1.Value = 0;
                addNodeToTree(selectedPath);
                treeView1.ExpandAll();
                if (MessageBox.Show("Do you want to see created directory structure ? ",
                    "Publisher", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(this.selectedPath);
                }
            }
            catch (Exception exp)
            {
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            FileCollection.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteSelectedItems();
            }
            catch (Exception)
            {
            }
        }

        private void btnFindChanged_Click(object sender, EventArgs e)
        {
            if(Deployment == null)
            {
                MessageBox.Show("Please select a site");
                return;
            }
            FrmChanged frmc = new FrmChanged(Deployment.Path);
            if (frmc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                searchPath = frmc.SearchPath;
                if (FileCollection.Count > 0 && MessageBox.Show("Do you want to add these file to current", "Keep Old Files", MessageBoxButtons.YesNo) == DialogResult.OK)
                {
                    FileCollection.Clear();
                    foreach (FileInfo f in frmc.Files)
                    {
                        FileCollection.Add(f.FullName);
                    }
                }
                else
                {
                    foreach (FileInfo f in frmc.Files)
                    {
                        FileCollection.Add(f.FullName);
                    }
                }
                FileCollection.FillList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fbd1.ShowDialog() == DialogResult.OK)
            {
                selectedFiles = new List<string>();
                selectedPath = fbd1.SelectedPath;
                foreach (var item in lstFiles.Items)
                {
                    selectedFiles.Add(item.ToString());
                }
                bg1.RunWorkerAsync();
            }
        }

        private void DeleteSelectedItems()
        {
            if (lstFiles.SelectedItems.Count > 0)
            {
                List<string> items = new List<string>();
                foreach (var i in lstFiles.SelectedItems)
                {
                    items.Add(i.ToString());
                }
                foreach (var item in items)
                {
                    lstFiles.Items.Remove(item);
                    FileCollection.Remove(item.ToString());
                }
            }
        }

        private void fillFilesList()
        {
            Files.Clear();
            foreach (object item in lstFiles.Items)
            {
                Files.Add(item.ToString());
            }
        }

        private string FindCommon(string path1, string path2)
        {
            string[] pth1 = path1.ToLower().Split('\\');
            string[] pth2 = path2.ToLower().Split('\\');

            string tmp = null;
            foreach (string e in pth1)
            {
                if (pth2.Contains(e))
                {
                    tmp = e;
                    break;
                }
            }
            return tmp;
        }

        private string DefaultPath { get; set; }

        private void FrmPublisher_Load(object sender, EventArgs e)
        {
            FileCollection.OnFillingList += new FileCollection.EventHandler(FileCollection_OnFillingList);
            this.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Top = 0;
            this.Left = 0;
            this.files = new List<string>();
            FillSites();

        }

        void FillSites()
        {
            Deployments = JsonConvert.DeserializeObject<List<DeploymentFile>>(File.ReadAllText("sites.dep"));
            Deployments.ForEach(d=>drpSites.Items.Add(d));
        }
        void FileCollection_OnFillingList(object sender, EventArgs e)
        {
            lstFiles.Items.Clear();
            foreach (string s in sender as FileCollection)
            {
                lstFiles.Items.Add(s);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(lstFiles.SelectedItems[0].ToString());
            }
            catch
            {

            }
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] dragdropfiles = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in dragdropfiles)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.Attributes == FileAttributes.Directory)
                {
                    DirectoryInfo dr = new DirectoryInfo(file);
                    IEnumerable<FileInfo> filesindirectory = GetFilesRecursive(dr);
                    foreach (var item in filesindirectory)
                    {
                        FileCollection.Add(item.FullName);
                    }
                    continue;
                }
                FileCollection.Add(file);
            }
            FileCollection.FillList();
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                e.Effect = DragDropEffects.All;
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedItems();
            }
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lstFiles.SelectedItems.Count > 0 && e.KeyChar == (Char)Keys.Delete)
            {
                foreach (var item in lstFiles.SelectedItems)
                {
                    lstFiles.Items.Remove(item);
                    FileCollection.Remove(item.ToString());
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItems.Count > 0)
            {
                try
                {
                    FileInfo fi = new FileInfo(lstFiles.Text);
                    FLInfo fl = new FLInfo { CreationDate = fi.CreationTime, Filename = fi.Name, Path = fi.DirectoryName, LastModifiedDate = fi.LastWriteTime, Size = fi.Length };
                    propertyGrid1.SelectedObject = fl;
                }
                catch (Exception exp)
                {
                    lblStatus.Text = exp.Message;
                }
            }
        }

        private void menuCopyFileLocation_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex > -1)
            {
                Clipboard.SetText(lstFiles.Text);
            }
        }

        private void mnuCopyFile_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex > -1)
            {
                StringCollection strFiles = new StringCollection();
                strFiles.Add(lstFiles.SelectedItem.ToString());
                Clipboard.SetFileDropList(strFiles);
            }
        }

        private void mnuCopyFolderLocation_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex > -1)
            {
                FileInfo fl = new FileInfo(lstFiles.Text);
                Clipboard.SetText(fl.DirectoryName);
            }
        }

        private void mnuOpenFolder_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex > -1)
            {
                FileInfo fl = new FileInfo(lstFiles.Text);
                System.Diagnostics.Process.Start(fl.DirectoryName);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "All Publisher files (*.pub)|*.pub";
            if (opd.ShowDialog() == DialogResult.OK)
            {

                FileInfo fi = new FileInfo(opd.FileName);
                DefaultPath = fi.DirectoryName;

                string tmp = null;
                FileCollection.Clear();
                using (StreamReader sr = new StreamReader(opd.FileName))
                {
                    while ((tmp = sr.ReadLine()) != null)
                    {
                        FileCollection.Add($"{Deployment.Path}{tmp}");
                    }
                    FileCollection.FillList();
                }
                lblStatus.Text = string.Format("File '{0}' opened", opd.FileName);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "All Publisher files (*.pub)|*.pub";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(sv.FileName);
                DefaultPath = fi.DirectoryName;

                using (StreamWriter sw = new StreamWriter(sv.FileName))
                {
                    foreach (string s in FileCollection)
                    {
                        sw.WriteLine(s.Replace(Deployment.Path, ""));
                    }
                }
                MessageBox.Show(string.Format("{0} file saved successfully.", sv.FileName), "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                fbd1.SelectedPath = DefaultPath;
                if (fbd1.ShowDialog() == DialogResult.OK)
                {

                    pgbar1.Value = 0;
                    selectedFiles = new List<string>();
                    listView1.Items.Clear();
                    selectedPath = fbd1.SelectedPath;
                    foreach (var item in lstFiles.Items)
                    {
                        selectedFiles.Add(item.ToString());
                    }
                    pgbar1.Maximum = selectedFiles.Count + 1;
                    bg1.RunWorkerAsync();
                }
            }
            catch (Exception)
            {
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog();
            if (fld.ShowDialog() == DialogResult.OK)
            {
                addNodeToTree(fld.SelectedPath);
                treeView1.ExpandAll();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.FindCommon(@"C:\websitedate", @"D:\something\else\websitedate"));
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                FLInfo fl = new FLInfo(((TreeNodeFile)treeView1.SelectedNode).Path);
                this.propertyGrid1.SelectedObject = fl;
            }
            catch (Exception)
            {
            }
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string filepath = ((TreeNodeFile)treeView1.SelectedNode).Path;
                if (e.KeyCode == Keys.Delete && MessageBox.Show(string.Format("Are you sure you want to delete {0} ?", filepath), "Delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                {
                    File.SetAttributes(filepath, File.GetAttributes(filepath) & ~(FileAttributes.Archive | FileAttributes.ReadOnly));
                    File.Delete(filepath);
                    treeView1.BeginUpdate();
                    treeView1.SelectedNode.Remove();
                    treeView1.EndUpdate();
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim().Length != 0)
            {
                FoundFiles = new List<string>();
                foreach (string item in FileCollection)
                {
                    FileInfo finfo = new FileInfo(item);
                    if (finfo.Name.ToLower().Contains(txtSearch.Text.Trim().ToLower()))
                    {
                        FoundFiles.Add(item);
                    }
                }
                lstFiles.DataSource = FoundFiles;
            }
            else
            {
                lstFiles.DataSource = FileCollection;
            }
        }

        #endregion Methods

        private void btnFindTodayFiles_Click(object sender, EventArgs e)
        {
            FrmSearchFiles frms = new FrmSearchFiles();
            if (frms.ShowDialog() == DialogResult.OK)
            {
                if (lstFiles.Items.Count > 0 &&
                    MessageBox.Show("There are some files already added do you want to remove them ?",
                    "Files", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    FileCollection.Clear();
                }

                foreach (FileInfo fileInfo in frms.SelectedFiles)
                    FileCollection.Add(fileInfo.FullName);

                FileCollection.FillList();
            }
        }

        private List<FileInfo> FindFilesInPath(string path, params DateTime[] dates)
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException(string.Format("Directory {0} not found", path));
            }

            if (dates == null || dates.Count() == 0)
            {
                throw new ArgumentException("dates can not be empty or null", "dates");
            }

            List<FileInfo> files = new List<FileInfo>();

            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] allFiles = dir.GetFiles("*.*", SearchOption.AllDirectories);

            foreach (DateTime d in dates)
            {
                var foundFilesinDate = allFiles.Where(f => f.LastWriteTime.Date == d.Date);

                if (foundFilesinDate != null || foundFilesinDate.Count() > 0)
                {
                    files.AddRange(foundFilesinDate);
                }
            }

            return files;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            var frmCompare = new FrmCompare();
            if (frmCompare.ShowDialog() != DialogResult.OK) return;

            fileinfos = frmCompare.FileInfos;
            source = frmCompare.Source;
            target = frmCompare.Target;
            pgbar1.Maximum = frmCompare.FileInfos.Count;
            pgbar1.Value = 0;
            bg2.RunWorkerAsync();
        }

        List<string> compFiles = new List<string>();
        private string source;
        private string target;
        List<string> fileinfos = new List<string>();
        private void bg2_DoWork(object sender, DoWorkEventArgs e)
        {
            var regex = new Regex(Regex.Escape("\\"));
            Parallel.ForEach(fileinfos, (file) =>
            {
                var nfile = regex.Replace(file, "", 1);
                if (File.Exists(Path.Combine(target, nfile)))
                {
                    var hash1 = CalculateHash(Path.Combine(source, nfile));
                    var hash2 = CalculateHash(Path.Combine(target, nfile));
                    if (hash1 != hash2)
                    {
                        compFiles.Add(Path.Combine(source, nfile));
                    }
                }
                else
                {
                    compFiles.Add(Path.Combine(source, nfile));
                }
                bg2.ReportProgress(1);
            });
        }

        private void bg2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbar1.Value += 1;
        }

        private void bg2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pgbar1.Value = 0;
            Files = compFiles;
        }

        public string CalculateHash(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return Encoding.UTF8.GetString(md5.ComputeHash(stream));
                }
            }
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            var text = Clipboard.GetText();
            if (string.IsNullOrEmpty(text)) return;

            var stringReader = new StringReader(text);
            string line;

            while ((line = stringReader.ReadLine()) != null)
            {
                if (File.Exists(line))
                    FileCollection.Add(line);
            }

            lstFiles.DataSource = FileCollection;
        }

        private void ChekDeployment()
        {


        }

        private async void MakeZip()
        {
            if (Deployment == null)
            {
                MessageBox.Show("Please select a site");
                return;
            }

            fillFilesList();
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "All Zip Files (*.zip)|*.zip|All files (*.*)|*.*"; //"Text files (*.txt)|*.txt|All files (*.*)|*.*"
            try
            {

                if (sv.ShowDialog() == DialogResult.OK)
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, "");
                    using (var MemoryStream = new FileStream(sv.FileName, FileMode.Create))
                    using (ZipOutputStream zipOutputStream = new ZipOutputStream(MemoryStream))
                    {
                        foreach (var f in Files)
                        {
                            var finfo = new FileInfo(f);
                            var entryname = finfo.FullName.Replace(Deployment.Path, "");
                            ZipEntry entry = new ZipEntry(ZipEntry.CleanName(entryname));

                            entry.Size = finfo.Length;

                            zipOutputStream.PutNextEntry(entry);

                            var bytes = File.ReadAllBytes(finfo.FullName);
                            zipOutputStream.Write(bytes, 0, (int)finfo.Length);
                        }

                        zipOutputStream.Finish();
                        MemoryStream.Position = 0;
                    }
                }
                MessageBox.Show($"Zip file {sv.FileName} created successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                MessageBox.Show($"Zip file {sv.FileName} could not be created. {exp.Message}", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDeploy_Click(object sender, EventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient(); ;
                if (Deployment == null)
                {
                    MessageBox.Show("Please select a site");
                    return;
                }

                this.UseWaitCursor = true;
                fillFilesList();

                if (files.Count == 0)
                    return;

                if (Deployment.Username != null)
                {
       
                    var authenticationString = $"{Deployment.Username}:{Deployment.Password}";
                    var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
                }

                client.BaseAddress = new Uri($"{Deployment.URL}wp-json/webdeploy/v1/");
                
                var request = new HttpRequestMessage(HttpMethod.Post, "");
                
                using (var MemoryStream = new MemoryStream())
                using (ZipOutputStream zipOutputStream = new ZipOutputStream(MemoryStream))
                {
                    foreach (var f in Files)
                    {
                        var finfo = new FileInfo(f);
                        var entryname = finfo.FullName.Replace(Deployment.Path, ""); //
                        ZipEntry entry = new ZipEntry(ZipEntry.CleanName(entryname));

                        entry.Size = finfo.Length;

                        zipOutputStream.PutNextEntry(entry);

                        var bytes = File.ReadAllBytes(finfo.FullName);
                        zipOutputStream.Write(bytes, 0, (int)finfo.Length);
                    }

                    zipOutputStream.Finish();
                    MemoryStream.Position = 0;
                    var canread = MemoryStream.CanRead;
                    using (var content = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
                    {
                        content.Add(new StreamContent(MemoryStream), "file", "wp-content.zip");

                        using (
                           var message =
                               await client.PostAsync($"deploy/{Deployment.ApiKey}", content))
                        {
                            //message.EnsureSuccessStatusCode();
                            var input = await message.Content.ReadAsStringAsync();
                                
                            var respons = JsonConvert.DeserializeObject<Response>(input);
                            if (respons.Success)
                            {
                                MessageBox.Show(
                                    respons.Data.Message + Environment.NewLine + "Following files backed up: " + Environment.NewLine 
                                    + string.Join(Environment.NewLine, respons.Data.Files)
                                    , "Deployed"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information
                                    );
                            }
                            else
                            {
                                MessageBox.Show(respons.Data.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                }

            }
            catch(HttpRequestException exp)
            {
                MessageBox.Show(exp.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        private void btnSaveZip_Click(object sender, EventArgs e)
        {
            MakeZip();
        }

        private void drpSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            Deployment = drpSites.SelectedItem as DeploymentFile;
            lblStatus.Text = Deployment.Name;
            System.Diagnostics.Process.Start(Deployment.Path);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstFiles.Items.Count; i++)
                lstFiles.SetSelected(i, true);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }
    }
}