using DAL.Entidades;
using Microsoft.AspNetCore.Mvc;
using reRepasoPuntoNet.Services;

namespace reRepasoPuntoNet.Controllers
{
    public class AsignaturaController : Controller
    {
        private readonly IconsultasServicioAsignatura _servicioAsignatura;
        private readonly IconsultasServicioEstudiante _servicioEstudiante;


        public AsignaturaController(IconsultasServicioAsignatura servicioAsignatura, IconsultasServicioEstudiante servicioEstudiante)
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
            Asignatura asignatura = new Asignatura();
            Asignatura asignatura2 = new Asignatura();
            Asignatura asignatura3 = new Asignatura();

            asignatura.Nombre = "Programacion";
            asignatura2.Nombre = "Lenguaje de marcas";
            asignatura3.Nombre = "Entorno de desarrollo";

            asignatura.Descripcion = "Estructuras de flujo, variables, tipos de datos, bucles, etc";
            asignatura2.Descripcion = "Se introduce en el lenguaje de marcado usado en la web";
            asignatura3.Descripcion = asignatura.Descripcion;

            asignatura.TecnologiasUsadas = "C#, ASP.NET";
            asignatura2.TecnologiasUsadas = "HTML, CSS, JavaScript";
            asignatura3.TecnologiasUsadas = "Java";


            _servicioAsignatura.CrearAsignatura(asignatura);
            _servicioAsignatura.CrearAsignatura(asignatura2);
            _servicioAsignatura.CrearAsignatura(asignatura3);

            Console.WriteLine("[INFO] asignaturas insertadas correctamente");

            return View("~/Views/Home/Index.cshtml");
        }

        [HttpGet]
        public IActionResult SelectAllAsignaturas() 
        {
            Console.WriteLine("[INFO] Realizando un SELECT * FROM asignaturas");

            foreach (Asignatura asignatura in _servicioAsignatura.ObtenerAsignaturas()) 
            {
                Console.WriteLine(asignatura.ToString());
            }

            return View("~/Views/Home/Index.cshtml");
        }
    }
}
