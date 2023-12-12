using DAL;
using DAL.Entidades;
using Microsoft.AspNetCore.Mvc;
using reRepasoPuntoNet.Models;
using reRepasoPuntoNet.Services;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace reRepasoPuntoNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IconsultasServicioAsignatura _servicioAsignatura;
        private readonly IconsultasServicioEstudiante _servicioEstudiante;



        public HomeController(
            ILogger<HomeController> logger,
            IconsultasServicioAsignatura servicioAsignatura,
            IconsultasServicioEstudiante servicioEstudiante
            )
        {
            _logger = logger;
            _servicioAsignatura = servicioAsignatura;
            _servicioEstudiante = servicioEstudiante;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult CrearRelacionBidireccional() 
        {
            List<Asignatura> asignaturas = _servicioAsignatura.ObtenerAsignaturas();
            List<Estudiante> estudiantes = _servicioEstudiante.ObtenerEstudiantes();

            //Matriculamos los estudiantes en las asignaturas y actualizamos la bbdd
            foreach (Asignatura a in asignaturas) 
            {
                foreach (Estudiante e in estudiantes) 
                {
                    a.ListaEstudiantes?.Add(e);
                    e.ListaAsignaturas.Add(a);
                    _servicioAsignatura.ActualizarAsignatura(a);
                    _servicioEstudiante.ActualizarEstudiante(e);
                }
            }


            Console.WriteLine("[INFO] creada la relación con exito");

            return View("~/Views/Home/Index.cshtml"); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
