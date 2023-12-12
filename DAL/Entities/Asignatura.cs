using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL.Entidades
{
    [Table("Asignaturas_DAW", Schema = "universidad")]
    public class Asignatura
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("modulo")]
        public string Nombre { get; set; }

        public string? TecnologiasUsadas { get; set; }

        public string? Descripcion { get; set; }

        [InverseProperty("ListaAsignaturas")]
        [ForeignKey("asignatura_id_fk")]
        public List<Estudiante>? ListaEstudiantes { get; set; } = new List<Estudiante>();

        public Asignatura() { }

        public Asignatura(string nombre, string tecnologiasUsadas, string descripcion) 
        {
            Nombre = nombre;
            TecnologiasUsadas = tecnologiasUsadas;
            Descripcion = descripcion;
        }

        public override string ToString() 
        {
            return String.Format("\n\t--- Datos Asignatura ---\nNombre: {0}\nTecnologias Usadas: {1}\nDescripción: {2}", Nombre, TecnologiasUsadas, Descripcion);
        }
    }
}
