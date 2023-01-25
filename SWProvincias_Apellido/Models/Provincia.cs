using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWProvincias_Rivera.Models
{
    [Table("Provincia")]
    public class Provincia
    {        
        public int ProvinciaId { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre { get; set; }
        public List<Ciudad> Ciudades { get; set; }

    }
}
