using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalityProject.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        public required string RoomNumber { get; set; }

        [Required]
        public int Capacity { get; set; }
        
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
