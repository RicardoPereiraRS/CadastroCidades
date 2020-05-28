using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadCidades.Models
{
    public class Uf
    {
        // verifica se a UF é válida.
        public bool UfValida(string uf)
        {
            string listaUf = "AC,AL,AP,AM,BA,CE,DF,ES,GO,MA,MT,MS,MG," +
                             "PA,PB,PR,PE,PI,RJ,RN,RS,RO,RR,SC,SP,SE,TO";

            if (uf.Contains(","))
            {
                return false;
            }

            if (uf.Length != 2)
            {
                return false;
            }

            uf = uf.ToUpper().Trim();

            return listaUf.Contains(uf);
        }

    }
}
