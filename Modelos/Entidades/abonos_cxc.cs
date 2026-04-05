using Modelos.Entidades.molde;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Entidades
{
    class abonos_cxc : entidadMolde
    {        
        public long fk_estado_cxc { get; set; }
        public long fk_cobrador { get; set; }
        public DateTime ts_generacion { get; set; }
        public bool confirmado { get; set; }
        public DateTime ts_confirmacion { get; set; }
        public decimal monto { get; set; }
        public decimal monto_antes_aplicar { get; set; }
        public decimal monto_despues_aplicar { get; set; }

    }
}
