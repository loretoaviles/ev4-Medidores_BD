using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresDatos
{
    public partial class PuntoCarga
    {
        public String TipoTxt
        {
            get
            {
                string texto = "";
                switch (Tipo)
                {
                    case 1:
                        texto = "Electrico";
                        break;
                    case 2: texto = "Dual";
                        break;
                }
                return texto;
            }
        }
    }
}
