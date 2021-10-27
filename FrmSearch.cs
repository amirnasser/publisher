using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Publisher
{
    public partial class FrmSearch : Form
    {
        public string SearchFileName { get { return txtSearch.Text; } set { txtSearch.Text = value; } }
        public FrmSearch()
        {
            InitializeComponent();
        }

        private void FrmSearch_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }
    }
}
