using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades
{
    [Table("alumnos_DAW", Schema = "universidad")]
    public class Estudiante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("nombre_alumno"),]
        public string Nombre { get; set; }

        [Column("apellidos_alumno")]
        public string? Apellidos { get; set; }

        [Required]
        [Column("email")]
        public string CorreoElectronico { get; set; }

        [Required]
        [Column("documento_identidad")]
        public string DNI { get; set; }

        [Column("fch_nacimiento")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaNacimiento { get; set; }

        [InverseProperty("ListaEstudiantes")]
        [ForeignKey("estudiante_id_fk")]
        public List<Asignatura> ListaAsignaturas { get; set; } = new List<Asignatura>();

        public Estudiante() { }

        public Estudiante(string nombre, string apellidos, string correoElectronico, string dni, DateTime? fechaNacimiento)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            CorreoElectronico = correoElectronico;
            DNI = dni;
            FechaNacimiento = fechaNacimiento;
        }

        public override string ToString()
        {
            return String.Format("\n\t--- Datos Estudiante ---\nNombre: {0}\nApellidos: {1}\nEmail: {2}\nDNI: {3}\nFecha de nacimiento: {4}", Nombre, Apellidos, CorreoElectronico, DNI, FechaNacimiento);
        }
    }
}
