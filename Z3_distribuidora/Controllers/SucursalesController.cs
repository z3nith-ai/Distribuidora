using Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos.Entidades;
using Syncfusion.EJ2.Base;
using System.Diagnostics;
using Z3_inventario.Controllers.ControladorBase;


namespace Z3_inventario.Controllers
{
    public class SucursalesController : ControladorRoot
    {        
        public SucursalesController(Contexto_z3 db) : base(db) { }
        public ActionResult Indice()
        {
            return View();
        }
        public async Task<IActionResult> Get([FromBody] DataManagerRequest dm)
        {           
            // 1. Traer todos los datos
            IEnumerable<sucursales> data = await _contexto.sucursales.AsNoTracking().ToListAsync();

            int totalCount = data.Count();

            var Do = new DataOperations();          // 2. Búsqueda (Search)
            if (dm.Search != null && dm.Search.Count > 0)
            {
                data = Do.PerformSearching(data, dm.Search);
            }

            // 3. Filtrado (Filter)
            if (dm.Where != null && dm.Where.Count > 0)
            {
                data = Do.PerformFiltering(data, dm.Where, dm.Where[0].Operator);
            }

            // 4. Ordenamiento (Sort)
            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                data = Do.PerformSorting(data, dm.Sorted);
            }

            // 5. Total después de filtros (para paginación correcta)
            totalCount = data.Count();

            // 6. Paginación (debe ir al final)
            if (dm.Skip != 0)
            {
                data = Do.PerformSkip(data, dm.Skip);
            }
            if (dm.Take != 0)
            {
                data = Do.PerformTake(data, dm.Take);
            }

            return Ok(new { result = data, count = totalCount });
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CRUDModel<sucursales> nuevoRegistro)
        {
            await _contexto.sucursales.AddAsync(nuevoRegistro.Value);
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] CRUDModel<sucursales> registroEditado)
        {
            await _contexto.sucursales.ExecuteUpdateAsync(suc => suc
            .SetProperty(p => p.nombre, registroEditado.Value.nombre)
            .SetProperty(p => p.estado, registroEditado.Value.estado)
            );
            
            return Json(new { success = true });
        }
    }
}
