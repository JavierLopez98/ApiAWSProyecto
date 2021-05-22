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
    public class PartidosController : ControllerBase
    {
        PartidosRepository repo;
        public PartidosController(PartidosRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public ActionResult<List<Partidos>> GetPartidos()
        {
            return this.repo.GetPartidos();
        }
        [HttpGet("{id}")]
        public ActionResult<Partidos> BuscarPartido(int id)
        {
            return this.repo.GetPartidoId(id);
        }
        [HttpGet]
        [Route("[action]/{pagina}")]
        public ActionResult<List<Partidos>> PaginarPartidos(int pagina)
        {
            return this.repo.GetPartidosPaginados(pagina);
        }
        [HttpGet]
        [Route("[action]/{equipo}")]
        public ActionResult<List<Partidos>> PartidosEquipo(int equipo)
        {
            return this.repo.GetPartidosEquipo(equipo);
        }

        [HttpPost]
        public void CrearPartido(Partidos p)
        {
            this.repo.NuevoPartido(p.Equipo1,p.Equipo2,p.ResultadoEquipo1, p.ResultadoEquipo2, p.fecha);
            
        }
        [HttpPut]
        public void ModificarPartido(Partidos p)
        {
            this.repo.ModificarPartido(p.Id, p.Equipo1, p.Equipo2, p.ResultadoEquipo1, p.ResultadoEquipo2, p.fecha);
        }

        
    }
}
