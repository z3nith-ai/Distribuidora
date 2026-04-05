using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Entidades.molde
{
    public class entidadMolde
    {
        [Key]
        public long codigo { get; set; }  
        public Guid id { get; set; } = Guid.NewGuid();
        public string nombre { get; set; } = "Nombre provicional";
        public bool estado { get; set; } = true;
    }
}
