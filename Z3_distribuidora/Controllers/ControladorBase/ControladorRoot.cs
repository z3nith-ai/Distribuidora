using Contexto;
using Microsoft.AspNetCore.Mvc;

namespace Z3_inventario.Controllers.ControladorBase
{
    public abstract class ControladorRoot:Controller
    {
        protected readonly Contexto_z3 _contexto;
        public ControladorRoot(Contexto_z3 contexto)
        {
            _contexto = contexto;
        }
    }
}
