using Microsoft.Reporting.WinForms;
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
    public partial class ReciboDepositoForm : Form
    {

        public ReciboDepositoForm(Deposito deposito, Cuenta cuenta)
        {
            InitializeComponent();

            //Crea los objetos de Parametro
            ReportParameter fecha = new ReportParameter("fecha", Convert.ToString(deposito.Fecha));
            ReportParameter cajero = new ReportParameter("cajero", deposito.CajeroDeTurno.Nombre + " " + deposito.CajeroDeTurno.Apellido);
            ReportParameter pCuenta = new ReportParameter("cuenta", Convert.ToString(cuenta.id));
           
            ReportParameter monto = new ReportParameter("monto", "RD$"+Convert.ToString(deposito.Monto));
            ReportParameter idTransaccion = new ReportParameter("numeroTransaccion", Convert.ToString(deposito.ID));
            ReportParameter tipoTransaccion = new ReportParameter("tipoTransaccion", deposito.Tipo);
            

            //Le pasa los parametros al ReportViewer
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { fecha, cajero, pCuenta, monto, idTransaccion, tipoTransaccion });
        }

        private void ReciboDepositoForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
