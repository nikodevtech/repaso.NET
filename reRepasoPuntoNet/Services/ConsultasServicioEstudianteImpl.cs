using DAL;
using DAL.Entidades;
using Microsoft.EntityFrameworkCore;

namespace reRepasoPuntoNet.Services
{
    public class consultasServicioEstudianteImpl : IconsultasServicioEstudiante
    {
        private readonly Contexto _contexto;
        public consultasServicioEstudianteImpl(Contexto dbContext)
        {
            _contexto = dbContext;
        }

        public void ActualizarEstudiante(Estudiante estudiante)
        {
            _contexto.Estudiantes.Update(estudiante);
            _contexto.SaveChanges();
        }

        public void CrearEstudiante(Estudiante estudiante)
        {
            _contexto.Estudiantes.Add(estudiante);
            _contexto.SaveChanges();
        }

        public void EliminarEstudiante(Estudiante estudiante)
        {
            _contexto.Estudiantes.Remove(estudiante);
            _contexto.SaveChanges();
        }

        public Estudiante ObtenerEstudiantePorId(int id)
        {
            Estudiante? estudiante = _contexto.Estudiantes.Include(e => e.ListaAsignaturas).FirstOrDefault(e => e.Id == id);
            return estudiante == null ? throw new Exception("Estudiante no encontrado") : estudiante;
        }

        public List<Estudiante> ObtenerEstudiantes()
        {
            return _contexto.Estudiantes.Include(e => e.ListaAsignaturas).ToList();
        }
    }
}
