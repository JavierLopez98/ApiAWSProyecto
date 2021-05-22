using ApiProyecto.Models;
using ApiProyecto.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LigaController : ControllerBase
    {
        PartidosRepository repo;
        public LigaController(PartidosRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public ActionResult<List<Liga>> GetLigas()
        {
            return this.repo.GetLigas();
        }
        [HttpGet("{id}")]
        public ActionResult<Liga> BuscarLiga(int id)
        {
            return this.repo.GetLigaId(id);
        }
        [HttpGet]
        [Route("[action]/{Nombre}")]
        public ActionResult<List<Liga>> BuscarLigasNombre(String Nombre)
        {
            return this.repo.GetLigasNombre(Nombre);
        }
        [HttpPost]
        public void NuevaLiga(Liga lig)
        {
            this.repo.NuevaLiga(lig.Nombre, lig.Descripcion);
        }
        [HttpPut]
        public void ModificarLiga(Liga lig)
        {
            this.repo.ModificarLiga(lig.IdLiga, lig.Nombre, lig.Descripcion);
        }
        [HttpDelete("{id}")]
        public void EliminarLiga(int id)
        {
            this.repo.EliminarLiga(id);
        }
    }
}
