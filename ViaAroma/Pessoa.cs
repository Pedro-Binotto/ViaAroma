using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViaAroma
{
    internal class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public void GetPessoaById(int id)
        {
            string sql = "select * from cadastro where id=" + id;

            try
            {
                using (var conection = new MySqlConnection(Connection.stringConnection))
                {
                    conection.Open();
                    using (var dataAdapter = new MySqlCommand(sql, conection))
                    {
                        using (var dataReader = dataAdapter.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                if (dataReader.Read())
                                {
                                    this.Id = Convert.ToInt32(dataReader["id"]);
                                    this.Nome = dataReader["nome"].ToString();
                                    this.Telefone = dataReader["telefone"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Delete()
        {
            var sql = "delete from cadastro where id=" + this.Id;
            try
            {
                using (var conection = new MySqlConnection(Connection.stringConnection))
                {
                    conection.Open();
                    using (var dataAdapter = new MySqlCommand(sql, conection))
                    {
                        dataAdapter.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        public void Save()
        {
            var sql = "";
            if (this.Id == 0)
            {
                sql = "insert into cadastro (nome, telefone) values (@nome, @telefone)";

            }
            else
            {
                sql = "update cadastro set nome=@nome," +
                    " telefone=@telefone where id=" + this.Id;
            }
            try
            {
                using (var conection = new MySqlConnection(Connection.stringConnection))
                {
                    conection.Open();
                    using (var dataAdapter = new MySqlCommand(sql, conection))
                    {
                        dataAdapter.Parameters.AddWithValue("@nome", this.Nome);
                        dataAdapter.Parameters.AddWithValue("@telefone", this.Telefone);
                        dataAdapter.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public static DataTable GetPessoas()
        {
            var dataTable = new DataTable();
            string sql = "select * from teste_cadastros.cadastro";

            try
            {
                using (var conection = new MySqlConnection(Connection.stringConnection))
                {
                    conection.Open();
                    using (var dataAdapter = new MySqlDataAdapter(sql, conection))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dataTable;
        }

    }
}

