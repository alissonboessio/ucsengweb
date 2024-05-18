using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UCSCursoWebEng.Models;

namespace UCSCursoWebEng.Repositories
{
    public class PessoaADO
    {

        const string sqlConn = "Server=DESKTOP-SVV20FT\\SQLEXPRESS;Database=UcsEngWeb;Trusted_Connection=True";

        const string SelectAll = "SELECT ID, NOME, SOBRENOME FROM PESSOAS ORDER BY NOME;";
        const string SelectById = "SELECT ID, NOME, SOBRENOME FROM PESSOAS WHERE ID = @id;";
        const string DeleteById = "DELETE FROM PESSOAS WHERE ID = @id;";
        const string InserirSql = "INSERT INTO PESSOAS (ID, NOME, SOBRENOME) VALUES (@id, @nome, @sobrenome);";
        const string AtualizarSql = "UPDATE PESSOAS SET ID = @id, NOME = @nome, SOBRENOME = @sobrenome WHERE ID = @id;";

        public List<PessoaModel> GetAll()
        {
            List<PessoaModel> pessoas = new List<PessoaModel>();

            using(SqlConnection conn = new SqlConnection(sqlConn))
            {
                SqlCommand cmd = new SqlCommand(SelectAll, conn);
            
                conn.Open();

                SqlDataReader sqlR = cmd.ExecuteReader();

                while (sqlR.Read())
                {                
                    PessoaModel p = new PessoaModel(
                        sqlR["ID"].ToString(),
                        sqlR["NOME"].ToString(),
                        sqlR["SOBRENOME"].ToString()
                     );

                    pessoas.Add(p);
                }

                sqlR.Close();
            }

            return pessoas;
        }
        public PessoaModel GetById(string id)
        {

            if (string.IsNullOrEmpty(id)) return null;

            using(SqlConnection conn = new SqlConnection(sqlConn))
            {
                SqlCommand cmd = new SqlCommand(SelectById, conn);

                cmd.Parameters.AddWithValue("id", id);

                conn.Open();
                
                SqlDataReader sqlR = cmd.ExecuteReader();

                while (sqlR.Read())
                {                
                    return new PessoaModel(
                        sqlR["ID"].ToString(),
                        sqlR["NOME"].ToString(),
                        sqlR["SOBRENOME"].ToString()
                     );

                }

                sqlR.Close();
            }

            return null;
        }

        public bool Delete(string id)
        {

            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                SqlCommand cmd = new SqlCommand(DeleteById, conn);

                cmd.Parameters.AddWithValue("id", id);

                conn.Open();

                return cmd.ExecuteNonQuery() == 1;
            }
        }
        public bool Inserir(PessoaModel p)
        {

            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                SqlCommand cmd = new SqlCommand(InserirSql, conn);

                cmd.Parameters.AddWithValue("id", Guid.NewGuid().ToString());
                cmd.Parameters.AddWithValue("nome", p.Nome);
                cmd.Parameters.AddWithValue("sobrenome", p.Sobrenome);

                conn.Open();

                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public bool Atualizar(PessoaModel p)
        {

            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                SqlCommand cmd = new SqlCommand(AtualizarSql, conn);

                cmd.Parameters.AddWithValue("id", p.Id);
                cmd.Parameters.AddWithValue("nome", p.Nome);
                cmd.Parameters.AddWithValue("sobrenome", p.Sobrenome);

                conn.Open();

                return cmd.ExecuteNonQuery() == 1;
            }
        }
    }
}