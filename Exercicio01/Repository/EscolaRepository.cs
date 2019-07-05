using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EscolaRepository
    {
        Conexao conexao = new Conexao();

        public void Inserir(Escola escola)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "INSERT INTO escolas (nome) VALUES (@NOME)";
            comando.Parameters.AddWithValue("@NOME", escola.Nome);
            comando.ExecuteNonQuery();

            comando.Connection.Close();
        }

        public List<Escola> ObterTodos()
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "SELECT * FROM escolas";
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            List<Escola> lista = new List<Escola>();

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                Escola escola = new Escola();
                escola.Id = Convert.ToInt32(linha["id"]);
                escola.Nome = linha["nome"].ToString();
                lista.Add(escola);
            }

            return lista;
        }

        public void Apagar(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "DELETE FROM escolas WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.ExecuteNonQuery();
            comando.Connection.Close();
                
        }

        public void Alterar(Escola escola)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "UPDATE escolas SET nome = @NOME WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", escola.Id);
            comando.Parameters.AddWithValue("@NOME", escola.Nome);
            comando.ExecuteNonQuery();
            comando.Connection.Close();

        }

        public Escola ObterPeloID(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "SELECT * FROM escolas WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());

            comando.Connection.Close();
            if (tabela.Rows.Count == 1)
            {
                DataRow linha = tabela.Rows[0];

                Escola escola = new Escola();
                escola.Id = Convert.ToInt32(linha["id"]);
                escola.Nome = linha["nome"].ToString();
                return escola;
            }
            else
            {
                return null;
            }

        }

    }
}
