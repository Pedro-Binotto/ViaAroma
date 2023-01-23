using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViaAroma
{
    public partial class Relatorio : Form
    {
        DataTable dataTable = new DataTable();
        public Relatorio(DataTable dataTable)
        {
            InitializeComponent();
            this.dataTable = dataTable;
        }

        private void Relatorio_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dataTable));
            this.reportViewer1.RefreshReport();
           
        }
    }
}
