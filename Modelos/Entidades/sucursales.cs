using Modelos.Entidades.molde;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Entidades
{
    public class sucursales:entidadMolde
    {
        public ICollection<bodegas>? Bodegas { get; set; }
    }
}
