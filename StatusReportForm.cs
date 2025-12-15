using System;
using System.Windows.Forms;

namespace NPC_Dialogue_Manager
{
    public partial class StatusReportForm : Form
    {
        public StatusReportForm()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
