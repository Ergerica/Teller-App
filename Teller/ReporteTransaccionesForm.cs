using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teller
{
    public partial class ReporteTransaccionesForm : Form
    {
        public ReporteTransaccionesForm()
        {
            InitializeComponent();
        }

        private void ReporteTransaccionesForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'TellerLocalDataSet.tblTransacciones' table. You can move, or remove it, as needed.
            this.tblTransaccionesTableAdapter.Fill(this.TellerLocalDataSet.tblTransacciones);

            this.reportViewer1.RefreshReport();
        }
    }
}
