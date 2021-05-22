using ApiProyecto.Data;
using ApiProyecto.Helpers;
using ApiProyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProyecto.Repositories
{
    
    public class PartidosRepository
    {
        PartidosContext context;
        public PartidosRepository(PartidosContext context)
        {
            this.context = context;
        }
        #region Equipo

        public List<Equipo> GetEquipos()
        {
            return this.context.Equipos.ToList();
        }

        public Equipo GetEquipoId(int id) 
        {
            return GetEquipos().SingleOrDefault(x => x.IdEquipo == id);
        }
        
        public int GetMaxIdEquipo()
        {
            return this.context.Equipos.Max(x => x.IdEquipo);
        }

        public void CreateEquipo(String nombre,int Liga, String foto)
        {
            Equipo eq = new Equipo();
            eq.IdEquipo = this.GetMaxIdEquipo()+1;
            eq.Nombre = nombre;
            eq.Liga = Liga;
            eq.Foto = foto;
            this.context.Equipos.Add(eq);
            this.context.SaveChanges();
        }
        public void ModificarEquipo(int id,String nombre,int Liga,String foto)
        {
            Equipo eq = this.GetEquipoId(id);
            eq.Nombre = nombre;
            eq.Liga = Liga;
            eq.Foto = foto;
            this.context.SaveChanges();
        }
        public void EliminarEquipo(int id)
        {
            Equipo eq = this.GetEquipoId(id);
            this.context.Equipos.Remove(eq);
            this.context.SaveChanges();
        }
        public List<Equipo> GetEquiposLigas(int idliga)
        {
            return this.context.Equipos.Where(x => x.Liga == idliga).ToList();
        }

        #endregion 
        #region Jugador

        public List<Jugador> GetJugadores()
        {
            return this.context.Jugadores.ToList();
        }
        public Jugador BuscarJugador(int id)
        {
            return this.GetJugadores().SingleOrDefault(x => x.IdJugador == id);
        }

        public List<Jugador> GetJugadoresEquipo(int idequipo)
        {
            return GetJugadores().Where(x => x.IdEquipo == idequipo).ToList();
        }

        public List<Jugador> getJugadorNickEquipo(String nick, int equipo)
        {
            return this.context.Jugadores.Where(x => x.Nick.Contains(nick) && x.IdEquipo == equipo).ToList();
        }
        public List<Jugador> GetJugadorNick(String nick)
        {
            return this.GetJugadores().Where(x => x.Nick.Contains(nick)).ToList();
        }
        public List<Jugador> PaginarJugadores(int pagina)
        {
            return this.context.Jugadores.Where(x=>x.IdJugador>0).Page(6, pagina).ToList();
        }

        public Jugador ExisteJugador(String nick, String password)
        {
            return this.context.Jugadores.SingleOrDefault(x => x.Nick == nick && x.Password==password);
        }

        public int GetMaxIdJugador()
        {
            return this.context.Jugadores.Max(x => x.IdJugador);
        }

        public void NuevoJugador(String nombre,String nick,int idEquipo,String correo,String password,String foto)
        {
            Jugador jug = new Jugador();
            jug.IdJugador = this.GetMaxIdJugador()+1;
            jug.Nombre = nombre;
            jug.Nick = nick;
            jug.IdEquipo = idEquipo;
            jug.Correo = correo;
            jug.Password = password;
            jug.Foto = foto;
            this.context.Jugadores.Add(jug);
            this.context.SaveChanges();
        }
        public void UpdateJugador(int idJugador, String nombre, String nick, int idEquipo, String correo, String password, String foto)
        {
            Jugador jug = this.BuscarJugador(idJugador);
            jug.Nombre = nombre;
            jug.Nick = nick;
            jug.IdEquipo = idEquipo;
            jug.Correo = correo;
            jug.Password = password;
            jug.Foto = foto;
            this.context.SaveChanges();
        }

        public void CambiarContraseña(int idJugador,String password)
        {
            Jugador jug = this.BuscarJugador(idJugador);
            jug.Password = password;
            this.context.SaveChanges();
        }
        public void DeleteJugador(int idJugador)
        {
            Jugador jug = this.BuscarJugador(idJugador);
            this.context.Jugadores.Remove(jug);
            this.context.SaveChanges();
        }

        


        #endregion 
        #region Liga
        public List<Liga> GetLigas()
        {
            return this.context.Ligas.ToList();
        }
        public Liga GetLigaId(int id)
        {
            return this.context.Ligas.Where(x => x.IdLiga == id).FirstOrDefault();
        }
        public List<Liga> GetLigasNombre(String nombre)
        {
            return this.context.Ligas.Where(x => x.Nombre.Contains(nombre)).ToList();
        }

        public int GetMaxIdLiga()
        {
            return this.context.Ligas.Max(x => x.IdLiga);
        }

        public void NuevaLiga(String nombre,String descripcion)
        {
            Liga lig = new Liga();
            lig.IdLiga = this.GetMaxIdLiga()+1;
            lig.Nombre = nombre;
            lig.Descripcion = descripcion;
            this.context.Add(lig);
            this.context.SaveChanges();
        }
        public void ModificarLiga(int id, String nombre, String descripcion)
        {
            Liga lig = this.GetLigaId(id);
            lig.Nombre = nombre;
            lig.Descripcion = descripcion;
            
            this.context.SaveChanges();
        }
        public void EliminarLiga(int id)
        {
            Liga lig = this.GetLigaId(id);
            this.context.Ligas.Remove(lig);
            this.context.SaveChanges();
        }
        #endregion
        #region Partidos

            public List<Partidos> GetPartidos()
        {
            return this.context.Partidos.ToList();
        }
        public Partidos GetPartidoId(int id)
        {
            return this.context.Partidos.Where(z => z.Id == id).SingleOrDefault();
        }
        public List<Partidos> GetPartidosPaginados(int pagina)
        {
            return this.context.Partidos.Page(6, pagina).ToList();
        }

        public List<Partidos> GetPartidosEquipo(int equipo)
        {
            return this.context.Partidos.Where(x => x.Equipo1 == equipo || x.Equipo2 == equipo).ToList();
        }
        public void NuevoPartido(int equipo1, int equipo2, int resultado1, int resultado2, String fecha)
        {
            Partidos partido = new Partidos();
            partido.Id = this.MaxIdPartidos()+1;
            partido.Equipo1 = equipo1;
            partido.Equipo2 = equipo2;
            partido.ResultadoEquipo1 = resultado1;
            partido.ResultadoEquipo2 = resultado2;
            partido.fecha = fecha;
            this.context.Partidos.Add(partido);
            this.context.SaveChanges();
        }

        public int MaxIdPartidos()
        {
            return this.context.Partidos.Max(x => x.Id);
        }

        public void ModificarPartido(int id, int equipo1, int equipo2, int resultado1, int resultado2, String fecha)
        {
            Partidos game = this.GetPartidoId(id);
            game.Equipo1 = equipo1;
            game.Equipo2 = equipo2;
            game.ResultadoEquipo1 = resultado1;
            game.ResultadoEquipo2 = resultado2;
            game.fecha = fecha;
            this.context.SaveChanges();
        }
        #endregion 
    }
}
