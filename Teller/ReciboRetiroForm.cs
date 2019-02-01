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
using Teller.Clases;

namespace Teller
{
    //Form que se muestra luego de un retiro. El recibo del retiro
    public partial class ReciboRetiroForm : Form
    {
        public ReciboRetiroForm(Retiro retiro, Cuenta cuenta)
        {
            InitializeComponent();
            //Crea los objetos de Parametro
            ReportParameter fecha = new ReportParameter("fecha", Convert.ToString(retiro.Fecha));
            ReportParameter cajero = new ReportParameter("cajero", retiro.CajeroDeTurno.Nombre + " " + retiro.CajeroDeTurno.Apellido);
            ReportParameter pCuenta = new ReportParameter("cuenta", Convert.ToString(cuenta.id));
            ReportParameter tipoCuenta = new ReportParameter("tipoCuenta", Convert.ToString(cuenta.Tipo));
            ReportParameter monto = new ReportParameter("monto", Convert.ToString(retiro.Monto));
            ReportParameter idTransaccion = new ReportParameter("numeroTransaccion", Convert.ToString(retiro.ID))
;           ReportParameter saldo = new ReportParameter("saldo", Convert.ToString(cuenta.Balance - retiro.Monto));

            //Le pasa los parametros al ReportViewer
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { fecha, cajero, pCuenta, monto, tipoCuenta, idTransaccion, saldo});
        }

        private void ReciboRetiroForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
