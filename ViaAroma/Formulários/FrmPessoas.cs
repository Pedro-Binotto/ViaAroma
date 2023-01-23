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
    public partial class FrmPessoas : Form
    {
        int id;
        bool delete = true;
        Pessoa pessoa = new Pessoa();
        public FrmPessoas(int id, bool delete)
        {
            InitializeComponent();
            this.id = id;
            this.delete = delete;    
            if (this.id > 0)
            {
                pessoa.GetPessoaById(this.id);
                txtNome.Text = pessoa.Nome;
                txtTelefone.Text = pessoa.Telefone;
            }
            if (this.delete == true)
            {
                btnDelete.Visible = true;
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormCad_Load(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                pessoa.Nome = txtNome.Text;
                pessoa.Telefone = txtTelefone.Text;
                pessoa.Save();
                this.Close();
            }
        }

        private void tnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pessoa.Delete();
            this.Close();
        }

        private bool ValidateData()
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("informe um Nome.", Program.sis);
                txtNome.Focus();
                return false;
            }
            else if (txtTelefone.Text == "")
            {
                MessageBox.Show("informe um Telefone.", Program.sis);
                txtTelefone.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
