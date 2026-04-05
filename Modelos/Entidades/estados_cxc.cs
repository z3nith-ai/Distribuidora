using Modelos.Entidades.molde;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Entidades
{
    public class estados_cxc : entidadMolde
    {        
        public long fk_cliente { get; set; }
        public decimal monto { get; set; }
    }
}
