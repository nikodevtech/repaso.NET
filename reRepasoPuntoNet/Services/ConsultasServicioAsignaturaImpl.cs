using DAL;
using DAL.Entidades;
using Microsoft.EntityFrameworkCore;

namespace reRepasoPuntoNet.Services
{
    public class ConsultasServicioAsignaturaImpl : IconsultasServicioAsignatura
    {
        private readonly Contexto _contexto;

        public ConsultasServicioAsignaturaImpl(Contexto dbContext)
        {
            _contexto = dbContext;
        }


        public void ActualizarAsignatura(Asignatura asignatura)
        {
            _contexto.Asignaturas.Update(asignatura);
            _contexto.SaveChanges();
        }

        public void CrearAsignatura(Asignatura asignatura)
        {
            _contexto.Asignaturas.Add(asignatura);
            _contexto.SaveChanges();
        }

        public void EliminarAsignatura(Asignatura asignatura)
        {
            _contexto.Remove(asignatura);
            _contexto.SaveChanges();
        }

        public Asignatura ObtenerAsignaturaPorId(int id)
        {
            Asignatura? asignatura = _contexto.Asignaturas.Include(a => a.ListaEstudiantes).FirstOrDefault(a => a.Id == id);
            return asignatura == null ? throw new Exception("Asignatura no encontrada") : asignatura;
        }

        public List<Asignatura> ObtenerAsignaturas()
        {
            return _contexto.Asignaturas.Include(a => a.ListaEstudiantes).ToList();
        }
    }
}
