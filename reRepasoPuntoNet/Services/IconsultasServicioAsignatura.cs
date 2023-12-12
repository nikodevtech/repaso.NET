using DAL.Entidades;

namespace reRepasoPuntoNet.Services
{
    public interface IconsultasServicioAsignatura
    {
        public List<Asignatura> ObtenerAsignaturas();
        public Asignatura ObtenerAsignaturaPorId(int id);

        public void CrearAsignatura(Asignatura asignatura);

        public void EliminarAsignatura(Asignatura asignatura);

        public void ActualizarAsignatura(Asignatura asignatura);
    }
}
