using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuProject
{
    public partial class frmImportData : Form
    {
        public SendMessage send;
        public frmImportData()
        {
            InitializeComponent();
        }

        public frmImportData(SendMessage sender)
        {
            InitializeComponent();
            this.send = sender;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            this.send(txtDataSend.Text);
            this.Close();
        }
    }
}
