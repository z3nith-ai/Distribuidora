using Contexto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Modelos.Entidades;

namespace Z3_distribuidora.Controllers
{
    public class ClientesController : Controller
    {
        private readonly Contexto_z3 _contexto;

        public ClientesController(Contexto_z3 contexto)
        {
            _contexto = contexto;   
        }

        public IActionResult Indice()
        {
            return View();
        }

        
        public async Task<IActionResult> Get([FromBody] DataManagerRequest dm)
        {
            try
            {
                var a = await _contexto.clientes.AsNoTracking().ToListAsync();
            }catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            
            // 1. Traer todos los datos
            IEnumerable<clientes> data = await _contexto.clientes.AsNoTracking().ToListAsync();
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
        public async  Task<IActionResult> Insert([FromBody] CRUDModel<clientes> nuevoCLiente)
        {
            if(nuevoCLiente == null ) return Json(new { success = false });

            try
            {
                await _contexto.clientes.AddAsync(nuevoCLiente.Value);


                await _contexto.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            


            return Json(new {success = true});
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] CRUDModel<clientes> cLienteEditado)
        {
            if (cLienteEditado == null) return Json(new { success = false });
            try
            {
                
                await _contexto.clientes.Where(cli => cli.codigo == cLienteEditado.Value.codigo)
                    .ExecuteUpdateAsync(cli => cli
                    .SetProperty(p => p.nombre, cLienteEditado.Value.nombre)
                    .SetProperty(p => p.estado, cLienteEditado.Value.estado)
                    .SetProperty(p => p.dui, cLienteEditado.Value.dui)
                    );
                                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }



            return Json(new { success = true });
        }


    }
}
