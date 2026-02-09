using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class estados_cxc
    {
        public long codigo { get; set; }
        public Guid id { get; set; }
        public long fk_cliente { get; set; }
        public decimal monto { get; set; }
    }
}
