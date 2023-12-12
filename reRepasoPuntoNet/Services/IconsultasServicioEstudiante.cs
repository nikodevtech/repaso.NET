using DAL.Entidades;

namespace reRepasoPuntoNet.Services
{
    public interface IconsultasServicioEstudiante
    {

        public List<Estudiante> ObtenerEstudiantes();
        public Estudiante ObtenerEstudiantePorId(int id);

        public void CrearEstudiante(Estudiante estudiante);

        public void ActualizarEstudiante(Estudiante estudiante);

        public void EliminarEstudiante(Estudiante estudiante);
    }
}
