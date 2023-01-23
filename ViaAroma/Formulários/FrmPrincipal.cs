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
    
    public partial class FrmPrincipal : Form
    {
        DataTable dataTable = new DataTable();
        public FrmPrincipal()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            dataTable = Pessoa.GetPessoas();
            dataGridViewPessoas.DataSource = dataTable;
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmPessoas(0, false))
            {
                frm.ShowDialog();
                dataGridViewPessoas.DataSource = Pessoa.GetPessoas();
            }
        }

        private void DataGridViewPessoas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = dataGridViewPessoas.CurrentCell.RowIndex;
            var id = Convert.ToInt32(dataGridViewPessoas.Rows[index].Cells["Id"].Value);

            using (var frm = new FrmPessoas(id, true))
            {
                frm.ShowDialog();
            }
            dataGridViewPessoas.DataSource = Pessoa.GetPessoas();
        }

        private void BtnRelatorio_Click(object sender, EventArgs e)
        {
            var dataTable = GerarDadosRelatorio();
            using(var frm = new Relatorio(dataTable))
            {
                frm.ShowDialog();
            }
        }
        private DataTable GerarDadosRelatorio()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("nome");
            dataTable.Columns.Add("telefone");

            foreach (DataGridViewRow item in dataGridViewPessoas.Rows)
            {
                dataTable.Rows.Add(item.Cells["id"].Value.ToString(),
                                   item.Cells["nome"].Value.ToString(), 
                                   item.Cells["telefone"].Value.ToString());
            }
            return dataTable;
        }
    }
}
