using Modelos.Entidades.molde;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Entidades
{
    public class productos : entidadMolde
    {
        public long FK_bodegas { get; set;}
        public int existencia { get; set; }
        public decimal precio { get; set; }
        public bodegas? Bodega { get; set; }    
    }
}
