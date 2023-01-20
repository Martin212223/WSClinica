using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSClinica.Models
{
    [Table("Habitacion")]
    public class Habitacion
    {
        public int Id { get; set; }

        [Range(1, 100, ErrorMessage = "Solo admite números entre 1 y 100.")]
        [RegularExpression(@"^AAA\.?[0-9]{3}$", ErrorMessage = "Debe contener AAA seguido del número de habitación.")]
        public int Numero { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Estado { get; set; }

        public int ClinicaId { get; set; }

        [ForeignKey("ClinicaId")]
        public Clinica Clinica { get; set; }

    }

}
