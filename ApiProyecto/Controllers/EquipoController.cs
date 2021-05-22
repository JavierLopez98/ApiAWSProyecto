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
    public class EquipoController : ControllerBase
    {
        PartidosRepository repo;
        public EquipoController(PartidosRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public ActionResult<List<Equipo>> GetEquipos()
        {
            return this.repo.GetEquipos();
        }
        [HttpGet("{id}")]
        public ActionResult<Equipo> BuscarEquipo(int id)
        {
            return this.repo.GetEquipoId(id);
        }
        [HttpGet]
        [Route("[action]/{liga}")]
        public List<Equipo> BuscarEquiposLiga(int liga)
        {
            return this.repo.GetEquiposLigas(liga);
        }
        
        [HttpPost]
        public void CrearEquipo(Equipo eq)
        {
            this.repo.CreateEquipo(eq.Nombre, eq.Liga, eq.Foto);
        }
        [HttpPut]
        public void ModificarEquipo(Equipo eq)
        {
            this.repo.ModificarEquipo(eq.IdEquipo,eq.Nombre,eq.Liga,eq.Foto);
        }
        [HttpDelete("id")]
        public void EliminarEquipo(int id)
        {
            this.repo.EliminarEquipo(id);
        }
    }
}
