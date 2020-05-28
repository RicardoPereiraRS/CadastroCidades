using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
namespace CadCidades.Models

{
    public class CidadeDataAccess
    {
        string operacaoOk = "Operação executada com sucesso.";

        // retorna conexão com banco de dados
        private SqlConnection GeraConn()
        {
            return new SqlConnection(Properties.Resources.strConn);
        }


        // verifica se a cidade já está cadastrada
        static bool CidadeJaCadastrada(string uf, string nome, SqlConnection cn)
        {
            nome = nome.Trim();

            string res = cn.ExecuteScalar("SELECT count(*) FROM cidades " +
                "WHERE uf=@uf AND nome=@nome",
                new { uf = uf, nome = nome }).ToString();

            return int.Parse(res) > 0;
        }


        public string IncluirCidade(string uf, string nome)
        {
            try
            {
                uf = uf.ToUpper();

                nome = nome.Trim();

                Uf objUf = new Uf();

                if (!objUf.UfValida(uf))
                {
                    return "UF é inválida.";
                }

                using SqlConnection cn = GeraConn();

                cn.Open();

                if (CidadeJaCadastrada(uf, nome, cn))
                {
                    return "Esta cidade já está cadastrada.";
                }
                else
                {
                    cn.Execute("INSERT INTO cidades (uf,nome) " +
                        "VALUES (@uf,@nome)", new { uf = uf, nome = nome });

                    return operacaoOk;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string ExcluirCidade(string uf, string nome)
        {
            try
            {
                uf = uf.ToUpper();

                nome = nome.Trim();

                Uf objUf = new Uf();

                if (!objUf.UfValida(uf))
                {
                    return "UF é inválida.";
                }

                using SqlConnection cn = GeraConn();

                cn.Open();

                cn.Execute("DELETE FROM cidades " +
                    "WHERE uf=@uf AND nome=@nome", new { uf = uf, nome = nome });

                return operacaoOk;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        public string ExcluirCidade(int codigo)
        {
            try
            {
                using SqlConnection cn = GeraConn();

                cn.Open();

                cn.Execute("DELETE FROM cidades " +
                    "WHERE codigo=@codigo", new { codigo = codigo });

                return operacaoOk;

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string AlterarCidade(string uf, string nomeAtual, string nomeNovo)
        {
            try
            {
                nomeAtual = nomeAtual.Trim();

                nomeNovo = nomeNovo.Trim();

                uf = uf.ToUpper();

                Uf objUf = new Uf();

                if (!objUf.UfValida(uf))
                {
                    return "UF é inválida.";
                }

                using SqlConnection cn = GeraConn();

                cn.Open();

                if (CidadeJaCadastrada(uf, nomeNovo, cn))
                {
                    return "Esta cidade já está cadastrada.";
                }
                else
                {
                    cn.Execute("UPDATE cidades set uf=@uf,nome=@nomeNovo " +
                        "WHERE nome=@nomeAtual AND uf=@uf",
                        new { uf = uf, nomeNovo = nomeNovo, nomeAtual = nomeAtual });

                    return operacaoOk;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
