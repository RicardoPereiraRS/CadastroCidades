using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadCidades.Models
{
    public class Cidade
    {
        public int Codigo { get; set; }

        public string NomeCidade { get; set; }

        public string Uf { get; set; }
    }
}
