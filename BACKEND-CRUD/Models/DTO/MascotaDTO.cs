using System.ComponentModel.DataAnnotations;

namespace BACKEND_CRUD.Models.DTO
{
    public class MascotaDTO
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20, ErrorMessage = "El nombre no debe ser mayor a 20 caracteres")]
        public string Nombre { get; set; }

        public string Raza { get; set; }
        public string Color { get; set; }
        public int Edad { get; set; }
        public float Peso { get; set; }
    }
}
