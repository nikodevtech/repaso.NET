using DAL.Entidades;
using Microsoft.AspNetCore.Mvc;
using reRepasoPuntoNet.Services;

namespace reRepasoPuntoNet.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly IconsultasServicioAsignatura _servicioAsignatura;
        private readonly IconsultasServicioEstudiante _servicioEstudiante;

        public EstudianteController(IconsultasServicioAsignatura servicioAsignatura, IconsultasServicioEstudiante servicioEstudiante)
        {
            _servicioAsignatura = servicioAsignatura;
            _servicioEstudiante = servicioEstudiante;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RealizarInsert() 
        {
            Estudiante estudiante = new Estudiante();
            estudiante.Nombre = "Juan";
            estudiante.Apellidos = "Perez";
            estudiante.CorreoElectronico = "sDnLd@example.com";
            estudiante.DNI = "12345678x";
            estudiante.FechaNacimiento = new DateTime(2000, 5, 15);


            Estudiante estudiante2 = new Estudiante();
            estudiante2.Nombre = "Maria";
            estudiante2.Apellidos = "Perez";
            estudiante2.CorreoElectronico = "sDnLd@example.com";
            estudiante2.DNI = "98765432x";
            estudiante2.FechaNacimiento = new DateTime(2010, 6, 30);


            _servicioEstudiante.CrearEstudiante(estudiante);
            _servicioEstudiante.CrearEstudiante(estudiante2);

            Console.WriteLine("[INFO] estudiantes insertados correctamente");

            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult EliminarEstudiante()
        {
            _servicioEstudiante.EliminarEstudiante(_servicioEstudiante.ObtenerEstudiantePorId(1));
            Console.WriteLine("[INFO] Realizado con exito un DELETE estudiante");

            return View("~/Views/Home/Index.cshtml");
        }

        [HttpGet]
        public IActionResult SelectAllEstudiantes() 
        {
            Console.WriteLine("[INFO] Realizando un SELECT * FROM estudiantes");

            List<Estudiante> estudiantes = _servicioEstudiante.ObtenerEstudiantes();

            foreach (Estudiante estudiante in estudiantes)
            {
                Console.WriteLine(estudiante.ToString());
            }
            return View("~/Views/Home/Index.cshtml"); 
        }
    }
}
