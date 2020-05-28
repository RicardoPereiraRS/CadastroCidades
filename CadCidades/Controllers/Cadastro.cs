using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using CadCidades.Models;
using Microsoft.AspNetCore.Mvc;


namespace CadCidades.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Cadastro : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Cadastro de cidades, use parâmetros.";
        }

        [HttpPost]
        public string Post(string uf, string nome)
        {
            CidadeDataAccess cd = new CidadeDataAccess();
            return cd.IncluirCidade(uf, nome);
        }

        [HttpPut]
        public string Put(string uf, string nomeAtual, string nomeNovo)
        {
            CidadeDataAccess cd = new CidadeDataAccess();
            return cd.AlterarCidade(uf, nomeAtual, nomeNovo);
        }

        [HttpDelete]
        public string Delete(int codigo, string uf, string nome)
        {
            CidadeDataAccess cd = new CidadeDataAccess();
            if (codigo > 0)
            {   // deletar por código
                return cd.ExcluirCidade(codigo);
            }
            else
            {   // deletar por uf e nome da cidade
                return cd.ExcluirCidade(uf, nome);
            }
        }

    }
}
