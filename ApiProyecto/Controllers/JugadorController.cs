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
    public class JugadorController : ControllerBase
    {
        PartidosRepository repo;
        public JugadorController(PartidosRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public ActionResult<List<Jugador>> GetJugadores()
        {
            return this.repo.GetJugadores();
        }
        [HttpGet("{id}")]
        public ActionResult<Jugador> BuscarJugador(int id)
        {
            return this.repo.BuscarJugador(id);
        }
        [HttpGet]
        [Route("[Action]/{idequipo}")]
        public ActionResult<List<Jugador>> JugadoresEquipo(int idequipo)
        {
            return this.repo.GetJugadoresEquipo(idequipo);
        }
        [HttpGet]
        [Route("[Action]/{nick}")]
        public ActionResult<List<Jugador>> JugadorNick(String nick)
        {

            return this.repo.GetJugadorNick(nick);
        }
        [HttpGet]
        [Route("[Action]/{nick}/{equipo}")]
        public ActionResult<List<Jugador>> JugadorNickEquipo(String nick,int equipo)
        {
            return this.repo.getJugadorNickEquipo(nick, equipo);
        }
        [HttpGet]
        [Route("[Action]/{pagina}")]
        public ActionResult<List<Jugador>> PaginarJugadores(int pagina)
        {
            return this.repo.PaginarJugadores(pagina);
        }

        [HttpGet]
        [Route("[action]/{nick}/{password}")]
        public ActionResult<Jugador> ExisteJugador(String nick,String password)
        {
            return this.repo.ExisteJugador(nick, password);
        }
        [HttpPost]
        public void NuevoJugador(Jugador jug)
        {
            this.repo.NuevoJugador(jug.Nombre,jug.Nick,jug.IdEquipo,jug.Correo,jug.Password,jug.Foto);
        }
        [HttpPut]
        public void ModificarJugador(Jugador jug)
        {
            this.repo.UpdateJugador(jug.IdJugador, jug.Nombre, jug.Nick, jug.IdEquipo, jug.Correo, jug.Password, jug.Foto);
        }
        [HttpDelete("{id}")]
        public void EliminarJugador(int id)
        {
            this.repo.DeleteJugador(id);
        }
    }
}
