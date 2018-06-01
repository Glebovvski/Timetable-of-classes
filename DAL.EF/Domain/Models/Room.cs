using System.ComponentModel.DataAnnotations;

namespace Schedule_CodeFirstModel.Models
{
    public class Room
    {
        [Required]
        public int Id { get; set; }
        public int Number { get; set; }
        public int PlacesAmount { get; set; }
    }
}